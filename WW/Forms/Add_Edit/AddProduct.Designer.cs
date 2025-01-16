
namespace WW.Forms.Add
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNameProduct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.textStock = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboManufacturer = new System.Windows.Forms.ComboBox();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Категория";
            // 
            // textNameProduct
            // 
            this.textNameProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textNameProduct.Location = new System.Drawing.Point(13, 131);
            this.textNameProduct.MaxLength = 36;
            this.textNameProduct.Multiline = true;
            this.textNameProduct.Name = "textNameProduct";
            this.textNameProduct.Size = new System.Drawing.Size(355, 28);
            this.textNameProduct.TabIndex = 2;
            this.textNameProduct.TextChanged += new System.EventHandler(this.textNameProduct_TextChanged);
            this.textNameProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNameProduct_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Цена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Количество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Производитель";
            // 
            // textPrice
            // 
            this.textPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPrice.Location = new System.Drawing.Point(13, 407);
            this.textPrice.MaxLength = 36;
            this.textPrice.Multiline = true;
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(355, 28);
            this.textPrice.TabIndex = 6;
            this.textPrice.TextChanged += new System.EventHandler(this.textPrice_TextChanged);
            this.textPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPrice_KeyPress);
            // 
            // textStock
            // 
            this.textStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textStock.Location = new System.Drawing.Point(13, 338);
            this.textStock.MaxLength = 36;
            this.textStock.Multiline = true;
            this.textStock.Name = "textStock";
            this.textStock.Size = new System.Drawing.Size(355, 28);
            this.textStock.TabIndex = 7;
            this.textStock.TextChanged += new System.EventHandler(this.textStock_TextChanged);
            this.textStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textStock_KeyPress);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.BackColor = System.Drawing.Color.White;
            this.comboBoxCategory.DropDownHeight = 200;
            this.comboBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCategory.ForeColor = System.Drawing.Color.Black;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.IntegralHeight = false;
            this.comboBoxCategory.Location = new System.Drawing.Point(13, 200);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(355, 28);
            this.comboBoxCategory.TabIndex = 8;
            this.comboBoxCategory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxCategory_DrawItem);
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // comboManufacturer
            // 
            this.comboManufacturer.DropDownHeight = 200;
            this.comboManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboManufacturer.ForeColor = System.Drawing.Color.Black;
            this.comboManufacturer.FormattingEnabled = true;
            this.comboManufacturer.IntegralHeight = false;
            this.comboManufacturer.Location = new System.Drawing.Point(13, 269);
            this.comboManufacturer.Name = "comboManufacturer";
            this.comboManufacturer.Size = new System.Drawing.Size(355, 28);
            this.comboManufacturer.TabIndex = 9;
            this.comboManufacturer.SelectedIndexChanged += new System.EventHandler(this.comboManufacturer_SelectedIndexChanged);
            this.comboManufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboManufacturer_KeyPress);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddProduct.ForeColor = System.Drawing.Color.White;
            this.buttonAddProduct.Location = new System.Drawing.Point(13, 466);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(355, 50);
            this.buttonAddProduct.TabIndex = 10;
            this.buttonAddProduct.Text = "Добавить";
            this.buttonAddProduct.UseVisualStyleBackColor = false;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(89, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 31);
            this.label6.TabIndex = 11;
            this.label6.Text = "Добавление товара";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(82, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 20);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 528);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.comboManufacturer);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textStock);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textNameProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddProduct";
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNameProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.TextBox textStock;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboManufacturer;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}