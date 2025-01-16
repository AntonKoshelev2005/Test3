using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;

namespace WW.Forms.Add
{
    public partial class AddProduct : Form
    {
        private CheckProduct parentForm;

        public AddProduct(CheckProduct form)
        {
            InitializeComponent();
            parentForm = form;

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;

            // Заполняем комбобоксы данными
            LoadCategories();
            LoadManufacturers();

            // Устанавливаем стиль DropDownList для комбобоксов, чтобы запретить редактирование
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboManufacturer.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxCategory.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxCategory.DrawItem += ComboBox_DrawItem;
            comboManufacturer.DrawMode = DrawMode.OwnerDrawFixed;
            comboManufacturer.DrawItem += ComboBox_DrawItem;
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Рисуем фон белым цветом
            e.DrawBackground();
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);

            // Рисуем текст
            if (e.Index >= 0)
            {
                string text = comboBox.Items[e.Index].ToString();
                e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds);
            }
        }

        private void textNameProduct_TextChanged(object sender, EventArgs e)
        {
            // Ограничиваем ввод только буквами
            textNameProduct.Text = Regex.Replace(textNameProduct.Text, @"[^а-яА-Яa-zA-Z\s]", "");
            textNameProduct.SelectionStart = textNameProduct.Text.Length; // Устанавливаем курсор в конец
        }

        private void textPrice_TextChanged(object sender, EventArgs e) { }

        private void textStock_TextChanged(object sender, EventArgs e) { }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboManufacturer_SelectedIndexChanged(object sender, EventArgs e) { }




        private void LoadCategories()
        {
            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT categories_id, category_name FROM categories";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBoxCategory.Items.Add(new ComboBoxItem { Text = reader["category_name"].ToString(), Value = Convert.ToInt32(reader["categories_id"]) });
                    }

                    comboBoxCategory.DisplayMember = "Text";
                    comboBoxCategory.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке категорий: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadManufacturers()
        {
            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT manufacturers_id, manufacturer_name FROM manufacturers";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboManufacturer.Items.Add(new ComboBoxItem { Text = reader["manufacturer_name"].ToString(), Value = Convert.ToInt32(reader["manufacturers_id"]) });
                    }

                    comboManufacturer.DisplayMember = "Text";
                    comboManufacturer.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке производителей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNameProduct.Text) ||
                comboBoxCategory.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textPrice.Text) ||
                string.IsNullOrWhiteSpace(textStock.Text) ||
                comboManufacturer.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string productName = textNameProduct.Text;
            int categoryId = ((ComboBoxItem)comboBoxCategory.SelectedItem).Value;
            decimal price;
            int stock;
            int manufacturerId = ((ComboBoxItem)comboManufacturer.SelectedItem).Value;

            if (!decimal.TryParse(textPrice.Text, out price) || !int.TryParse(textStock.Text, out stock))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для цены и количества.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO products (product_name, category_id, price, stock, manufacturer_id) VALUES (@name, @category, @price, @stock, @manufacturer)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", productName);
                    command.Parameters.AddWithValue("@category", categoryId);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@manufacturer", manufacturerId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Продукт успешно добавлен.");

                        // Обновляем данные в форме просмотра товаров
                        parentForm.RefreshData();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении продукта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на ввод только цифр и одной точки для числа с плавающей запятой
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Разрешаем только одну точку для числа с плавающей запятой
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
        }

        private void textStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры для количества
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
        }

        private void textNameProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
            if (textNameProduct.Text.Length > 0)
            {
                // Сохраняем текущую позицию курсора
                int cursorPosition = textNameProduct.SelectionStart;

                // Преобразуем первую букву в заглавную
                textNameProduct.Text = char.ToUpper(textNameProduct.Text[0]) + textNameProduct.Text.Substring(1);

                // Восстанавливаем позицию курсора
                textNameProduct.SelectionStart = cursorPosition;
            }
        }

        private void comboManufacturer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
        }

        private void comboBoxCategory_DrawItem(object sender, DrawItemEventArgs e)
        {

        }
    }
}