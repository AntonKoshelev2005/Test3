using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Text;
using System.Globalization;
using WW.Forms.Admin;

namespace WW.Forms.Add_Edit
{
    public partial class AddUser : Form
    {
        private Staff parentForm;
        public AddUser(Staff form)
        {
            InitializeComponent();
            parentForm = form;

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;

            // Устанавливаем стиль DropDownList для комбобоксов, чтобы запретить редактирование
            comboRole.DropDownStyle = ComboBoxStyle.DropDownList;

            comboRole.DrawMode = DrawMode.OwnerDrawFixed;
            comboRole.DrawItem += ComboBox_DrawItem;
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

        private void AddUser_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            toolTipRandPassword.SetToolTip(pictureRandPassword, "Нажмите, чтобы сгенерировать пароль");

            LoadRoles();
            CustomizeMonthCalendar();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e){}

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void textBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Отменяем ввод "Enter"
            }
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

        private bool CharCorrectLogin(char c)
        {

            return (c >= 'a' && c <= 'z') ||
                    (c >= 'A' && c <= 'Z') ||
                    (c >= '0' && c <= '9') ||
                    (c == '-') ||
                    (c == '_');
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


        private void monthCalendarBirth_DateSelected(object sender, DateRangeEventArgs e)
        {
            maskedBirth.Text = monthCalendarBirth.SelectionStart.ToString("yyyy.MM.dd");
            monthCalendarBirth.Visible = false; // Скрыть календарь после выбора даты
        }
        private void monthCalendarNaim_DateSelected(object sender, DateRangeEventArgs e)
        {
            maskedNaim.Text = monthCalendarNaim.SelectionStart.ToString("yyyy.MM.dd");
            monthCalendarNaim.Visible = false; // Скрыть календарь после выбора даты
        }


        private void maskedBirth_TextChanged(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToString("yyyy.MM.dd");
        }
        private void maskedNaim_TextChanged(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToString("yyyy.MM.dd");
        }


        private void maskedBirth_Leave(object sender, EventArgs e)
        {
            // Проверка корректности ввода даты
            if (DateTime.TryParseExact(maskedBirth.Text, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
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
                    MessageBox.Show($"Введите дату в диапазоне от {minDate:yyyy.MM.dd} до {maxDate:yyyy.MM.dd}",
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
            if (DateTime.TryParseExact(maskedNaim.Text, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
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
                    MessageBox.Show($"Введите дату в диапазоне от {minDate:yyyy.MM.dd} до {maxDate:yyyy.MM.dd}",
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

        private void buttonAddUser_Click(object sender, EventArgs e)
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
                MessageBox.Show("Пожалуйста, заполните все поля. Убедитесь, что паспорт содержит ровно 10 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = textName.Text;
            string surname = textSurname.Text;
            string partonimyc = textPartonimyc.Text;
            string birth = maskedBirth.Text;
            string naim = maskedNaim.Text;
            string phone = maskedPhone.Text;
            string passport = textPassport.Text;

            string role = comboRole.Text;
            string login = textLogin.Text;
            string password = textPassword.Text;



            using (MySqlConnection connection = new MySqlConnection(Connect.conStr))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO staff (name, surname, patronymic, date_of_birth, hire_date, phone, passport, role, login, password) VALUES (@name, @surname, @partonimyc, @birth, @naim, @phone, @passport, @role, @login, @password)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@partonimyc", partonimyc);
                    command.Parameters.AddWithValue("@birth", birth);
                    command.Parameters.AddWithValue("@naim", naim);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@passport", passport);
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Сотрудник успешно добавлен.");

                        // Обновляем данные в форме просмотра товаров
                        parentForm.RefreshData();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textPassport_TextChanged(object sender, EventArgs e)
        {}

        private void textLogin_TextChanged(object sender, EventArgs e) {}
        private void textPassword_TextChanged(object sender, EventArgs e) {}
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void monthCalendarBirth_DateChanged(object sender, DateRangeEventArgs e) { }
        private void maskedBirth_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e){}

        private void toolTipRandPassword_Popup(object sender, PopupEventArgs e)
        {
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
