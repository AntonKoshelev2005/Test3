
namespace WW.Forms.Add_Edit
{
    partial class AddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.textName = new System.Windows.Forms.TextBox();
            this.textSurname = new System.Windows.Forms.TextBox();
            this.textPartonimyc = new System.Windows.Forms.TextBox();
            this.textPassport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.maskedPhone = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.monthCalendarBirth = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarNaim = new System.Windows.Forms.MonthCalendar();
            this.maskedBirth = new System.Windows.Forms.MaskedTextBox();
            this.pictureCalendar1 = new System.Windows.Forms.PictureBox();
            this.pictureCalendar2 = new System.Windows.Forms.PictureBox();
            this.maskedNaim = new System.Windows.Forms.MaskedTextBox();
            this.pictureRandPassword = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.toolTipRandPassword = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRandPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textName.Location = new System.Drawing.Point(12, 136);
            this.textName.MaxLength = 17;
            this.textName.Multiline = true;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(170, 26);
            this.textName.TabIndex = 0;
            this.textName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textName_KeyPress);
            // 
            // textSurname
            // 
            this.textSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textSurname.Location = new System.Drawing.Point(12, 203);
            this.textSurname.MaxLength = 17;
            this.textSurname.Multiline = true;
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new System.Drawing.Size(170, 26);
            this.textSurname.TabIndex = 1;
            this.textSurname.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSurname_KeyPress);
            // 
            // textPartonimyc
            // 
            this.textPartonimyc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPartonimyc.Location = new System.Drawing.Point(12, 270);
            this.textPartonimyc.MaxLength = 20;
            this.textPartonimyc.Multiline = true;
            this.textPartonimyc.Name = "textPartonimyc";
            this.textPartonimyc.Size = new System.Drawing.Size(170, 26);
            this.textPartonimyc.TabIndex = 2;
            this.textPartonimyc.TextChanged += new System.EventHandler(this.textPartonimyc_TextChanged);
            this.textPartonimyc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPartonimyc_KeyPress);
            // 
            // textPassport
            // 
            this.textPassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPassport.Location = new System.Drawing.Point(290, 203);
            this.textPassport.MaxLength = 10;
            this.textPassport.Multiline = true;
            this.textPassport.Name = "textPassport";
            this.textPassport.Size = new System.Drawing.Size(170, 26);
            this.textPassport.TabIndex = 4;
            this.textPassport.TextChanged += new System.EventHandler(this.textPassport_TextChanged);
            this.textPassport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPassport_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(286, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Роль";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Отчество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(286, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Паспорт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(8, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Дата рожения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "Дата найма";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(286, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "Телефон";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(286, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "Логин";
            // 
            // textLogin
            // 
            this.textLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogin.Location = new System.Drawing.Point(290, 339);
            this.textLogin.MaxLength = 15;
            this.textLogin.Multiline = true;
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(170, 26);
            this.textLogin.TabIndex = 17;
            this.textLogin.TextChanged += new System.EventHandler(this.textLogin_TextChanged);
            this.textLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLogin_KeyPress);
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPassword.Location = new System.Drawing.Point(290, 406);
            this.textPassword.MaxLength = 15;
            this.textPassword.Multiline = true;
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(144, 26);
            this.textPassword.TabIndex = 18;
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
            this.textPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPassword_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(286, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 24);
            this.label10.TabIndex = 19;
            this.label10.Text = "Пароль";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddUser.ForeColor = System.Drawing.Color.White;
            this.buttonAddUser.Location = new System.Drawing.Point(12, 489);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(448, 50);
            this.buttonAddUser.TabIndex = 23;
            this.buttonAddUser.Text = "Добавить";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // comboRole
            // 
            this.comboRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Location = new System.Drawing.Point(290, 270);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(170, 28);
            this.comboRole.TabIndex = 24;
            this.comboRole.SelectedIndexChanged += new System.EventHandler(this.comboRole_SelectedIndexChanged);
            // 
            // maskedPhone
            // 
            this.maskedPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedPhone.Location = new System.Drawing.Point(290, 136);
            this.maskedPhone.Mask = "8 (990)-000-00-00";
            this.maskedPhone.Name = "maskedPhone";
            this.maskedPhone.Size = new System.Drawing.Size(170, 26);
            this.maskedPhone.TabIndex = 26;
            this.maskedPhone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(118, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(342, 31);
            this.label11.TabIndex = 28;
            this.label11.Text = "Добавление сотрудника";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(182, 81);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(109, 397);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // monthCalendarBirth
            // 
            this.monthCalendarBirth.Location = new System.Drawing.Point(181, 202);
            this.monthCalendarBirth.Name = "monthCalendarBirth";
            this.monthCalendarBirth.TabIndex = 30;
            this.monthCalendarBirth.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarBirth_DateChanged);
            this.monthCalendarBirth.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarBirth_DateSelected);
            // 
            // monthCalendarNaim
            // 
            this.monthCalendarNaim.Location = new System.Drawing.Point(181, 269);
            this.monthCalendarNaim.Name = "monthCalendarNaim";
            this.monthCalendarNaim.TabIndex = 31;
            this.monthCalendarNaim.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarNaim_DateSelected);
            // 
            // maskedBirth
            // 
            this.maskedBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedBirth.Location = new System.Drawing.Point(12, 337);
            this.maskedBirth.Mask = "0000/00/00";
            this.maskedBirth.Name = "maskedBirth";
            this.maskedBirth.Size = new System.Drawing.Size(170, 26);
            this.maskedBirth.TabIndex = 33;
            this.maskedBirth.ValidatingType = typeof(System.DateTime);
            this.maskedBirth.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedBirth_MaskInputRejected);
            this.maskedBirth.TextChanged += new System.EventHandler(this.maskedBirth_TextChanged);
            this.maskedBirth.Leave += new System.EventHandler(this.maskedBirth_Leave);
            // 
            // pictureCalendar1
            // 
            this.pictureCalendar1.BackColor = System.Drawing.Color.White;
            this.pictureCalendar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCalendar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCalendar1.Image = ((System.Drawing.Image)(resources.GetObject("pictureCalendar1.Image")));
            this.pictureCalendar1.Location = new System.Drawing.Point(156, 337);
            this.pictureCalendar1.Name = "pictureCalendar1";
            this.pictureCalendar1.Size = new System.Drawing.Size(26, 26);
            this.pictureCalendar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCalendar1.TabIndex = 34;
            this.pictureCalendar1.TabStop = false;
            this.pictureCalendar1.Click += new System.EventHandler(this.pictureCalendar1_Click);
            // 
            // pictureCalendar2
            // 
            this.pictureCalendar2.BackColor = System.Drawing.Color.White;
            this.pictureCalendar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCalendar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCalendar2.Image = ((System.Drawing.Image)(resources.GetObject("pictureCalendar2.Image")));
            this.pictureCalendar2.Location = new System.Drawing.Point(156, 404);
            this.pictureCalendar2.Name = "pictureCalendar2";
            this.pictureCalendar2.Size = new System.Drawing.Size(26, 26);
            this.pictureCalendar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCalendar2.TabIndex = 35;
            this.pictureCalendar2.TabStop = false;
            this.pictureCalendar2.Click += new System.EventHandler(this.pictureCalendar2_Click);
            // 
            // maskedNaim
            // 
            this.maskedNaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedNaim.Location = new System.Drawing.Point(12, 404);
            this.maskedNaim.Mask = "0000/00/00";
            this.maskedNaim.Name = "maskedNaim";
            this.maskedNaim.Size = new System.Drawing.Size(170, 26);
            this.maskedNaim.TabIndex = 36;
            this.maskedNaim.ValidatingType = typeof(System.DateTime);
            this.maskedNaim.TextChanged += new System.EventHandler(this.maskedNaim_TextChanged);
            this.maskedNaim.Leave += new System.EventHandler(this.maskedNaim_Leave);
            // 
            // pictureRandPassword
            // 
            this.pictureRandPassword.BackColor = System.Drawing.Color.White;
            this.pictureRandPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureRandPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureRandPassword.Image = ((System.Drawing.Image)(resources.GetObject("pictureRandPassword.Image")));
            this.pictureRandPassword.Location = new System.Drawing.Point(434, 406);
            this.pictureRandPassword.Name = "pictureRandPassword";
            this.pictureRandPassword.Size = new System.Drawing.Size(26, 26);
            this.pictureRandPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureRandPassword.TabIndex = 37;
            this.pictureRandPassword.TabStop = false;
            this.pictureRandPassword.Click += new System.EventHandler(this.pictureRandPassword_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(428, 438);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 20);
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // toolTipRandPassword
            // 
            this.toolTipRandPassword.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipRandPassword_Popup);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(474, 551);
            this.Controls.Add(this.monthCalendarNaim);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureRandPassword);
            this.Controls.Add(this.monthCalendarBirth);
            this.Controls.Add(this.pictureCalendar1);
            this.Controls.Add(this.pictureCalendar2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.maskedPhone);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPassport);
            this.Controls.Add(this.textPartonimyc);
            this.Controls.Add(this.textSurname);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.maskedNaim);
            this.Controls.Add(this.maskedBirth);
            this.Controls.Add(this.pictureBox2);
            this.Name = "AddUser";
            this.Text = "Add User";
            this.Load += new System.EventHandler(this.AddUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRandPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textSurname;
        private System.Windows.Forms.TextBox textPartonimyc;
        private System.Windows.Forms.TextBox textPassport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.MaskedTextBox maskedPhone;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MonthCalendar monthCalendarBirth;
        private System.Windows.Forms.MonthCalendar monthCalendarNaim;
        private System.Windows.Forms.MaskedTextBox maskedBirth;
        private System.Windows.Forms.PictureBox pictureCalendar1;
        private System.Windows.Forms.PictureBox pictureCalendar2;
        private System.Windows.Forms.MaskedTextBox maskedNaim;
        private System.Windows.Forms.PictureBox pictureRandPassword;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolTip toolTipRandPassword;
    }
}