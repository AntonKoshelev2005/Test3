using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using WW.Forms.Admin;

namespace WW.Forms.Add_Edit
{
    public partial class AddManufacturer : Form
    {
        private Manufacturers parentForm;
        public AddManufacturer(Manufacturers form)
        {
            InitializeComponent();
            parentForm = form;

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddManufacturer_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void textManufacturer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
            if (textManufacturer.Text.Length > 0)
            {
                // Сохраняем текущую позицию курсора
                int cursorPosition = textManufacturer.SelectionStart;

                // Преобразуем первую букву в заглавную
                textManufacturer.Text = char.ToUpper(textManufacturer.Text[0]) + textManufacturer.Text.Substring(1);

                // Восстанавливаем позицию курсора
                textManufacturer.SelectionStart = cursorPosition;
            }
        }

        private void textManufacturer_TextChanged(object sender, EventArgs e)
        {
            // Ограничиваем ввод только буквами
            textManufacturer.Text = Regex.Replace(textManufacturer.Text, @"[^а-яА-Яa-zA-Z\s]", "");
            textManufacturer.SelectionStart = textManufacturer.Text.Length; // Устанавливаем курсор в конец
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textManufacturer.Text) == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string category = textManufacturer.Text;

            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO manufacturers (manufacturer_name) VALUES (@manufacturer)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@@manufacturer", category);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Категория успешно добавлена.");

                        // Обновляем данные в форме просмотра товаров
                        parentForm.RefreshData();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении категории.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
