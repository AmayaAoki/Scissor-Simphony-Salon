using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace DiplomAE
{
    public partial class RegEnter : Form
    {
        SqlConnection sqlConnection = new SqlConnection(Global.connectionstring);
        public RegEnter()
        {
            InitializeComponent();
            //автоматизация
            // Добавляем обработчик событий Enter
            this.txtUsername.Enter += new EventHandler(textbox_Enter);
            this.txtPassword.Enter += new EventHandler(textbox_Enter);
            this.RegFIO.Enter += new EventHandler(textbox_Enter);
            this.RegUsername.Enter += new EventHandler(textbox_Enter);
            this.RegPassword.Enter += new EventHandler(textbox_Enter);

            // Добавляем обработчик событий Leave
            this.txtUsername.Leave += new EventHandler(textbox_Leave);
            this.txtPassword.Leave += new EventHandler(textbox_Leave);
            this.RegFIO.Leave += new EventHandler(textbox_Leave);
            this.RegUsername.Leave += new EventHandler(textbox_Leave);
            this.RegPassword.Leave += new EventHandler(textbox_Leave);

            // Добавляем обработчик события KeyDown для TextBox
            this.txtUsername.KeyDown += new KeyEventHandler(textbox_KeyDown);
            this.txtPassword.KeyDown += new KeyEventHandler(textbox_KeyDown);
            this.RegFIO.KeyDown += new KeyEventHandler(textbox_KeyDown);
            this.RegUsername.KeyDown += new KeyEventHandler(textbox_KeyDown);
            this.RegPassword.KeyDown += new KeyEventHandler(textbox_KeyDown);
        }
        // Обработчик событий Enter
        private void textbox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox == txtPassword || textBox == RegPassword)
            {
                textBox.PasswordChar = '•';
            }
            textBox.Text = "";
            textBox.ForeColor = Color.Black;
        }
        // Обработчик событий Leave
        private void textbox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string defaultText = string.Empty;
            switch (textBox.Name)
            {
                case "txtUsername":
                case "RegUsername":
                    defaultText = "Логин:";
                    break;
                case "txtPassword":
                case "RegPassword":
                    defaultText = "Пароль:";
                    break;
                case "RegFIO":
                    defaultText = "ФИО:";
                    break;
            }
            if (string.IsNullOrEmpty(textBox.Text))
            {
                // Если текстовое поле пустое, выполняем действия
                if (textBox == txtPassword || textBox == RegPassword)
                {
                    txtPassword.PasswordChar = '\0';
                }
                textBox.Text = defaultText;
                textBox.ForeColor = Color.Gray;

                if (textBox == txtUsername || textBox == RegUsername)
                {
                    Global.login = textBox.Text;
                }
                else if (textBox == RegFIO)  
                {
                    Global.FIO = textBox.Text;
                }
                else
                {
                    Global.password = textBox.Text;
                }
            }
        }
        // Обработчик события KeyDown для TextBox
        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                // Перемещаем фокус на следующий элемент управления
                SelectNextControl(textBox, true, true, true, true);
                // Предотвращаем дальнейшую обработку нажатия клавиши
                e.Handled = true;
            }
        }
        // Обработчик события KeyDown для кнопки "Отправить"
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Вызываем метод, который обрабатывает нажатие кнопки "Отправить"
                EntButton.PerformClick();
                // Предотвращаем дальнейшую обработку нажатия клавиши
                e.Handled = true;
            }
        }
        //скрытие или показ пароля
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.PasswordChar = '\0';   // Unmasks password when checked
            }
            else
            {
                txtPassword.PasswordChar = '•';    // Resumes masking when unchecked
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                RegPassword.PasswordChar = '\0';   // Unmasks password when checked
            }
            else
            {
                RegPassword.PasswordChar = '•';    // Resumes masking when unchecked
            }
        }
        //-----------------------------------------------------------------------------------------
        // авторизация
        private void EntButton_Click(object sender, EventArgs e)
        {
            // Проверка на пустые значения
            List<string> forbiddenWords = new List<string> { "Логин:", "Пароль:" };
            bool allFilled = CheckEmpty.RegisterTextBoxHandlers(forbiddenWords,txtUsername, txtPassword);
            if (allFilled==false)
            {
                return;
            }
            //Авторизация
            string login = txtUsername.Text;
            string password = txtPassword.Text;
            string photo = null;
            string fio = null;
            bool admin = CheckLoginAndPassword(login, password, out photo, out fio);
            if (fio != null)
            {
                // Заносим значения Photo и FIO в глобальные переменные
                Global.photo = photo;
                Global.FIO = fio;
                Global.login = login;
                Global.password = password;
                MessageBox.Show($"Добрый день, {fio}!");
                // Выполняем действия для администратора
                if (admin)
                {
                    FormAdmin adminform = new FormAdmin();
                    Global.status = "Администратор";
                    Global.Astatus = true;
                    adminform.StartPosition = FormStartPosition.CenterScreen;
                    adminform.Show();
                }
                else
                {
                    Global.Astatus = false;
                    // Выполняем действия для сотрудника
                    FormEmployee employeeform = new FormEmployee();
                    Global.status = "Сотрудник";
                    employeeform.StartPosition = FormStartPosition.CenterScreen;
                    employeeform.Show();
                }
                Hide();
            }
            else
            {
                MessageBox.Show("Произошла ошибка. Проверьте правильность введенных данных.");
            }
        }
        // SQL проверка данных
        private bool CheckLoginAndPassword(string login, string password, out string photo, out string fio)
        {
            photo = null;
            fio = null;
            bool admin = false;
            sqlConnection.Open();
            string query = "SELECT ID, Photo, FIO FROM Admnistrator WHERE Login = @login AND Password = @password; " +
                            "SELECT Photo, FIO FROM Employee WHERE Login = @login AND Password = @password;";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        admin = true;
                        Global.Astatus = true;
                        Global.ADMINID = int.Parse(reader["ID"].ToString());
                        photo = reader["Photo"].ToString();
                        fio = reader["FIO"].ToString();
                    }
                    else
                    {
                        reader.NextResult();
                        if (reader.Read())
                        {
                            admin = false;
                            Global.Astatus = true;

                            photo = reader["Photo"].ToString();
                            fio = reader["FIO"].ToString();
                        }
                    }
                }
            }
            sqlConnection.Close();
            return admin;
        }
        //--------------------------------------------------------------------------------------------------------------------------
        private void RegButton_Click(object sender, EventArgs e)
        {
            // Проверка на пустые значения
            List<string> forbiddenWords = new List<string> { "ФИО:", "Логин:", "Пароль:", "Фото:", "Должность:" };
            bool allFilled = CheckEmpty.RegisterTextBoxHandlers(forbiddenWords, RegFIO, RegUsername, RegPassword, RegPhoto, RegStatus);
            if (allFilled == false)
            {
                return;
            }
            //Регистрация
            string fio = RegFIO.Text;
            string login = RegUsername.Text;
            string password = RegPassword.Text;
            string photo = RegPhoto.Text;
            string status = RegStatus.Text;
            bool success = SQLRegistration(login, password, fio, photo, status);
            if (success)
            {
                if (fio != null)
                {
                    MessageBox.Show($"Здравствуйте, {fio}! Вы успешно зарегистрированы");
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка. Проверьте правильность введенных данных.");
            }
        }
        // SQL запись данных
        private bool SQLRegistration(string login, string password, string fio, string photo, string status)
        {
            string query;
            string checkQuery = "SELECT COUNT(*) FROM (SELECT Login FROM Admnistrator UNION SELECT Login FROM Employee) AS Users WHERE Login = @login";
            sqlConnection.Open();
            // Проверка на существование пользователя
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, sqlConnection))
            {
                checkCommand.Parameters.AddWithValue("@login", login);
                int userCount = (int)checkCommand.ExecuteScalar();

                if (userCount > 0)
                {
                    // Пользователь уже существует
                    MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sqlConnection.Close();
                    return false;
                }
            }
            // Выполнение вставки в базу данных
            if (status == "Администратор")
            {
                query = "INSERT INTO Admnistrator (FIO, Login, Password, Photo) VALUES (@fio, @login, @password, @photo)";
            }
            else
            {
                query = "INSERT INTO Employee (FIO, Login, Password, Photo) VALUES (@fio, @login, @password, @photo)";
            }
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@fio", fio);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@photo", photo);

                int rowsAffected = command.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return true;
        }
        // ---------------- фото
        private void RegPhoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = RegPhoto.SelectedItem.ToString();
            string imagePath = $"{selectedItem}.jpg";
            string folderPath = @"..\..\Resourses\"; // относительный путь к папке с изображениями
            // Проверяем, что элемент существует
            if (!string.IsNullOrEmpty(selectedItem))
            {
                // Пытаемся найти изображение в указанной папке
                string fullPath = Path.Combine(folderPath, imagePath);
                if (System.IO.File.Exists(fullPath))
                {
                    // Устанавливаем изображение в качестве фона PictureBox
                    CBphoto.BackgroundImage = System.Drawing.Image.FromFile(fullPath);
                    // Устанавливаем режим масштабирования фона
                    CBphoto.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    MessageBox.Show($"Изображение '{selectedItem}' не найдено в указанной папке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // выход из приложения
        private void Exit(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из приложения?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // Отменим закрытие формы
                e.Cancel = true;
            }
        }
    }




}
