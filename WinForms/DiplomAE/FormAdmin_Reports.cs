using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace DiplomAE
{
    public partial class FormAdmin
    {
        // Класс FormAdmin_Reports является частью класса FormAdmin и доступен из других частей проекта
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ОТЧЕТЫ
        // сохранения отчета в базу данных при нажатии на кнопку 
        private void FormReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (TypeO.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тип отчета!");
                    return;
                }
                else
                {
                    string reportType = TypeO.SelectedItem.ToString();
                    int adminID = Global.ADMINID; 
                    DateTime dateTime = DataO.Value.Date;
                    string header = TBHeader.Text;
                    string text = TBText.Text;
                    string query = "INSERT INTO Report (ReportType, AdminID, DateTime, Header, Text) VALUES (@ReportType, @AdminID, @DateTime, @Header, @Text)";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@ReportType", reportType);
                        command.Parameters.AddWithValue("@AdminID", adminID);
                        command.Parameters.AddWithValue("@DateTime", dateTime);
                        command.Parameters.AddWithValue("@Header", header);
                        command.Parameters.AddWithValue("@Text", text);
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                        MessageBox.Show("Отчет сформирован.");
                    }
                    LoadReports();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // отображения отчетов в ListView
        private void LoadReports()
        {
            OList.Items.Clear();
            string query = "SELECT ID, Header, ReportType, AdminID, DateTime FROM Report";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader(); // Создаем новый экземпляр SqlDataReader
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Header"].ToString());
                    item.SubItems.Add(reader["ReportType"].ToString());
                    item.SubItems.Add(reader["AdminID"].ToString());
                    item.SubItems.Add(((DateTime)reader["DateTime"]).ToShortDateString());
                    item.Tag = reader["ID"]; // Устанавливаем значение свойства Tag равным идентификатору записи
                    OList.Items.Add(item);
                }
                sqlConnection.Close();
            }
        }
        // Для фильтрации
        private void FilterApply_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли тип отчета
            if (RBType.Checked || RBDate.Checked)
            {
                string filterQuery = "SELECT ID, Header, ReportType, AdminID, DateTime FROM Report WHERE 1=1";
                // Проверяем, какой RadioButton выбран
                if (RBType.Checked && TypeO2.Text != "Тип отчета:")
                {
                    filterQuery += " AND ReportType = @ReportType";
                }
                else if (RBDate.Checked)
                {
                    filterQuery += " AND DateTime = @DateTime";
                }
                using (SqlCommand command = new SqlCommand(filterQuery, sqlConnection))
                {
                    if (RBType.Checked && TypeO2.SelectedItem != null)
                    {
                            command.Parameters.AddWithValue("@ReportType", TypeO2.SelectedItem.ToString());
                    }
                    else if (RBDate.Checked && DataO2.Value.Date != null)
                    {                       
                            command.Parameters.AddWithValue("@DateTime", DataO2.Value.Date);                             
                    }
                    else
                    {
                        MessageBox.Show("Укажите тип отчета для фильтрации!");
                        return;
                    }
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    OList.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Header"].ToString());
                        item.SubItems.Add(reader["ReportType"].ToString());
                        item.SubItems.Add(reader["AdminID"].ToString());
                        item.SubItems.Add(reader["DateTime"].ToString().Split(' ')[0]); // Отображаем только дату
                        item.Tag = reader["ID"]; // Устанавливаем значение свойства Tag равным идентификатору записи
                        OList.Items.Add(item);
                    }
                    sqlConnection.Close();
                }
                MessageBox.Show("Фильтр применен.");
            }
            else
            {
                MessageBox.Show("Выберите значение!");
            }
        }

        // для сброса фильтрации
        private void SbrosFiltr_Click(object sender, EventArgs e)
        {
            // Сброс значений элементов управления
            TypeO2.Text = "Тип отчета";
            DataO2.Value = DateTime.Now;
            // Перезагрузка всех отчетов без фильтрации
            LoadReports();
        }
        //Для удаления отчета
        private void DelReport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить отчет?", "Отмена", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (OList.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = OList.SelectedItems[0];
                    int reportID = Convert.ToInt32(selectedItem.Tag); // Получаем идентификатор записи из свойства Tag
                    // Проверяем значение переменной reportID
                    if (reportID == 0)
                    {
                        MessageBox.Show($"Значение переменной reportID равно нулю.\nИндекс: {selectedItem.Index}\nЗначение свойства Tag: {selectedItem.Tag}");
                        return;
                    }
                    string query = "DELETE FROM Report WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@ID", reportID);
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery(); // Выполняем запрос и получаем количество затронутых строк
                        sqlConnection.Close();
                        if (rowsAffected > 0) // Проверяем, что запрос был выполнен успешно
                        {
                            OList.Items.Remove(selectedItem); // Удаляем выбранный элемент из ListView
                        }
                        else
                        {
                            MessageBox.Show($"Запрос: {command.CommandText}\nПараметр: @ID = {reportID}\nКоличество затронутых строк: {rowsAffected}");
                        }
                    }
                    MessageBox.Show("Отчет удален.");
                }
            }
        }
        //Для просмотра отчета
        private void ShowReport_Click(object sender, EventArgs e)
        {
            if (OList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = OList.SelectedItems[0];
                int reportID = Convert.ToInt32(selectedItem.Tag); // Получаем идентификатор записи из свойства Tag
                string query = "SELECT Header, ReportType, AdminID, DateTime, Text FROM Report WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@ID", reportID);
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        TBHeader.Text = reader["Header"].ToString();
                        TBHeader.ForeColor = Color.Black;
                        TypeO.SelectedItem = reader["ReportType"].ToString();
                        DataO.Value = ((DateTime)reader["DateTime"]).Date;
                        TBText.Text = reader["Text"].ToString();
                        TBText.ForeColor = Color.Black;
                    }
                    sqlConnection.Close();
                }
            }
        }

        // Обработчик событий Enter
        private void textbox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.ForeColor == Color.Gray)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            }
            else if (sender is RichTextBox richTextBox)
            {
                if (richTextBox.ForeColor == Color.Gray)
                {
                    richTextBox.Text = "";
                    richTextBox.ForeColor = Color.Black;
                }
            }
        }
        // Обработчик событий Leave
        private void textbox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "")
                {
                    textBox.ForeColor = Color.Gray;
                    string defaultText = "Заголовок:";
                    textBox.Text = defaultText;
                }
            }
            else if (sender is RichTextBox richTextBox)
            {
                if (richTextBox.Text == "")
                {
                    richTextBox.ForeColor = Color.Gray;
                    string defaultText = "Текст:";
                    richTextBox.Text = defaultText;
                }
            }
        }

    }
}
