using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using WW.Forms.Admin;

namespace WW.Forms.Add_Edit
{
    public partial class AddCategory : Form
    {
        private Category parentForm;
        public AddCategory(Category form)
        {
            InitializeComponent();
            parentForm = form;

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void textCategory_TextChanged(object sender, EventArgs e)
        {
            // Ограничиваем ввод только буквами
            textCategory.Text = Regex.Replace(textCategory.Text, @"[^а-яА-Я\s]", "");
            textCategory.SelectionStart = textCategory.Text.Length; // Устанавливаем курсор в конец
        }

        private void textCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
            if (textCategory.Text.Length > 0)
            {
                // Сохраняем текущую позицию курсора
                int cursorPosition = textCategory.SelectionStart;

                // Преобразуем первую букву в заглавную
                textCategory.Text = char.ToUpper(textCategory.Text[0]) + textCategory.Text.Substring(1);

                // Восстанавливаем позицию курсора
                textCategory.SelectionStart = cursorPosition;
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textCategory.Text) == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string category = textCategory.Text;

            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO categories (category_name) VALUES (@category)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@@category", category);

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
