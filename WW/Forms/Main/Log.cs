using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using WW.Forms.Meneger;

namespace WW
{
    public partial class Log : Form
    {
        string conString = Connect.conStr;
        private string captchaText;

        public Log()
        {
            InitializeComponent();

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        Random random = new Random();
        private void GenerateCaptcha()
        {
            // Генерация случайного текста для капчи
            Random rand = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            captchaText = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                captchaText += characters[rand.Next(characters.Length)];
            }

            Bitmap bmp = new Bitmap(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; graphics.Clear(Color.White);
            Font font = new Font("Arial", 40, FontStyle.Strikeout);
            for(int i = 0; i < 4; i++)
            {
                PointF point = new PointF(i * 20, 0);
                graphics.TranslateTransform(100, 50);
                graphics.RotateTransform(random.Next(-10, 10));
                graphics.DrawString(captchaText[i].ToString(), font, Brushes.SteelBlue, point);
                graphics.ResetTransform();
            }

            // Отображаем картинку
            pictureBoxCaptcha.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            //288; 355
            this.Width = 579;
            this.Height = 355;

            // Инициализация поля пароля: скрываем текст пароля точками по умолчанию
            textPassword.PasswordChar = '●';

            GenerateCaptcha();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Если флажок установлен, показываем пароль
            if (checkBox_Login.Checked)
            {
                textPassword.PasswordChar = default;
            }
            // Если флажок снят, скрываем пароль точками
            else
            {
                textPassword.PasswordChar = '●';
            }
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (textPassword.Text == "Введите пароль")
            {
                textPassword.Text = "";
                textPassword.ForeColor = Color.Black;
                textPassword.PasswordChar = '●'; // Включаем маскировку
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textPassword.Text))
            {
                textPassword.Text = "Введите пароль";
                textPassword.ForeColor = Color.Gray;
                textPassword.PasswordChar = '\0'; // Отключаем маскировку
            }
        }
   
        public static string GetHashPass(string password)
        {
            byte[] bytesPass = Encoding.UTF8.GetBytes(password);

            SHA256Managed hashstring = new SHA256Managed();

            byte[] hash = hashstring.ComputeHash(bytesPass);

            string hashPasswd = string.Empty;

            foreach (byte x in hash)
            {
                hashPasswd += String.Format("{0:x2}", x);
            }

            hashstring.Dispose();

            return hashPasswd;
        }


        private void Log_Leave(object sender, EventArgs e)
        {

        }

        
        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка логина и пароля
            if (textLogin.Text == "user" && textPassword.Text == "user")
            {
                MessageBox.Show("Вы успешно авторизовались", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Переход на форму Admin
                Admin admin = new Admin();
                this.Visible = false;
                admin.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Text = "";
            }
        }

        private void textLogin_Enter(object sender, EventArgs e)
        {
            if (textLogin.Text == "Введите логин")
            {
                textLogin.Text = "";
                textLogin.ForeColor = Color.Black;
            }
        }

        private void textLogin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textLogin.Text))
            {
                textLogin.Text = "Введите логин";
                textLogin.ForeColor = Color.Gray;
            }
        }
    }
}
