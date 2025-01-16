using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WW.Forms.Add_Edit;


namespace WW.Forms.Admin
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            LoadData();

            this.Width = 1150;  // Установить ширину
            this.Height = 541; // Установить высоту

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;

            // Устанавливаем стиль DropDownList для комбобоксов, чтобы запретить редактирование
            comboRole.DropDownStyle = ComboBoxStyle.DropDownList;

            comboRole.DrawMode = DrawMode.OwnerDrawFixed;
            comboRole.DrawItem += ComboBox_DrawItem;

            CustomizeMonthCalendar();
            LoadRoles();
        }
        private void CustomizeMonthCalendar()
        {
            // Убираем кнопку "Сегодня:" и выделение текущей даты
            monthCalendarBirth.ShowToday = false;
            monthCalendarBirth.ShowTodayCircle = false;

            // Ограничения диапазона дат
            monthCalendarBirth.MinDate = new DateTime(1950, 12, 12);
            monthCalendarBirth.MaxDate = new DateTime(2005, 1, 1);

            monthCalendarNaim.MinDate = new DateTime(2015, 12, 12);
            monthCalendarNaim.MaxDate = DateTime.Today;

            // Скрываем календарь по умолчанию
            monthCalendarBirth.Visible = false;

            monthCalendarNaim.Visible = false;
        }
        private void LoadRoles()
        {
            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT role FROM staff ";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboRole.Items.Add(new ComboBoxItem { Text = reader["role"].ToString() });
                    }

                    comboRole.DisplayMember = "Text";
                    comboRole.ValueMember = "Value";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке категорий: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        public void RefreshData()
        {
            LoadData(); // Вызовите метод, который заполняет dataGridView данными из базы данных
        }

        private void LoadData()
        {
            string connectionString = Connect.conStr;
            string query = "SELECT staff_id, role, name, surname, patronymic, passport, date_of_birth, phone, login, password, hire_date FROM staff";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();

                    //Заполняем DataTable данными
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                    dataGridView1.AllowUserToAddRows = false;


                    // Настройка внешнего вида
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dataGridView1.ScrollBars = ScrollBars.Both;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.ReadOnly = true;

                    // Настройка ширины столбцов
                    dataGridView1.Columns["staff_id"].Width = 60;
                    dataGridView1.Columns["role"].Width = 100;
                    dataGridView1.Columns["name"].Width = 100;
                    dataGridView1.Columns["surname"].Width = 100;
                    dataGridView1.Columns["patronymic"].Width = 100;
                    dataGridView1.Columns["passport"].Width = 100;
                    dataGridView1.Columns["date_of_birth"].Width = 100;
                    dataGridView1.Columns["phone"].Width = 100;
                    dataGridView1.Columns["login"].Width = 100;
                    dataGridView1.Columns["password"].Width = 100;
                    dataGridView1.Columns["hire_date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dataGridView1.AllowUserToResizeColumns = false;
                    dataGridView1.AllowUserToResizeRows = false;

                    // Настройка заголовков
                    dataGridView1.Columns["staff_id"].HeaderText = "Номер";
                    dataGridView1.Columns["role"].HeaderText = "Роль";
                    dataGridView1.Columns["name"].HeaderText = "Имя";
                    dataGridView1.Columns["surname"].HeaderText = "Фамилия";
                    dataGridView1.Columns["patronymic"].HeaderText = "Отчество";
                    dataGridView1.Columns["passport"].HeaderText = "Паспорт";
                    dataGridView1.Columns["date_of_birth"].HeaderText = "Дата рождения";
                    dataGridView1.Columns["phone"].HeaderText = "Телефон";
                    dataGridView1.Columns["login"].HeaderText = "Логин";
                    dataGridView1.Columns["password"].HeaderText = "Пароль";
                    dataGridView1.Columns["hire_date"].HeaderText = "Дата устройства на работу";

                    // Скрытие столбца staff_id
                    dataGridView1.Columns["staff_id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button_Exit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void textSearch1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Add1_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(this);
            addUser.ShowDialog();
        }

        string connect = Connect.conStr;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                // Получаем значение staff_id из выбранной строки
                string staffId = dataGridView1.Rows[rowIndex].Cells["staff_id"].Value.ToString();

                string query = @"SELECT staff.staff_id AS 'Номер', staff.name AS 'Имя', staff.surname AS 'Фамилия', 
                                 staff.patronymic AS 'Отчество', staff.phone AS 'Телефон', staff.date_of_birth AS 'Дата рождения', 
                                 staff.hire_date AS 'Дата устройства на работу', staff.passport AS 'Паспорт', 
                                 staff.role AS 'Роль', staff.login AS 'Логин', staff.password AS 'Пароль' 
                                 FROM staff WHERE staff.staff_id = @StaffId";

                using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@StaffId", staffId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textName.Text = reader["Имя"].ToString();
                                textSurname.Text = reader["Фамилия"].ToString();
                                textPartonimyc.Text = reader["Отчество"].ToString();
                                maskedPhone.Text = reader["Телефон"].ToString();
                                maskedBirth.Text = reader["Дата рождения"].ToString();
                                maskedNaim.Text = reader["Дата устройства на работу"].ToString();
                                textPassport.Text = reader["Паспорт"].ToString();
                                comboRole.Text = reader["Роль"].ToString();
                                textLogin.Text = reader["Логин"].ToString();
                                textPassword.Text = reader["Пароль"].ToString();

                                buttonApply.Enabled = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка получения данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_Edit1_Click(object sender, EventArgs e)
        {
            this.Width = 1150;  // Установить ширину
            this.Height = 837; // Установить высоту
        }
        private void textLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!CharCorrectLogin(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
        }
        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!CharCorrectLogin(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
        }
        private bool CharCorrectLogin(char c)
        {

            return (c >= 'a' && c <= 'z') ||
                    (c >= 'A' && c <= 'Z') ||
                    (c >= '0' && c <= '9') ||
                    (c == '-') ||
                    (c == '_');
        }
        private void pictureRandPassword_Click(object sender, EventArgs e)
        {
            textPassword.Text = CreatePassword(15);
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyz_-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            this.Width = 1150;  // Установить ширину
            this.Height = 541; // Установить высоту
            //1150; 837
        }
        public int des1;
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textName.Text) ||
                string.IsNullOrWhiteSpace(textSurname.Text) ||
                string.IsNullOrWhiteSpace(textPartonimyc.Text) ||
                string.IsNullOrWhiteSpace(maskedBirth.Text) ||
                string.IsNullOrWhiteSpace(maskedNaim.Text) ||
                string.IsNullOrWhiteSpace(maskedPhone.Text) ||
                comboRole.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textPassport.Text) ||
                textPassport.Text.Length != 10 || // Точная проверка длины
                !Regex.IsMatch(textPassport.Text, @"^\d{10}$") || // Проверка на 10 цифр
                string.IsNullOrWhiteSpace(textLogin.Text) ||
                string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля. Убедитесь, что паспорт содержит ровно 10 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Выберите пользователя для редактирования.", "Пользователь не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем значения для обновления
            string staffId = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["staff_id"].Value.ToString();

            // Преобразуем даты в формат yyyy-MM-dd
            DateTime birthDate, hireDate;
            string dateOfBirth = "";
            string hireDateStr = "";

            if (DateTime.TryParseExact(maskedBirth.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
            {
                dateOfBirth = birthDate.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Некорректный формат даты рождения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.TryParseExact(maskedNaim.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out hireDate))
            {
                hireDateStr = hireDate.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Некорректный формат даты устройства на работу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Запрос для обновления данных
            string query = @"UPDATE staff SET 
                     name = @Name, 
                     surname = @Surname, 
                     patronymic = @Patronymic, 
                     phone = @Phone, 
                     date_of_birth = @DateOfBirth, 
                     hire_date = @HireDate, 
                     passport = @Passport, 
                     role = @Role, 
                     login = @Login, 
                     password = @Password 
                     WHERE staff_id = @StaffId";

            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Name", textName.Text);
                    cmd.Parameters.AddWithValue("@Surname", textSurname.Text);
                    cmd.Parameters.AddWithValue("@Patronymic", textPartonimyc.Text);
                    cmd.Parameters.AddWithValue("@Phone", maskedPhone.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);  // Передаём дату в формате yyyy-MM-dd
                    cmd.Parameters.AddWithValue("@HireDate", hireDateStr);  // Передаём дату в формате yyyy-MM-dd
                    cmd.Parameters.AddWithValue("@Passport", textPassport.Text);
                    cmd.Parameters.AddWithValue("@Role", comboRole.Text);
                    cmd.Parameters.AddWithValue("@Login", textLogin.Text);
                    cmd.Parameters.AddWithValue("@Password", textPassword.Text);
                    cmd.Parameters.AddWithValue("@StaffId", staffId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно обновлены.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка обновления данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Удаление
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
                    string strCmd = $@"DELETE FROM staff  WHERE staff_id = '{cell0}' ;";
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
            else if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            // Ограничиваем ввод только буквами
            textName.Text = Regex.Replace(textName.Text, @"[^а-яА-Я\s]", "");
            textName.SelectionStart = textName.Text.Length; // Устанавливаем курсор в конец

            if (textName.Text.Length > 0)
            {
                // Сохраняем текущую позицию курсора
                int cursorPosition = textName.SelectionStart;

                // Преобразуем первую букву в заглавную
                textName.Text = char.ToUpper(textName.Text[0]) + textName.Text.Substring(1);

                // Восстанавливаем позицию курсора
                textName.SelectionStart = cursorPosition;
            }
        }

        private void textSurname_TextChanged(object sender, EventArgs e)
        {
            // Ограничиваем ввод только буквами
            textSurname.Text = Regex.Replace(textSurname.Text, @"[^а-яА-Я\s]", "");
            textSurname.SelectionStart = textSurname.Text.Length; // Устанавливаем курсор в конец

            if (textSurname.Text.Length > 0)
            {
                // Сохраняем текущую позицию курсора
                int cursorPosition = textSurname.SelectionStart;

                // Преобразуем первую букву в заглавную
                textSurname.Text = char.ToUpper(textSurname.Text[0]) + textSurname.Text.Substring(1);

                // Восстанавливаем позицию курсора
                textSurname.SelectionStart = cursorPosition;
            }
        }

        private void textPartonimyc_TextChanged(object sender, EventArgs e)
        {
            // Ограничиваем ввод только буквами
            textPartonimyc.Text = Regex.Replace(textPartonimyc.Text, @"[^а-яА-Я\s]", "");
            textPartonimyc.SelectionStart = textPartonimyc.Text.Length; // Устанавливаем курсор в конец


            if (textPartonimyc.Text.Length > 0)
            {
                // Сохраняем текущую позицию курсора
                int cursorPosition = textPartonimyc.SelectionStart;

                // Преобразуем первую букву в заглавную
                textPartonimyc.Text = char.ToUpper(textPartonimyc.Text[0]) + textPartonimyc.Text.Substring(1);

                // Восстанавливаем позицию курсора
                textPartonimyc.SelectionStart = cursorPosition;
            }
        }

        private void pictureCalendar1_Click(object sender, EventArgs e)
        {
            // Показать или скрыть календарь
            monthCalendarBirth.Visible = !monthCalendarBirth.Visible;
        }

        private void pictureCalendar2_Click(object sender, EventArgs e)
        {
            // Показать или скрыть календарь
            monthCalendarNaim.Visible = !monthCalendarNaim.Visible;
        }

        private void maskedBirth_Leave(object sender, EventArgs e)
        {
            // Проверка корректности ввода даты
            if (DateTime.TryParseExact(maskedBirth.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                // Задаём диапазон
                DateTime minDate = new DateTime(1950, 12, 12);
                DateTime maxDate = new DateTime(2005, 1, 1);

                // Проверяем, входит ли дата в диапазон
                if (date >= minDate && date <= maxDate)
                {
                    monthCalendarBirth.SetDate(date); // Устанавливаем дату в календаре
                }
                else
                {
                    // Если дата за пределами диапазона
                    MessageBox.Show($"Введите дату в диапазоне от {minDate:dd.MM.yyyy} до {maxDate:dd.MM.yyyy}",
                                    "Некорректная дата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedBirth.Focus();
                }
            }
            else
            {
                // Если формат даты некорректен
                MessageBox.Show("Введите корректную дату в формате дд.мм.гггг",
                                "Неверный формат даты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedBirth.Focus();
            }
        }

        private void maskedNaim_Leave(object sender, EventArgs e)
        {
            // Проверка корректности ввода даты
            if (DateTime.TryParseExact(maskedNaim.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                // Задаём диапазон
                DateTime minDate = new DateTime(2015, 12, 12);
                DateTime maxDate = DateTime.Today;

                // Проверяем, входит ли дата в диапазон
                if (date >= minDate && date <= maxDate)
                {
                    monthCalendarNaim.SetDate(date); // Устанавливаем дату в календаре
                }
                else
                {
                    // Если дата за пределами диапазона
                    MessageBox.Show($"Введите дату в диапазоне от {minDate:dd.MM.yyyy} до {maxDate:dd.MM.yyyy}",
                                    "Некорректная дата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedNaim.Focus();
                }
            }
            else
            {
                // Если формат даты некорректен
                MessageBox.Show("Введите корректную дату в формате дд.мм.гггг",
                                "Неверный формат даты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedNaim.Focus();
            }
        }

        private void monthCalendarBirth_DateSelected(object sender, DateRangeEventArgs e)
        {
            maskedBirth.Text = monthCalendarBirth.SelectionStart.ToString("dd.MM.yyyy");
            monthCalendarBirth.Visible = false; // Скрыть календарь после выбора даты
        }

        private void monthCalendarNaim_DateSelected(object sender, DateRangeEventArgs e)
        {
            maskedNaim.Text = monthCalendarNaim.SelectionStart.ToString("dd.MM.yyyy");
            monthCalendarNaim.Visible = false; // Скрыть календарь после выбора даты
        }

        private void maskedBirth_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedBirth_TextChanged(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void maskedNaim_TextChanged(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToString("dd.MM.yyyy");
        }





        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
            if (e.KeyChar == ' ') // Проверяем, что вводимый символ — пробел
            {
                e.Handled = true; // Отменяем ввод
            }
        }

        private void textSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
            if (e.KeyChar == ' ') // Проверяем, что вводимый символ — пробел
            {
                e.Handled = true; // Отменяем ввод
            }
        }

        private void textPartonimyc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
            if (e.KeyChar == ' ') // Проверяем, что вводимый символ — пробел
            {
                e.Handled = true; // Отменяем ввод
            }
        }

        private void textPassport_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и управление
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Блокируем ввод
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e){}
    }
}
