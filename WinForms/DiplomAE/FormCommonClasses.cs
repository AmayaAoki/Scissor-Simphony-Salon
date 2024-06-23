using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace DiplomAE
{
    internal class FormCommonClasses
    {
    }
    //----------------------------------------------------------------------------  выход 
    public static class ExitHelper
    {
        public static DialogResult ShowExitConfirmation(Form currentForm)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form != currentForm)
                    {
                        form.Hide();
                    }
                }
                currentForm.Hide(); // Закрываем текущую форму
                RegEnter exitform = new RegEnter();
                exitform.StartPosition = FormStartPosition.CenterScreen;
                exitform.Show();
            }
            return result;
        }
        public static void BindExitButton(Button exitButton, Form currentForm)
        {
            exitButton.Click += (sender, e) => ShowExitConfirmation(currentForm);
            currentForm.FormClosing += (sender, e) =>
            {
                DialogResult result = ShowExitConfirmation(currentForm);
                if (result == DialogResult.No)
                {
                    // Отменим закрытие формы
                    e.Cancel = true;
                }
            };
        }
    }
    //---------------------------------------------------------------------------- фото
    public static class FormHelper
    {
        public static void LoadPhoto(string photoName, PictureBox pictureBox)
        {
            string imagePath = $"{photoName}.jpg";
            string folderPath = @"..\..\Resourses\"; // Относительный путь к папке с изображениями
            string fullPath = Path.Combine(folderPath, imagePath);
            if (File.Exists(fullPath))
            {
                pictureBox.BackgroundImage = Image.FromFile(fullPath);
                pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                imagePath = $"{photoName}.png";
                fullPath = Path.Combine(folderPath, imagePath);
                if (File.Exists(fullPath))
                {
                    pictureBox.BackgroundImage = Image.FromFile(fullPath);
                    pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    MessageBox.Show($"Изображение '{photoName}' не найдено в указанной папке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    // ------------------------------------------------------------------------------------------ чат
    public static class ChatHelper
    {
        public static void InitializeChat(RichTextBox writeTextBox, FlowLayoutPanel chatFlowLayoutPanel, Button sendButton, SqlConnection sqlConnection)
        {
            if (writeTextBox == null  || chatFlowLayoutPanel == null || sendButton == null || sqlConnection == null)
            {
                throw new ArgumentNullException("Один или более аргументов пусты.");
            }
            writeTextBox.KeyPress += (sender, e) => RichTextBox_KeyPress(sender, e, writeTextBox, sendButton);
            LoadChatFromDatabase(chatFlowLayoutPanel, sqlConnection);
            sendButton.Click += (sender, e) => SendButton_Click(sender, e, writeTextBox, chatFlowLayoutPanel, sqlConnection);
        }
        private static void RichTextBox_KeyPress(object sender, KeyPressEventArgs e, RichTextBox writeTextBox, Button sendButton)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(writeTextBox.Text))
                {
                    MessageBox.Show("Введите сообщение!");
                }
                else
                {
                    sendButton.PerformClick();
                }
                
            }
        }
        private static void SendButton_Click(object sender, EventArgs e, RichTextBox writeTextBox, FlowLayoutPanel chatFlowLayoutPanel, SqlConnection sqlConnection)
        {
            if (sqlConnection == null)
            {
                throw new ArgumentNullException(nameof(sqlConnection), "SqlConnection is null");
            }
            if (string.IsNullOrWhiteSpace(writeTextBox.Text))
            {
                MessageBox.Show("Введите сообщение!");
                return;
            }
            string query = "INSERT INTO Messenger (Text, Sender, Date, Status, Photo) VALUES (@Text, @Sender, @Date, @Status, @Photo)";
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Sender", Global.FIO);
            command.Parameters.AddWithValue("@Text", writeTextBox.Text);
            command.Parameters.AddWithValue("@Date", DateTime.Now);
            command.Parameters.AddWithValue("@Status", Global.Astatus ? "Администратор" : "Сотрудник");
            command.Parameters.AddWithValue("@Photo", Global.photo);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            AddChatMessage(chatFlowLayoutPanel, Global.FIO, writeTextBox.Text, DateTime.Now.ToString(), Global.Astatus ? "Администратор" : "Сотрудник", Global.photo);
            writeTextBox.Clear();
            chatFlowLayoutPanel.ScrollControlIntoView(chatFlowLayoutPanel.Controls[chatFlowLayoutPanel.Controls.Count - 1]);
        }
        private static void LoadChatFromDatabase(FlowLayoutPanel chatFlowLayoutPanel, SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM Messenger ORDER BY Date ASC";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AddChatMessage(
                    chatFlowLayoutPanel,
                    reader["Sender"].ToString(),
                    reader["Text"].ToString(),
                    reader["Date"].ToString(),
                    reader["Status"].ToString(),
                    reader["Photo"].ToString()
                );
            }
            sqlConnection.Close();
        }
        private static void AddChatMessage(FlowLayoutPanel chatFlowLayoutPanel, string sender, string message, string date, string status, string photo)
        {
            var chatMessageControl = new ChatUserControl
            {
                Sender = sender,
                Message = message,
                SendDate = date,
                Status = status,
                Anchor = AnchorStyles.Right | AnchorStyles.Left ,
                //Dock = DockStyle.Top,
                Width = chatFlowLayoutPanel.ClientSize.Width,  // Adjust width as needed
            };
            // Загрузка изображения профиля
            var profileImage = LoadPhoto(photo);
            if (profileImage != null)
            {
                chatMessageControl.ProfileImage = profileImage;
            }
            chatFlowLayoutPanel.Controls.Add(chatMessageControl);
        }
        public static Image LoadPhoto(string photoName)
        {
            if (string.IsNullOrEmpty(photoName))
            {
                return null;
            }
            string imagePath = $"{photoName}.jpg";
            string folderPath = @"..\..\Resourses\"; // Относительный путь к папке с изображениями
            string fullPath = Path.Combine(folderPath, imagePath);
            if (File.Exists(fullPath))
            {
                return Image.FromFile(fullPath);
            }
            else
            {
                imagePath = $"{photoName}.png";
                fullPath = Path.Combine(folderPath, imagePath);
                if (File.Exists(fullPath))
                {
                    return Image.FromFile(fullPath);
                }
                else
                {
                    MessageBox.Show($"Изображение '{photoName}.jpg' или '{photoName}.png' не найдено в указанной папке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }

    // ------------------------------------------------------------ переключение вкладок
    public static class TabControlHelper
    {
        public static void InitializeTabControl(TabControl tabControl, Button refreshallB, params DataGridView[] dataGridViews)
        {
            if (tabControl == null || refreshallB == null || dataGridViews.Any(dgv => dgv == null))
            {
                throw new ArgumentNullException("Один или более аргументов пустые");
            }
            tabControl.SelectedIndexChanged += (sender, e) => TabControl_SelectedIndexChanged(sender, e, tabControl, refreshallB, dataGridViews);
        }
        private static void TabControl_SelectedIndexChanged(object sender, EventArgs e, TabControl tabControl, Button refreshallB, params DataGridView[] dataGridViews)
        {
            // Получаем индекс выбранной вкладки
            int selectedIndex = tabControl.SelectedIndex;
            if (Global.Astatus)
            {
                // Выполняем действия в зависимости от выбранной вкладки
                switch (selectedIndex)
                {
                    case 0:  
                    case 1:
                    case 3:
                        refreshallB.Visible = true;
                        break;
                    case 2:
                    case 4:
                        // Действия для 3 и 4 вкладки
                        refreshallB.Visible = false;
                        break;
                    // Добавьте действия для других вкладок по мере необходимости
                    default:
                        break;
                }
            }
            else
            {
                // Выполняем действия в зависимости от выбранной вкладки
                switch (selectedIndex)
                {
                    case 0:
                        // Действия для первой вкладки
                        refreshallB.Visible = true;
                        //LoadData(dataGridViews[0], "SELECT * FROM Appointments");
                        //FullData(dataGridViews[0]);
                        break;
                    case 1:
                        
                        // Действия для 2 вкладки
                        refreshallB.Visible = false;
                        break;
                    // Добавьте действия для других вкладок по мере необходимости
                    default:
                        break;
                }
            }
        }
    }
    // ---------------------------------------------------------------------        загрузка данных в таблицу
    public static class CommonHelper
    {
        // Метод для загрузки данных в DataGridView
        public static void LoadData(DataGridView dataGridView, string query)
        {
            dataGridView.DataSource = GetData(query);
        }
        // Метод для получения данных из базы данных
        private static DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(Global.connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
    }
    // -----------------------------------------------------------------   добавление и изменение таблицы базы данных через SQL. Огромный код
    public class DatabaseHelper
    {
        private readonly string _connectionString;
        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool CheckRecordExists(string tableName, string[] columnNames, string[] columnValues)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE ";
            query += string.Join(" AND ", columnNames.Select((name, index) => $"{name} = @{name}"));

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@{columnNames[i]}", columnValues[i]);
                    }

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке существования записи: {ex.Message}");
                return false;
            }
        }
        // Метод для проверки на занятое время
        public bool IsTimeSlotOccupied(string employeeId, string date, string time)
        {
            string checkQuery = "SELECT EventTime FROM Appointments WHERE EmployeeId = @EmployeeId AND Date = @Date";

            using (SqlConnection connection = new SqlConnection(Global.connectionstring))
            {
                SqlCommand command = new SqlCommand(checkQuery, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@Date", date);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                bool timeExists = false;
                List<string> existingTimes = new List<string>();
                while (reader.Read())
                {
                    string existingTime = reader["EventTime"].ToString();
                    if (existingTime == time)
                    {
                        timeExists = true;
                    }
                    existingTimes.Add(existingTime);
                }
                reader.Close();
                if (timeExists)
                {
                    MessageBox.Show("На данное время запись уже существует.");
                    if (existingTimes.Count > 0)
                    {
                        string times = string.Join(", ", existingTimes);
                        MessageBox.Show($"На этот день занято время на: {times}");
                    }
                    return true;
                }
                return false;
            }
        }
        public void InsertOrUpdateRecord(DataGridView table, string query, string tableName, string[] columnNames, string[] newcolumnValues, string[] oldcolumnValues)
        {
            // Предполагая, что первый столбец является первичным ключом
            string[] updateColumns = columnNames.Skip(1).ToArray();
            string[] updateValues = newcolumnValues.Skip(1).ToArray();
            if (CheckRecordExists(tableName, columnNames, oldcolumnValues))
            {
                UpdateRecord(tableName, columnNames, newcolumnValues, updateColumns, updateValues);
                CommonHelper.LoadData(table, query);
                return;
            }
            else
            {
                InsertRecord(tableName, columnNames, newcolumnValues);
                CommonHelper.LoadData(table, query);
                return;
            }
        }
        private void InsertRecord(string tableName, string[] columnNames, string[] columnValues)
        {
            string query = $"INSERT INTO {tableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", columnNames.Select(c => "@" + c))})";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@{columnNames[i]}", columnValues[i]);
                    }
                    LogParameters(command);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись добавлена.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
        private void UpdateRecord(string tableName, string[] columnNames, string[] columnValues, string[] updateColumns, string[] updateValues)
        {
            string query = $"UPDATE {tableName} SET ";
            for (int i = 0; i < updateColumns.Length; i++)
            {
                query += $"{updateColumns[i]} = @{updateColumns[i]}";
                if (i < updateColumns.Length - 1)
                {
                    query += ", ";
                }
            }
            query += $" WHERE {columnNames[0]} = @{columnNames[0]}";
            if ( Global.status == "Сотрудник")
            {
                query += $" AND ID = {Global.AppointmentID}";
                
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < updateColumns.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@{updateColumns[i]}", updateValues[i]);
                    }
                    command.Parameters.AddWithValue($"@{columnNames[0]}", columnValues[0]);
                    Console.WriteLine("Query: " + query);
                    LogParameters(command);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись обновлена.");
                    }
                    else
                    {
                        MessageBox.Show(query);
                        MessageBox.Show("Запись не была обновлена. Проверьте правильность введенных данных.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении записи: {ex.Message}");
            }
        }
        private void LogParameters(SqlCommand command)
        {
            foreach (SqlParameter param in command.Parameters)
            {
                Console.WriteLine($"{param.ParameterName}: {param.Value}");
            }
        }
    }
    //--------------------------------------------------------------------------------  Проверка на пустые строки
    public static class Validator
    {
        private static readonly string[] ForbiddenWords = { "Дата:", "Время:", "Сотрудник:", "Пользователь:", "Статус:", "Услуга:", "Название услуги:", "Описание услуги:", "Стоимость:", "Имя фотографии:", "Номер категории:" };
        public static (bool IsValid, string ErrorMessage) ValidateInputs(params (string Name, string Value)[] inputs)
        {
            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input.Value))
                {
                    return (false, $"Поле '{input.Name}' пустое.");
                }
                foreach (var forbiddenWord in ForbiddenWords)
                {
                    if (input.Value.IndexOf(forbiddenWord, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return (false, $"Поле '{input.Name}' содержит запрещённое слово: {forbiddenWord}.");
                    }
                }
            }
            return (true, string.Empty);
        }
    }
    public static class CheckEmpty
    {
        public static bool RegisterTextBoxHandlers(List<string> forbiddenWords, params Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text) || forbiddenWords.Any(word => textBox.Text.Contains(word)))
                    {
                        // Подсвечиваем красным, если пусто
                        textBox.BackColor = Color.Pink;
                        // Выводим сообщение об ошибке
                        MessageBox.Show($"Вы оставили одно из полей пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; 
                    }
                    else
                    {
                        // Сбрасываем цвет фона, если не пусто
                        textBox.BackColor = SystemColors.Window;
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.SelectedIndex == -1 || forbiddenWords.Any(word => comboBox.SelectedItem.ToString().Contains(word)))
                    {
                        // Подсвечиваем красным, если ничего не выбрано
                        comboBox.BackColor = Color.Pink;
                        // Выводим сообщение об ошибке
                        MessageBox.Show($"Вы оставили значение одного из списка пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; 
                    }
                    else
                    {
                        // Сбрасываем цвет фона, если все хорошо
                        comboBox.BackColor = SystemColors.Window;
                    }
                }
            }
            return true; // Возвращаем true, если все TextBox заполнены
        }
    }


    

}
