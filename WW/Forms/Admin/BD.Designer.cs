
namespace WW.Forms.Admin
{
    partial class BD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BD));
            this.comboBD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.buttonBackUp = new System.Windows.Forms.Button();
            this.buttonBackUpFull = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBD
            // 
            this.comboBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBD.FormattingEnabled = true;
            this.comboBD.Location = new System.Drawing.Point(12, 88);
            this.comboBD.Name = "comboBD";
            this.comboBD.Size = new System.Drawing.Size(381, 37);
            this.comboBD.TabIndex = 32;
            this.comboBD.TextChanged += new System.EventHandler(this.comboBD_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(85, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 31);
            this.label1.TabIndex = 31;
            this.label1.Text = "Базы данных";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // buttonImport
            // 
            this.buttonImport.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonImport.ForeColor = System.Drawing.Color.White;
            this.buttonImport.Location = new System.Drawing.Point(12, 131);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(381, 50);
            this.buttonImport.TabIndex = 29;
            this.buttonImport.Text = "Импорт";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.Brown;
            this.button_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Exit.ForeColor = System.Drawing.Color.White;
            this.button_Exit.Location = new System.Drawing.Point(12, 299);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(381, 50);
            this.button_Exit.TabIndex = 28;
            this.button_Exit.Text = "Назад";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // buttonBackUp
            // 
            this.buttonBackUp.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonBackUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBackUp.ForeColor = System.Drawing.Color.White;
            this.buttonBackUp.Location = new System.Drawing.Point(12, 243);
            this.buttonBackUp.Name = "buttonBackUp";
            this.buttonBackUp.Size = new System.Drawing.Size(381, 50);
            this.buttonBackUp.TabIndex = 27;
            this.buttonBackUp.Text = "Восстановить структуру";
            this.buttonBackUp.UseVisualStyleBackColor = false;
            this.buttonBackUp.Click += new System.EventHandler(this.buttonBackUp_Click);
            // 
            // buttonBackUpFull
            // 
            this.buttonBackUpFull.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonBackUpFull.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackUpFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackUpFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBackUpFull.ForeColor = System.Drawing.Color.White;
            this.buttonBackUpFull.Location = new System.Drawing.Point(12, 187);
            this.buttonBackUpFull.Name = "buttonBackUpFull";
            this.buttonBackUpFull.Size = new System.Drawing.Size(381, 50);
            this.buttonBackUpFull.TabIndex = 34;
            this.buttonBackUpFull.Text = "Восстановить данные";
            this.buttonBackUpFull.UseVisualStyleBackColor = false;
            this.buttonBackUpFull.Click += new System.EventHandler(this.buttonBackUpFull_Click);
            // 
            // BD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 359);
            this.Controls.Add(this.buttonBackUpFull);
            this.Controls.Add(this.comboBD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.buttonBackUp);
            this.Name = "BD";
            this.Text = "BD";
            this.Load += new System.EventHandler(this.BD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button buttonBackUp;
        private System.Windows.Forms.Button buttonBackUpFull;
    }
}