using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WW.Forms.Admin;


namespace WW
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            // Устанавливаем положение формы в центр экрана при открытии
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // Блокируем изменение размера окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {}

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckProduct checkProduct = new CheckProduct();
            this.Visible = false;
            checkProduct.ShowDialog();
            this.Visible = true;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            this.Visible = false;
            staff.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            this.Visible = false;
            category.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Manufacturers manufacturers = new Manufacturers();
            this.Visible = false;
            manufacturers.ShowDialog();
            this.Visible = true;
        }

        private void button_BD_Click(object sender, EventArgs e)
        {
            BD bD = new BD();
            this.Visible = false;
            bD.ShowDialog();
            this.Visible = true;
        }
    }
}
