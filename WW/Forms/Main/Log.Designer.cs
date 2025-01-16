
namespace WW
{
    partial class Log
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.labelLog = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.checkBox_Login = new System.Windows.Forms.CheckBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLog.Location = new System.Drawing.Point(12, 32);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(94, 31);
            this.labelLog.TabIndex = 0;
            this.labelLog.Text = "Войти";
            this.labelLog.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(12, 85);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(69, 24);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин:";
            // 
            // checkBox_Login
            // 
            this.checkBox_Login.AutoSize = true;
            this.checkBox_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_Login.Location = new System.Drawing.Point(18, 214);
            this.checkBox_Login.Name = "checkBox_Login";
            this.checkBox_Login.Size = new System.Drawing.Size(75, 17);
            this.checkBox_Login.TabIndex = 2;
            this.checkBox_Login.Text = "Показать";
            this.checkBox_Login.UseVisualStyleBackColor = true;
            this.checkBox_Login.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textLogin
            // 
            this.textLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogin.ForeColor = System.Drawing.Color.Black;
            this.textLogin.Location = new System.Drawing.Point(16, 112);
            this.textLogin.MaxLength = 15;
            this.textLogin.Multiline = true;
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(240, 28);
            this.textLogin.TabIndex = 6;
            this.textLogin.Text = "admin";
            this.textLogin.Enter += new System.EventHandler(this.textLogin_Enter);
            this.textLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLogin_KeyPress);
            this.textLogin.Leave += new System.EventHandler(this.textLogin_Leave);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(14, 153);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(81, 24);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Пароль:";
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPassword.ForeColor = System.Drawing.Color.Black;
            this.textPassword.Location = new System.Drawing.Point(16, 180);
            this.textPassword.MaxLength = 15;
            this.textPassword.Multiline = true;
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '●';
            this.textPassword.Size = new System.Drawing.Size(240, 28);
            this.textPassword.TabIndex = 8;
            this.textPassword.Text = "admin";
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
            this.textPassword.Enter += new System.EventHandler(this.textPassword_Enter);
            this.textPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPassword_KeyPress);
            this.textPassword.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(186, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(299, 12);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(240, 128);
            this.pictureBoxCaptcha.TabIndex = 10;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(16, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 50);
            this.button1.TabIndex = 15;
            this.button1.Text = "Войти";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 316);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxCaptcha);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.checkBox_Login);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Log";
            this.Text = "Log up";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Log_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Log_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.CheckBox checkBox_Login;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private System.Windows.Forms.Button button1;
    }
}

