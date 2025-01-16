
namespace WW.Forms.Add_Edit
{
    partial class AddManufacturer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddManufacturer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textManufacturer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddCategory.ForeColor = System.Drawing.Color.White;
            this.buttonAddCategory.Location = new System.Drawing.Point(12, 192);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(467, 50);
            this.buttonAddCategory.TabIndex = 32;
            this.buttonAddCategory.Text = "Добавить";
            this.buttonAddCategory.UseVisualStyleBackColor = false;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Производитель";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(88, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 31);
            this.label1.TabIndex = 29;
            this.label1.Text = "Добавление производителя";
            // 
            // textManufacturer
            // 
            this.textManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textManufacturer.Location = new System.Drawing.Point(12, 128);
            this.textManufacturer.MaxLength = 32;
            this.textManufacturer.Multiline = true;
            this.textManufacturer.Name = "textManufacturer";
            this.textManufacturer.Size = new System.Drawing.Size(467, 28);
            this.textManufacturer.TabIndex = 34;
            this.textManufacturer.TextChanged += new System.EventHandler(this.textManufacturer_TextChanged);
            this.textManufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textManufacturer_KeyPress);
            // 
            // AddManufacturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 254);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAddCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textManufacturer);
            this.Name = "AddManufacturer";
            this.Text = "AddManufacturer";
            this.Load += new System.EventHandler(this.AddManufacturer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textManufacturer;
    }
}