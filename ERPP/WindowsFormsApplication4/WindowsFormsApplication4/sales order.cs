using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class sales_order : Form
    {
        connection link = new connection();
        OleDbCommand command;
        int soid;
        int qty;
        int price;
        String total;
        public sales_order()
        {
            InitializeComponent();
        }

        private void sales_order_Load(object sender, EventArgs e)
        {
            //id of products 

            link.ERP.Open();
            OleDbCommand command2 = new OleDbCommand("select pid from products", link.ERP);
            OleDbDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox3.Items.Add(dr2["pid"].ToString());

            }
            link.ERP.Close();


            link.ERP.Open();
            OleDbCommand command1 = new OleDbCommand("select cid from customer", link.ERP);
            OleDbDataReader dr = command1.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["cid"].ToString());
            }
            link.ERP.Close();

            // module

           
          /* link.ERP.Open();
            OleDbCommand command2 = new OleDbCommand("select soid from so", link.ERP);
            OleDbDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2["soid"].ToString());

            }
            link.ERP.Close();
           */
            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count (soid) from so", link.ERP);
            OleDbDataReader dr1 = command.ExecuteReader();
            if
                (dr1.Read())
            {
                soid = Convert.ToInt32(dr1[0]);
                soid++;

            }
            link.ERP.Close();
            this.textBox87.Text = "So" + "--" + soid + "--" + System.DateTime.Today.Year;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("select * from customer where  cid='" + comboBox1.Text + "'", link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["cname"].ToString();

                textBox2.Text = dr["ph"].ToString();

               
            }
            link.ERP.Close();

            

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prodcts

            link.ERP.Open();

            command = new OleDbCommand("select * from products where pid='" + comboBox3.Text + "'", link.ERP);
            OleDbDataReader dr2 = command.ExecuteReader();
            if (dr2.Read())
            {
                textBox3.Text = dr2["pname"].ToString();

                textBox4.Text = dr2["price"].ToString();

            }

            link.ERP.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qty = Convert.ToInt32(textBox6.Text);
            price = Convert.ToInt32(textBox4.Text);

            textBox7.Text = " Product Name " + textBox3.Text + Environment.NewLine + "Product Price " + textBox4.Text + Environment.NewLine + "Total Price " + (total = (Convert.ToString(qty * price))); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String st = "Open";
            link.ERP.Open();

            command = new OleDbCommand("insert into so (cid,cname,ccpph,soid,sodate ,totalamount,status) values (@cid,@cname,@ccpph,@soid,@sodate,@totalamount,@status)", link.ERP);
          
            command.Parameters.AddWithValue("@cname", textBox1.Text);
            command.Parameters.AddWithValue("@ccpph", textBox2.Text);
            command.Parameters.AddWithValue("@cid", comboBox1.Text);
            command.Parameters.AddWithValue("@sodate",dateTimePicker2);
            command.Parameters.AddWithValue("@soid", textBox87.Text);
            command.Parameters.AddWithValue("@totalamount",textBox4.Text);
            command.Parameters.AddWithValue("@status", st);
            command.ExecuteNonQuery();
            MessageBox.Show("done");

            link.ERP.Close();
        }
    }
}
