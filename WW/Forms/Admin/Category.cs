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
using WW.Forms.Admin;
using WW.Forms.Add_Edit;

namespace WW.Forms.Admin
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();

            LoadData();

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Category_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        public void RefreshData()
        {
            LoadData(); // Вызовите метод, который заполняет dataGridView данными из базы данных
        }
        private void LoadData()
        {
            // Используем строку подключения из класса Connect
            string connectionString = Connect.conStr;

            // SQL-запрос для выборки данных
            string query = "SELECT categories_id, category_name FROM categories";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    // Заполняем DataTable данными
                    adapter.Fill(table);

                    // Привязываем DataTable к существующему dataGridView1
                    dataGridView1.DataSource = table;

                    // Отключаем возможность добавления строк
                    dataGridView1.AllowUserToAddRows = false;

                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;      // Цвет фона заголовков
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;     // Цвет текста заголовков
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Шрифт заголовков

                    // Устанавливаем ширину для каждого столбца после привязки данных
                    dataGridView1.Columns["categories_id"].Width = 60;
                    dataGridView1.Columns["category_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    dataGridView1.AllowUserToResizeColumns = false;
                    dataGridView1.AllowUserToResizeRows = false;

                    // Скрываем заголовок строк (если не нужен) и запрещаем изменение размеров таблицы
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dataGridView1.ScrollBars = ScrollBars.Both;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.ReadOnly = true;


                    // Задаем пользовательские заголовки
                    dataGridView1.Columns["categories_id"].HeaderText = "Номер";
                    dataGridView1.Columns["category_name"].HeaderText = "Категория";
                    dataGridView1.Columns["categories_id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_Exit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button_Add3_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory(this);
            addCategory.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){}


        //Удаление данных из бд
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
                    string strCmd = $@"DELETE FROM categories  WHERE categories_id = '{cell0}' ;";
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
                catch
                {
                    MessageBox.Show("Категория не может быть удалена, так как она используется в других таблицах.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}
    }
}
