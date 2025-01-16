using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WW.Forms.Add;
using System.Text.RegularExpressions;

namespace WW
{
    public partial class CheckProduct : Form
    {
        public CheckProduct()
        {
            InitializeComponent();

            this.Width = 818;  // Установить ширину
            this.Height = 541; // Установить высоту

            

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;


            // Устанавливаем стиль DropDownList для комбобоксов, чтобы запретить редактирование
            comboCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboManufacturer.DropDownStyle = ComboBoxStyle.DropDownList;


            comboCategoryFilter.DrawMode = DrawMode.OwnerDrawFixed;
            comboCategoryFilter.DrawItem += ComboBox_DrawItem;
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

        DataView dv;
        string search = "";

        public void RefreshData()
        {
            LoadData(); // Вызовите метод, который заполняет dataGridView данными из базы данных
        }
        string connect = Connect.conStr;
        private void LoadData()
        {

            // Используем строку подключения из класса Connect
            string connectionString = Connect.conStr;

            // SQL-запрос для выборки данных
            string query = $"SELECT products.product_id AS 'Номер' , products.product_name AS 'Товар', categories.category_name AS 'Категория',"+
                           $"manufacturers.manufacturer_name AS 'Производитель', products.price AS 'Цена',  products.stock AS 'Количество' FROM "+
                           $"products INNER JOIN categories ON products.category_id = categories.categories_id INNER JOIN manufacturers ON products.manufacturer_id"+
                           $"= manufacturers.manufacturers_id; ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    // Заполняем DataTable данными
                    adapter.Fill(table);

                    dv = new DataView(table); // DataView создается из таблицы
                    dataGridView1.DataSource = dv; // DataGridView привязывается к DataView

                    // Привязываем DataTable к существующему dataGridView1
                    dataGridView1.DataSource = table;
                    dv = new DataView(table);
                    // Отключаем возможность добавления строк
                    dataGridView1.AllowUserToAddRows = false;

                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;      // Цвет фона заголовков
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;     // Цвет текста заголовков
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Шрифт заголовков


                    dataGridView1.AllowUserToResizeColumns = false;
                    dataGridView1.AllowUserToResizeRows = false;

                    // Скрываем заголовок строк (если не нужен) и запрещаем изменение размеров таблицы
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dataGridView1.ScrollBars = ScrollBars.Both;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.ReadOnly = true;


                    // Задаем пользовательские заголовки
                    dataGridView1.Columns["Номер"].HeaderText = "Номер товара";
                    dataGridView1.Columns["Категория"].HeaderText = "Категория";
                    dataGridView1.Columns["Товар"].HeaderText = "Товар";
                    dataGridView1.Columns["Цена"].HeaderText = "Цена";
                    dataGridView1.Columns["Количество"].HeaderText = "Количество";
                    dataGridView1.Columns["Производитель"].HeaderText = "Производитель";
                    dataGridView1.Columns["Номер"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable Rooms3 = new DataTable();
                using (MySqlConnection coon = new MySqlConnection(connect))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = coon;
                    cmd.CommandText = "select category_name from `categories`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(Rooms3);
                }
                for (int i = 0; i < Rooms3.Rows.Count; i++)
                {
                    comboBoxCategory.Items.Add(Rooms3.Rows[i]["category_name"]);
                    comboCategoryFilter.Items.Add(Rooms3.Rows[i]["category_name"]);
                }

                DataTable Rooms4 = new DataTable();
                using (MySqlConnection coon = new MySqlConnection(connect))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = coon;
                    cmd.CommandText = "select manufacturer_name from `manufacturers`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(Rooms4);
                }
                for (int i = 0; i < Rooms4.Rows.Count; i++)
                {
                    comboManufacturer.Items.Add(Rooms4.Rows[i]["manufacturer_name"]);
                }
            }
        }

