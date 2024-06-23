using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomAE
{
    public partial class FormEmployee : Form
    {
        SqlConnection sqlConnection = new SqlConnection(Global.connectionstring);
        public DateTime date;
        public FormEmployee()
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
            TabControlHelper.InitializeTabControl(tabControl1, RefreshB, AppointmentsDVG);
        }
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            UpdateQuery();
        }
        private void UpdateQuery()
        {
            string emp = "SELECT * FROM Appointments WHERE EmployeeID LIKE '" + Global.FIO + "'";
            CommonHelper.LoadData(AppointmentsDVG, emp);
        }
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
                        if (currentTabIndex == 1)
                        {
                            editTable.UserTB2.Text = selectedRow.Cells["UserId"].Value.ToString();
                            editTable.ServiceTB2.Text = selectedRow.Cells["ServiceId"].Value.ToString();
                            editTable.DateTB2.Text = Convert.ToDateTime(selectedRow.Cells["Datee"].Value).ToShortDateString();
                            editTable.EventTime2.Text = selectedRow.Cells["Timee"].Value.ToString();
                            editTable.StatusCB2.Text = selectedRow.Cells["Statuss"].Value.ToString();
                            Global.AppointmentID = selectedRow.Cells["ID"].Value.ToString();
                            // Сохраняем старые значения перед проверкой
                            Global.procedureid = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                            Global.EmployeeID = editTable.EmployeeTB.Text;
                            Global.ClientID = editTable.UserTB2.Text;
                            Global.ServiseID = editTable.ServiceTB2.Text;
                            Global.date = Convert.ToDateTime(selectedRow.Cells["Datee"].Value);
                            var cellValue = selectedRow.Cells["Timee"].Value;

                            if (cellValue != null)
                            {
                                // Преобразуйте значение в TimeSpan и обновите глобальную переменную
                                TimeSpan timeValue;
                                if (TimeSpan.TryParse(cellValue.ToString(), out timeValue))
                                {
                                    Global.time1 = timeValue;
                                    //MessageBox.Show($"Global.time1 updated to: {Global.time1}");
                                }
                                else
                                {
                                    MessageBox.Show("Неверный формат времени.");
                                }
                            }
                            Global.StatusS = editTable.StatusCB2.Text;
                        }
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------
        // кнопка профиль
        private void ProfileB_Click(object sender, EventArgs e)
        {
            FormProfile profileedit = new FormProfile();
            profileedit.ShowDialog();
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            FormAddAndFilter existingForm = Application.OpenForms.OfType<FormAddAndFilter>().FirstOrDefault();
            if (existingForm != null)
            {
                existingForm.Activate(); // Активируем уже открытую форму
            }
            else
            {
                FormAddAndFilter form = new FormAddAndFilter();
                form.FromForm = "Employee";
                form.DataGrid = AppointmentsDVG;
                form.Show();
            }
        }
        private void RefreshOrCancelChanges(bool cancel)
        {
            string confirmationMessage = cancel ? "отменить изменения" : "обновить данные";
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите {confirmationMessage}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DataGridView dataGridView = AppointmentsDVG;
                    UpdateQuery();
                    MessageBox.Show(cancel ? "Изменения сброшены." : "Данные обновлены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        // обновление всех таблиц
        private void RefreshB_Click(object sender, EventArgs e)
        {
            RefreshOrCancelChanges(cancel: false);
        }
        private void CancelB_Click(object sender, EventArgs e)
        {
            RefreshOrCancelChanges(cancel: true);
            // Дополнительно обновляем данные для таблицы Appointments после отмены изменений
            UpdateQuery();
        }
        //-----------------------------------------------------------------------------------------------
        // удаление строки - сотрудники
        private void DelB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данные?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DataGridView dataGridView = AppointmentsDVG;
                    if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
                    {
                        int selectedIndex = dataGridView.SelectedRows[0].Index;
                        string tableName = "Appointments" ; // Замените на имя вашей таблицы
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
                                UpdateQuery();
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
        // сохранение кнопка - сотрудники - записи
        private void SaveB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить данные?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Определение текущего DataGridView на активной вкладке TabControl
                    DataGridView currentDataGridView = AppointmentsDVG;
                    // Если текущий DataGridView не null, сохраняем изменения
                    if (currentDataGridView != null)
                    {
                        SaveChangesToDatabase(currentDataGridView);
                        UpdateQuery();
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
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    query = $"UPDATE Appointments SET EmployeeId = '" + Global.FIO + "', UserId = @userId, ServiceId = @serviceId, Date = @date,EventTime = @EventTime, Status = @status WHERE ID = @id";
                    command.Parameters.AddWithValue("@userId", row.Cells["UserId"].Value);
                    command.Parameters.AddWithValue("@serviceId", row.Cells["ServiceId"].Value);
                    command.Parameters.AddWithValue("@date", row.Cells["Datee"].Value);
                    command.Parameters.AddWithValue("@status", row.Cells["Statuss"].Value);
                    command.Parameters.AddWithValue("@EventTime", row.Cells["Timee"].Value);
                    command.Parameters.AddWithValue("@id", id);
                if (!string.IsNullOrEmpty(query))
                {
                    command.CommandText = query;
                    command.Connection = sqlConnection;
                    command.ExecuteNonQuery();
                }
            }
            sqlConnection.Close();
        }
        private void DelFilterB_Click(object sender, EventArgs e)
        {
            DelFilterB.Visible = false;
            UpdateQuery();
        }
        //фильтрация
        public string FromForm2 { get; set; }
        public void ApplyFilter()
        {
            DelFilterB.Visible = true;
            try
            {
                CommonHelper.LoadData(AppointmentsDVG, "SELECT * FROM Appointments WHERE " + FromForm2);
                //MessageBox.Show("Применен фильтр по: " + FromForm2);
                MessageBox.Show("Фильтр применен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при применении фильтра: " + ex.Message);
            }
        }
    }
}

