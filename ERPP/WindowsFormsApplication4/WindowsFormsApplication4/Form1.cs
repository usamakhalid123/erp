using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            this.Hide();
            a.ShowDialog();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.label1.Enabled = false;
            this.pictureBox1.Enabled = false;
            this.pictureBox2.Enabled = false;
            this.label5.Enabled = false;
            this.label6.Enabled = false;
            this.label7.Enabled = false;
            this.label8.Enabled = false;
            this.label9.Enabled = false;
            this.label10.Enabled = false;
            this.label11.Enabled = false;
          
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text == ""  &&  textBox2.Text == "")
            {
                panel4.Visible = false;
                this.label1.Enabled = true;
                this.pictureBox1.Enabled = true;
                this.pictureBox2.Enabled = true;
                this.label5.Enabled = true;
                this.label6.Enabled = true;
                this.label7.Enabled = true;
                this.label8.Enabled = true;
                this.label9.Enabled = true;
                this.label10.Enabled = true;
                this.label11.Enabled = true;
            }
            else {
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            GRN gn = new GRN();
            gn.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            po_invoice po = new po_invoice();
            po.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            sales_order so = new sales_order();
            so.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            sales_order_challan soc = new sales_order_challan();
            soc.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            so_invoice soi = new so_invoice();
            soi.ShowDialog();
        }
    }
}