        private void CheckProduct_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            LoadData();
        }


        string poisk = "";
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (comboCategoryFilter.Text == null || comboCategoryFilter.Text == "")
            {
                poisk = textSearch.Text;
                SearchBox();
            }
            else
            {
                poisk = textSearch.Text;
                Filtration();
            }
        }
        private void SearchBox()
        {
            string searchText = textSearch.Text.Trim(); // Получаем текст из поля поиска

            // Проверяем, есть ли что искать
            if (string.IsNullOrWhiteSpace(searchText))
            {
                viewTable(); // Если поле пустое, отображаем всю таблицу
                return;
            }

            using (MySqlConnection con = new MySqlConnection(Connect.conStr))
            {
                con.Open();

                // SQL-запрос для поиска
                string query = @"
            SELECT products.product_id AS 'Номер',
                   products.product_name AS 'Товар',
                   categories.category_name AS 'Категория',
                   manufacturers.manufacturer_name AS 'Производитель',
                   products.price AS 'Цена',
                   products.stock AS 'Количество'
            FROM products
            INNER JOIN categories ON products.category_id = categories.categories_id
            INNER JOIN manufacturers ON products.manufacturer_id = manufacturers.manufacturers_id
            WHERE products.product_name LIKE @SearchText;";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    // Добавляем параметр для защиты от SQL-инъекций
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    // Выполняем запрос и наполняем DataGridView
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt; // Используем DataSource
                }
            }
        }


        private void textSearch2_Enter(object sender, EventArgs e){}

        private void textSearch2_Leave(object sender, EventArgs e){}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Количество")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int stock))
                {
                    // Если цена меньше 5000, устанавливаем красный фон
                    if (stock < 1)
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        

        private void button_Add2_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(this);
            addProduct.ShowDialog();
        }

        private void button_Exit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Edit2_Click(object sender, EventArgs e)
        {
            this.Width = 1167;  // Установить ширину
            this.Height = 541; // Установить высоту
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e){}
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e){}
        private void textSearch2_KeyPress(object sender, KeyPressEventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                string Names = dataGridView1.Rows[rowIndex].Cells["Номер"].Value.ToString();
                string sqlQuery = "SELECT products.product_id AS 'Номер' , products.product_name AS 'Товар', categories.category_name AS 'Категория',"+
                    $"manufacturers.manufacturer_name AS 'Производитель', products.price AS 'Цена',  products.stock AS 'Количество' FROM  products "+
                    $"INNER JOIN categories ON products.category_id = categories.categories_id INNER JOIN manufacturers ON products.manufacturer_id ="+
                    $"manufacturers.manufacturers_id WHERE products.product_id='" + Names + "';";

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connect;
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();

                textNameProduct.Text = rdr["Товар"].ToString();
                comboBoxCategory.Text = rdr["Категория"].ToString();
                comboManufacturer.Text = rdr["Производитель"].ToString();
                textStock.Text = rdr["Количество"].ToString();
                textPrice.Text = rdr["Цена"].ToString();

                buttonApply.Enabled = true;
            }
        }
        
        public int des1;
        public int des2;
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (textNameProduct.Text == "")
            {
                MessageBox.Show("Выберите товар для редактирования.", "Товар не выбран", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                string Names = dataGridView1.Rows[rowIndex].Cells["Номер"].Value.ToString();

                string productName = textNameProduct.Text;
                string categoryId = comboBoxCategory.Text;
                int stock = Convert.ToInt32(textStock.Text);
                decimal price = Convert.ToInt32(textPrice.Text);
                string manufacturerId = comboManufacturer.Text;
                //

                DataTable Rooms = new DataTable();
                using (MySqlConnection coon = new MySqlConnection(connect))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = coon;
                    cmd.CommandText = $@"SELECT categories_id FROM categories  where category_name = '{categoryId}'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(Rooms);
                }
                for (int i = 0; i < Rooms.Rows.Count; i++)
                {
                    des1 = Convert.ToInt32(Rooms.Rows[i]["categories_id"]);
                }
                DataTable Rooms2 = new DataTable();
                using (MySqlConnection coon = new MySqlConnection(connect))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = coon;
                    cmd.CommandText = $@"select manufacturers_id from manufacturers where manufacturer_name = '{manufacturerId}'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(Rooms2);
                }
                for (int i = 0; i < Rooms2.Rows.Count; i++)
                {
                    des2 = Convert.ToInt32(Rooms2.Rows[i]["manufacturers_id"]);
                }
                

                string sqlQuery = $@"UPDATE products SET product_name = '{productName}', category_id = {des1}, manufacturer_id = {des2}, " +
                            $"price = {price}, stock = {stock} WHERE products.product_id = {Names}";
                using (MySqlConnection con = new MySqlConnection())
                {
                    con.ConnectionString = connect;
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
                    int res = cmd.ExecuteNonQuery();

                    if (res == 1)
                    {
                        LoadData();
                        MessageBox.Show("Данные обновлены");

                    }
                    else
                    {
                        MessageBox.Show("Данные не обновлены");
                    }
                    textNameProduct.Text = null;
                    comboBoxCategory.Text = null;
                    textStock.Text = null;
                    textPrice.Text = null;
                    comboManufacturer.Text = null;
                }

                LoadData();
            }
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            this.Width = 818;  // Установить ширину
            this.Height = 541; // Установить высоту
        }
        DataGridView dgv;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                try
                {
                    dgv = (DataGridView)sender;
                    int rowIndex = e.RowIndex;
                    dgv.Rows[rowIndex].Selected = true;

                    string cell0 = dgv.Rows[rowIndex].Cells[0].Value.ToString(); // Получаем staff_id выбранной строки
                    string strCmd = $@"DELETE FROM products  WHERE product_id = '{cell0}' ;";
                    string strCon = Connect.conStr;
                    using (MySqlConnection con = new MySqlConnection())
                    {
                        try
                        {

                            con.ConnectionString = strCon;

                            con.Open();


                            MySqlCommand cmd = new MySqlCommand(strCmd, con);

                            DialogResult dr = MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.Yes)
                            {
                                int res = cmd.ExecuteNonQuery();
                                MessageBox.Show("Удалено " + res.ToString(), "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                LoadData();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else if (e.Button == MouseButtons.Left){}
        }
        void Filtration()
        {
            string categoryFilter = comboCategoryFilter.SelectedItem?.ToString(); // Фильтр категории
            string searchText = textSearch.Text.Trim(); // Текст поиска

            // Формируем SQL-запрос
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT 
        products.product_id AS 'Номер', 
        products.product_name AS 'Товар', 
        categories.category_name AS 'Категория', 
        manufacturers.manufacturer_name AS 'Производитель', 
        products.price AS 'Цена', 
        products.stock AS 'Количество' 
        FROM products
        INNER JOIN categories ON products.category_id = categories.categories_id
        INNER JOIN manufacturers ON products.manufacturer_id = manufacturers.manufacturers_id
        WHERE 1=1 "); // Базовое условие для динамического добавления фильтров

            // Добавляем условия фильтрации
            if (!string.IsNullOrWhiteSpace(categoryFilter))
            {
                query.Append("AND categories.category_name = @Category ");
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query.Append("AND products.product_name LIKE @SearchText ");
            }

            // Создаем соединение и выполняем запрос
            using (MySqlConnection con = new MySqlConnection(Connect.conStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query.ToString(), con))
                {
                    // Добавляем параметры
                    if (!string.IsNullOrWhiteSpace(categoryFilter))
                    {
                        cmd.Parameters.AddWithValue("@Category", categoryFilter);
                    }

                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    }

                    // Выполняем запрос
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Заполняем DataGridView новыми данными
                    dataGridView1.DataSource = dt; // Используем DataSource
                }
            }
        }
        void ApplyFilterAndSort()
        {
            string sortOrder = radioButtonIncreasing.Checked ? "ASC" : "DESC";
            string categoryFilter = comboCategoryFilter.SelectedItem?.ToString();
            string productNameFilter = textNameProduct.Text;

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT products.product_id AS 'Номер',
                          products.product_name AS 'Товар',
                          categories.category_name AS 'Категория',
                          manufacturers.manufacturer_name AS 'Производитель',
                          products.price AS 'Цена',
                          products.stock AS 'Количество'
                   FROM products
                   INNER JOIN categories ON products.category_id = categories.categories_id
                   INNER JOIN manufacturers ON products.manufacturer_id = manufacturers.manufacturers_id
                   WHERE 1=1 ");

            if (!string.IsNullOrWhiteSpace(categoryFilter))
                query.Append("AND categories.category_name = @Category ");
            if (!string.IsNullOrWhiteSpace(productNameFilter))
                query.Append("AND products.product_name LIKE @ProductName ");

            query.Append($"ORDER BY products.price {sortOrder}");

            using (MySqlConnection con = new MySqlConnection(Connect.conStr))
            using (MySqlCommand cmd = new MySqlCommand(query.ToString(), con))
            {
                if (!string.IsNullOrWhiteSpace(categoryFilter))
                    cmd.Parameters.AddWithValue("@Category", categoryFilter);
                if (!string.IsNullOrWhiteSpace(productNameFilter))
                    cmd.Parameters.AddWithValue("@ProductName", "%" + productNameFilter + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt; // Используем DataSource
            }
        }
        // ДОДЕЛАТЬ
        string sort = "ASC";
        private void radioButtonDecreasing_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.Text == null || comboBoxCategory.Text == "")
            {
                radioButtonIncreasing.Checked = false;
                sort = "ASC";
                ApplyFilterAndSort();
            }
            else
            {
                radioButtonIncreasing.Checked = false;
                sort = "ASC";
                Filtration();
            }
        }

        private void radioButtonIncreasing_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.Text == null || comboBoxCategory.Text == "")
            {
                radioButtonDecreasing.Checked = false;
                sort = "DESC";
                ApplyFilterAndSort();
            }
            else
            {
                radioButtonDecreasing.Checked = false;
                sort = "DESC";
                Filtration();
            }
        }

        private void textSearch2_MouseClick(object sender, MouseEventArgs e)
        {
            textSearch.Text = "";
        }

        private void textNameProduct_TextChanged(object sender, EventArgs e)
        {
            // Ограничиваем ввод только буквами
            textNameProduct.Text = Regex.Replace(textNameProduct.Text, @"[^а-яА-Яa-zA-Z\s]", "");
            textNameProduct.SelectionStart = textNameProduct.Text.Length; // Устанавливаем курсор в конец
        }

        private void textStock_TextChanged(object sender, EventArgs e){}

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

        private void pictureClear_Click(object sender, EventArgs e)
        {
            comboCategoryFilter.Text = null;
            radioButtonDecreasing.Checked = false;
            radioButtonIncreasing.Checked = false;
            textSearch.Text = "";
            viewTable();
        }
        private void viewTable()
        {
            using (MySqlConnection con = new MySqlConnection(Connect.conStr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(
                    @"SELECT products.product_id AS 'Номер',
                     products.product_name AS 'Товар',
                     categories.category_name AS 'Категория',
                     manufacturers.manufacturer_name AS 'Производитель',
                     products.price AS 'Цена',
                     products.stock AS 'Количество'
              FROM products
              INNER JOIN categories ON products.category_id = categories.categories_id
              INNER JOIN manufacturers ON products.manufacturer_id = manufacturers.manufacturers_id;",
                    con
                );
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt; // Связываем напрямую с DataSource
            }
        }

        private void radioButtonIncreasing_CheckedChanged_1(object sender, EventArgs e)
        {
            if (comboBoxCategory.Text == null || comboBoxCategory.Text == "")
            {
                radioButtonDecreasing.Checked = false;
                sort = "DESC";
                ApplyFilterAndSort();
            }
            else
            {
                radioButtonDecreasing.Checked = false;
                sort = "DESC";
                Filtration();
            }
        }

        private void comboCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtration();
        }
    }
}
