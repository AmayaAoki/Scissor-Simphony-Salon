using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomAE
{
    public partial class FormProfile : Form
    {
        SqlConnection sqlConnection = new SqlConnection(Global.connectionstring);
        string oldFIO;
        public string oldphoto;
        string status;
        public FormProfile()
        {
            InitializeComponent();
            TBfio.Text = Global.FIO;
            oldFIO = TBfio.Text;
            TBlogin.Text = Global.login;
            TBpassword.Text = Global.password;
            // Проверяем, есть ли уже это значение в ComboBox
            if (!CBphoto.Items.Contains(Global.photo))
            {
                // Добавляем значение, если его еще нет
                CBphoto.Items.Add(Global.photo);
            }
            CBphoto.Text = Global.photo;
            oldphoto = CBphoto.Text;
        }
        // сохранить
        private void Apply_Click(object sender, EventArgs e)
        {
            // Проверка на пустые значения
            List<string> forbiddenWords = new List<string> { "ФИО:","Логин:", "Пароль:", "Фото:" };
            bool allFilled = CheckEmpty.RegisterTextBoxHandlers(forbiddenWords, TBfio, TBlogin, TBpassword, CBphoto);
            if (allFilled == false)
            {
                return;
            }
            DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Global.FIO = TBfio.Text;
                Global.login = TBlogin.Text;
                Global.password = TBpassword.Text;
                Global.photo = CBphoto.Text;

                if (Global.Astatus)
                {
                    status = "Администратор";
                }
                else
                {
                    status = "Сотрудник";
                }
                SQLUpdate(Global.login, Global.password, Global.FIO, Global.photo, status, oldFIO);
                // Выполняем действие, если пользователь нажал кнопку "Да"
                MessageBox.Show("Изменения сохранены. Пожалуйста, перезайдите в аккаунт, чтобы изменения применились.");
                Hide();
            }
            else
            {
                MessageBox.Show("Изменения сброшены.");
            }
        }
        // SQL запись данных
        private bool SQLUpdate(string login, string password, string fio, string photo, string status, string oldFIO)
        {
            bool admin = false;
            string query;
            sqlConnection.Open();
            if (status == "Администратор")
            {
                query = "UPDATE Admnistrator SET Password = @password, FIO = @fio, Photo = @photo, Login = @login  WHERE FIO = @oldFIO";
                admin = true;
            }
            else
            {
                query = "UPDATE Employee SET Password = @password, FIO = @fio, Photo = @photo, Login = @login WHERE FIO = @oldFIO";
                string query3 = "UPDATE Appointments SET EmployeeId = @fio WHERE EmployeeId = @oldFIO";
                admin = false;
                using (SqlCommand command = new SqlCommand(query3, sqlConnection))
                {                   
                    command.Parameters.AddWithValue("@fio", fio);
                    command.Parameters.AddWithValue("@oldFIO", oldFIO);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@fio", fio);
                command.Parameters.AddWithValue("@photo", photo);
                command.Parameters.AddWithValue("@oldFIO", oldFIO);
                int rowsAffected = command.ExecuteNonQuery();
            }
            query = "UPDATE Messenger SET Sender = @fio, Photo = @photo  WHERE Sender = @oldFIO";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@fio", fio);
                command.Parameters.AddWithValue("@photo", photo);
                command.Parameters.AddWithValue("@oldFIO", oldFIO);
                int rowsAffected = command.ExecuteNonQuery();
            }
            sqlConnection.Close();
            return admin;
        }

        //  картинка
        private void CBphoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = CBphoto.SelectedItem.ToString();
            string imagePath = $"{selectedItem}.jpg";
            string folderPath = @"..\..\Resourses\"; // относительный путь к папке с изображениями
            // Проверяем, что элемент существует
            if (!string.IsNullOrEmpty(selectedItem))
            {
                // Пытаемся найти изображение в указанной папке
                string fullPath = Path.Combine(folderPath, imagePath);
                if (File.Exists(fullPath))
                {
                    // Устанавливаем изображение в качестве фона PictureBox
                    pictureBox1.BackgroundImage = Image.FromFile(fullPath);
                    // Устанавливаем режим масштабирования фона
                    pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    imagePath = $"{selectedItem}.png";
                    fullPath = Path.Combine(folderPath, imagePath);
                    if (File.Exists(fullPath))
                    {
                        pictureBox1.BackgroundImage = Image.FromFile(fullPath);
                        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                    {
                        MessageBox.Show($"Изображение '{selectedItem}' не найдено в указанной папке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }

        }



    }
}
