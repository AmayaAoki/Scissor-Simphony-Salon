using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DiplomAE
{
    public partial class FormAdmin : Form
    {
        SqlConnection sqlConnection = new SqlConnection(Global.connectionstring);
        public DateTime date;
        public bool Record = false;
        public FormAdmin()
        {
            InitializeComponent();
            //выход из приложения
            ExitHelper.BindExitButton(ExitButton, this);
            // профиль           
            FIO.Text = Global.FIO;
            // фото
            FormHelper.LoadPhoto(Global.photo, photoImg);
            // чат 
            ChatHelper.InitializeChat(writetext, chatFlowLayoutPanel, SendB, sqlConnection);
            // переключение вкладок
            TabControlHelper.InitializeTabControl(tabControl1, refreshallB, AppointmentsDVG, ServicesDVG);
            // Список отчетов  
            OList.View = View.Details;
            OList.Columns.Add("Заголовок", 200);
            OList.Columns.Add("Тип отчета", 150);
            OList.Columns.Add("ID администратора", 100);
            OList.Columns.Add("Дата отчета", 150);
            LoadReports();
            //Обработчики
            this.TBHeader.Enter += new EventHandler(textbox_Enter);
            this.TBHeader.Leave += new EventHandler(textbox_Leave);
            this.TBText.Enter += new EventHandler(textbox_Enter);
            this.TBText.Leave += new EventHandler(textbox_Leave);

        }
        // -------------------------------------------------  очистка чата
        private void Clear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите очистить чат? Сообщения будут удалены у всех пользователей.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Messenger";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                // Очистить chatList
                chatFlowLayoutPanel.Controls.Clear();
            }
        }
        
        //-------------------------------------------------- заполненние таблиц данными
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            CommonHelper.LoadData(AppointmentsDVG, "SELECT * FROM Appointments");
            CommonHelper.LoadData(ServicesDVG, "SELECT * FROM ListOfServices");
            CommonHelper.LoadData(ReviewsDGV, "SELECT * FROM Reviews WHERE Checked = 0");
            CommonHelper.LoadData(FAQDGV, "SELECT * FROM FAQ ");
        }

        private string GetCurrentQuery()
        {
            // Определяем текущий запрос для обновления данных
            if (tabControl1.SelectedIndex == 0)
            {
                return "SELECT * FROM Appointments";
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                return "SELECT * FROM ListOfServices";
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                // Проверяем, какая вкладка открыта во вложенном TabControl ModerTab
                if (ModerTab.SelectedIndex == 0)
                {
                    if (GotoUncheckedBtn.Visible == true)
                    {
                        return "SELECT * FROM Reviews WHERE Checked = 1";
                    }
                    else
                    {
                        return "SELECT * FROM Reviews WHERE Checked = 0";
                    }
                }
                else if (ModerTab.SelectedIndex == 1)
                {
                    return "SELECT * FROM FAQ";
                }
            }
            throw new InvalidOperationException("Не удалось определить текущий запрос для обновления данных.");
        }
        private void RefreshOrCancelChanges(bool cancel)
        {
            string confirmationMessage = cancel ? "отменить изменения" : "обновить данные";
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите {confirmationMessage}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DataGridView dataGridView;
                    string query;
                    if (cancel)
                    {
                        if (Record)
                        {
                            dataGridView = AppointmentsDVG;
                            query = "SELECT * FROM Appointments";
                        }
                        else
                        {
                            dataGridView = ServicesDVG;
                            query = "SELECT * FROM ListOfServices";
                        }
                    }
                    else
                    {
                        dataGridView = GetCurrentDataGridView();
                        query = GetCurrentQuery();
                    }
                    CommonHelper.LoadData(dataGridView, query);
                    if (cancel)
                        Record = false;
                    MessageBox.Show(cancel ? "Изменения сброшены." : "Данные обновлены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        private DataGridView GetCurrentDataGridView()
        {
            // Определяем текущую таблицу для обновления
            if (tabControl1.SelectedIndex == 0)
            {
                return AppointmentsDVG;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                return ServicesDVG;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                // Проверяем, какая вкладка открыта во вложенном TabControl ModerTab
                if (ModerTab.SelectedIndex == 0)
                {
                    return ReviewsDGV;
                }
                else if (ModerTab.SelectedIndex == 1)
                {
                    return FAQDGV;
                }
            }
            throw new InvalidOperationException("Не удалось определить текущую таблицу для обновления.");
        }
        // обновление всех таблиц
        private void refreshallB_Click(object sender, EventArgs e)
        {
            RefreshOrCancelChanges(cancel: false);
        }

        // -------------------------------------------------------------  отмена изменений  - записи
        private void CancelB_Click(object sender, EventArgs e)
        {
            RefreshOrCancelChanges(cancel: true);
            // Дополнительно обновляем данные для таблицы Appointments после отмены изменений
            if (tabControl1.SelectedIndex == 0)
            {
                CommonHelper.LoadData(AppointmentsDVG, "SELECT * FROM Appointments");
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                CommonHelper.LoadData(ServicesDVG, "SELECT * FROM ListOfServices");
            }
        }
        // -------------------------------------------------------------  удаление строки - сотрудники
        private void DeleteB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данные?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DataGridView dataGridView = GetCurrentDataGridView();
                    if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
                    {
                        int selectedIndex = dataGridView.SelectedRows[0].Index;
                        string tableName = dataGridView == AppointmentsDVG ? "Appointments" : "ListOfServices"; // Замените на имя вашей таблицы
                        string query = $"DELETE FROM {tableName} WHERE ID = @ID"; // Замените "ID" на имя столбца с идентификатором
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand(query, sqlConnection))
                        {
                            if (tabControl1.SelectedIndex == 0)
                            {
                                int id = Convert.ToInt32(dataGridView.Rows[selectedIndex].Cells["ID"].Value);
                                command.Parameters.AddWithValue("@ID", id);
                            }
                            else
                            {
                                int id2 = Convert.ToInt32(dataGridView.Rows[selectedIndex].Cells["ID1"].Value);
                                command.Parameters.AddWithValue("@ID", id2);

                            }
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Строка удалена.");
                            CommonHelper.LoadData(dataGridView, GetCurrentQuery()); // Обновляем данные в DataGridView после удаления строки
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить строку.");
                            }
                        }                           
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, выберите всю строку! (нажмите пустую ячейку слева)");
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении строки: " + ex.Message);
                    sqlConnection.Close();
                }
            }
        }
        //--------------------------------------------------------------- сохранение кнопка - сотрудники - записи
        private void SaveB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить данные?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Определение текущего DataGridView на активной вкладке TabControl
                    DataGridView currentDataGridView = GetCurrentDataGridView();
                    // Если текущий DataGridView не null, сохраняем изменения
                    if (currentDataGridView != null)
                    {
                        SaveChangesToDatabase(currentDataGridView);
                        CommonHelper.LoadData(currentDataGridView, GetCurrentQuery());
                        MessageBox.Show("Сохранено!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: не удалось определить текущий DataGridView.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection.Close();
                }
            }
        }       
        private void SaveChangesToDatabase(DataGridView dataGridView)
        {
            // Создаем подключение к базе данных
            sqlConnection.Open();
            // Проходим по каждой строке в DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Проверяем, если строка помечена как удаленная
                if (row.IsNewRow)
                    continue;
                // Формируем и выполняем SQL-запрос в зависимости от таблицы
                string query = "";
                SqlCommand command = new SqlCommand();
                if (dataGridView == AppointmentsDVG)
                {
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    query = "UPDATE Appointments SET EmployeeId = @employeeId, UserId = @userId, ServiceId = @serviceId, Date = @date, EventTime = @EventTime, Status = @status WHERE ID = @id";
                        command.Parameters.AddWithValue("@employeeId", row.Cells["EmployeeId"].Value);
                        command.Parameters.AddWithValue("@userId", row.Cells["UserId"].Value);
                        command.Parameters.AddWithValue("@serviceId", row.Cells["ServiceId"].Value);
                        command.Parameters.AddWithValue("@date", row.Cells["Datee"].Value);
                        command.Parameters.AddWithValue("@EventTime", row.Cells["Timee"].Value);
                        command.Parameters.AddWithValue("@status", row.Cells["Statuss"].Value);
                        command.Parameters.AddWithValue("@id", id);
                }
                else if (dataGridView == ServicesDVG)
                {
                    // Получаем идентификатор строки
                    int id2 = Convert.ToInt32(row.Cells["ID1"].Value);
                    query = "UPDATE ListOfServices SET ProcedureName = @procedureName, Description = @description, Cost = @cost, Photo = @photo, CategoryID = @categoryID WHERE ID = @id";
                    command.Parameters.AddWithValue("@procedureName", row.Cells["ProcedureName"].Value);
                    command.Parameters.AddWithValue("@description", row.Cells["Description"].Value);
                    command.Parameters.AddWithValue("@cost", row.Cells["Cost"].Value);
                    command.Parameters.AddWithValue("@photo", row.Cells["Photos"].Value);
                    command.Parameters.AddWithValue("@categoryID", row.Cells["CategoryID"].Value);
                    command.Parameters.AddWithValue("@id", id2);
                }
                if (!string.IsNullOrEmpty(query))
                {
                    command.CommandText = query;
                    command.Connection = sqlConnection;
                    command.ExecuteNonQuery();
                }
            }
            sqlConnection.Close();
        }
        //---------------------------------------------------------------------------------- КНОПКИ
        // кнопка профиль
        private void ProfileB_Click(object sender, EventArgs e)
        {
            FormProfile profileedit = new FormProfile();
            profileedit.ShowDialog();
        }
        // удалить фильтр
        private void DelFilterB_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                DelFilterB.Visible = false;
                CommonHelper.LoadData(AppointmentsDVG, "SELECT * FROM Appointments");
            }
            else
            {
                DelFilterB2.Visible = false;
                CommonHelper.LoadData(ServicesDVG, "SELECT * FROM ListOfServices");
            }
        }
        // form добавление и фильтр
        private void AddAndFilterBtn_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли уже открытая форма
            FormAddAndFilter existingForm = Application.OpenForms.OfType<FormAddAndFilter>().FirstOrDefault();
            // Логика закрытия и открытия формы в зависимости от tabControl1.SelectedIndex
            if (tabControl1.SelectedIndex == 0)
            {
                if (existingForm != null && existingForm.FromForm == "Admin2")
                {
                    existingForm.Close(); // Закрываем форму Admin2
                    OpenNewForm("Admin",AppointmentsDVG); // Открываем форму Admin
                }
                else if (existingForm == null)
                {
                    OpenNewForm("Admin", AppointmentsDVG); // Открываем форму Admin
                }
            }
            else
            {
                if (existingForm != null && existingForm.FromForm == "Admin")
                {
                    existingForm.Close(); // Закрываем форму Admin
                    OpenNewForm("Admin2", ServicesDVG); // Открываем форму Admin2
                }
                else if (existingForm == null)
                {
                    OpenNewForm("Admin2", ServicesDVG); // Открываем форму Admin2
                }
            }
        }
        private void OpenNewForm(string fromForm,DataGridView table)
        {
            FormAddAndFilter form = new FormAddAndFilter
            {
                FromForm = fromForm,
                DataGrid = table
            };
            form.Show();
        }
        //передача данных из записей
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    DataGridViewRow selectedRow = AppointmentsDVG.Rows[e.RowIndex];
                    // Проверяем, открыта ли форма EditTable
                    FormAddAndFilter editTable = Application.OpenForms["FormAddAndFilter"] as FormAddAndFilter;
                    if (editTable != null)
                    {
                        // Определение текущей вкладки TabControl
                        int currentTabIndex = editTable.tabControl2.SelectedIndex;
                        // В зависимости от выбранной вкладки, устанавливаем значения элементов управления
                        if (currentTabIndex == 0)
                        {
                            editTable.EmployeeTB.Text = selectedRow.Cells["EmployeeId"].Value.ToString();
                            editTable.UserTB.Text = selectedRow.Cells["UserId"].Value.ToString();
                            editTable.ServiceCB.Text = selectedRow.Cells["ServiceId"].Value.ToString();
                            editTable.DateTB.Text = Convert.ToDateTime(selectedRow.Cells["Datee"].Value).ToShortDateString();
                            editTable.EventTime.Text = selectedRow.Cells["Timee"].Value.ToString();
                            editTable.StatusCB.Text = selectedRow.Cells["Statuss"].Value.ToString();
                            // Сохраняем старые значения перед проверкой
                            Global.procedureid = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                            Global.EmployeeID = editTable.EmployeeTB.Text;
                            Global.ClientID = editTable.UserTB.Text;
                            Global.ServiseID = editTable.ServiceCB.Text;
                            Global.date = Convert.ToDateTime(selectedRow.Cells["Datee"].Value);
                            var cellValue = selectedRow.Cells["Timee"].Value;
                            if (cellValue != null)
                            {
                                // Преобразуйте значение в TimeSpan и обновите глобальную переменную
                                TimeSpan timeValue;
                                if (TimeSpan.TryParse(cellValue.ToString(), out timeValue))
                                {
                                    Global.time1 = timeValue;
                                }
                                else
                                {
                                    MessageBox.Show("Неверный формат времени.");
                                }
                            }
                            Global.StatusS = editTable.StatusCB.Text;
                        }
                    }
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    DataGridViewRow selectedRow = ServicesDVG.Rows[e.RowIndex];
                    // Проверяем, открыта ли форма EditTable
                    FormAddAndFilter editTable = Application.OpenForms["FormAddAndFilter"] as FormAddAndFilter;
                    if (editTable != null)
                    {
                        // Определение текущей вкладки TabControl
                        int currentTabIndex = editTable.tabControl2.SelectedIndex;
                        // В зависимости от выбранной вкладки, устанавливаем значения элементов управления
                        if (currentTabIndex == 2)
                        {
                            editTable.ProcedureTB.Text = selectedRow.Cells["ProcedureName"].Value.ToString();
                            editTable.DescriptionTB.Text = selectedRow.Cells["Description"].Value.ToString();
                            editTable.CostTB.Text = selectedRow.Cells["Cost"].Value.ToString();
                            editTable.PhotoTB.Text = selectedRow.Cells["PhotoS"].Value.ToString();
                            string category = selectedRow.Cells["CategoryID"].Value.ToString();
                            switch (category)
                            {
                                case "1":
                                    category = "Женский зал";
                                    break;
                                case "2":
                                    category = "Мужской зал";
                                    break;
                                case "3":
                                    category = "Маникюр и педикюр";
                                    break;
                                default:
                                    category = "Неизвестная категория";
                                    break;
                            }
                            editTable.CategoryCB.Text = category;
                            // Сохранение старых значений
                            Global.procedureid = Convert.ToInt32(selectedRow.Cells["ID1"].Value);
                            Global.oldprocedure = editTable.ProcedureTB.Text;
                            Global.olddescription = editTable.DescriptionTB.Text;
                            Global.oldcost = editTable.CostTB.Text;
                            Global.oldphoto = editTable.PhotoTB.Text;
                            switch (editTable.CategoryCB.Text)
                            {
                                case "Женский зал":
                                    Global.oldcategory = "1";
                                    break;
                                case "Мужской зал":
                                    Global.oldcategory = "2";
                                    break;
                                case "Маникюр и педикюр":
                                    Global.oldcategory = "3";
                                    break;
                                default:
                                    Global.oldcategory = "0"; // или "Неизвестная категория"
                                    break;
                            }

                        }
                    }
                }
                
            }
        }

        //передача данных из услуг
        public string FromForm2 { get; set; }
        // фильтрация
        public void ApplyFilter()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                DelFilterB.Visible = true;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                DelFilterB2.Visible = true;
            }
            try
            {
                if ( tabControl1.SelectedIndex == 0 )
                {
                    CommonHelper.LoadData(AppointmentsDVG, "SELECT * FROM " + FromForm2);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    CommonHelper.LoadData(ServicesDVG, "SELECT * FROM " + FromForm2);
                }
                //MessageBox.Show("Применен фильтр по: "+ FromForm2);
                MessageBox.Show("Фильтр применен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при применении фильтра: " + ex.Message);
            }
        }
        
    }
}
