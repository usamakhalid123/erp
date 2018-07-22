using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication4
{
    public partial class Form4 : Form
    {
        connection link = new connection();
        OleDbCommand command;
        int poid;
        String total;
        int price;
        int qty;
        
        
        
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        //populte vid from vendor auto
            link.ERP.Open();
           OleDbCommand command1 = new OleDbCommand("select vid from vendor" , link.ERP);
            OleDbDataReader dr = command1.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["vid"].ToString());
            }         


            link.ERP.Close();


            //select model

            link.ERP.Open();
            OleDbCommand command2 = new OleDbCommand("select pid from products",link.ERP);
            OleDbDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2["pid"].ToString());
            
            }
            link.ERP.Close();

            //populate purchse order id auto
            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count (poid) from po", link.ERP);
            OleDbDataReader dr1 = command.ExecuteReader();
            if
                (dr1.Read())
            {
                poid = Convert.ToInt32(dr1[0]);
                poid++;

            }
            link.ERP.Close();
            this.textBox8.Text = "PO" + "--" + poid + "--" + System.DateTime.Today.Year;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         //select  pname and price from products ta table
            link.ERP.Open();

            command = new OleDbCommand("select * from products where pid='" + comboBox2.Text + "'", link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["pname"].ToString();

                textBox4.Text = dr["price"].ToString();

               
            }

            link.ERP.Close();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("select * from vendor where vid='" + comboBox1.Text + "'", link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["vname"].ToString();
              
                textBox2.Text = dr["ph"].ToString();
              
                textBox5.Text = dr["vdept"].ToString();
            }




            link.ERP.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qty = Convert.ToInt32(textBox6.Text);
            price = Convert.ToInt32(textBox4.Text);

            textBox7.Text = " Product Name " + textBox3.Text + Environment.NewLine + "Product Price " + textBox4.Text + Environment.NewLine + "Total Price " + (total= (Convert.ToString(qty*price))); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String st = "Open";
            link.ERP.Open();

            command = new OleDbCommand("insert into po (poid,ddate,vname,vid,vphone,vdept,productmodel,productname,productqty,productprice,status) values (@poid,@ddate,@vphone,@vname,@vid,@vdept,@productmodel,@productname,@productqty,@productprice,@status)", link.ERP);
            command.Parameters.AddWithValue("@poid", textBox8.Text);
            command.Parameters.AddWithValue("@vname", textBox1.Text);
            command.Parameters.AddWithValue("@vphone", textBox2.Text);
            command.Parameters.AddWithValue("@vid",comboBox1.Text);
            command.Parameters.AddWithValue("@ddate", System.DateTime.Today);          
            command.Parameters.AddWithValue("@vdept", textBox5.Text);
            command.Parameters.AddWithValue("@productmodel", comboBox2.Text);
            command.Parameters.AddWithValue("@productname", textBox3.Text);
            command.Parameters.AddWithValue("@productqty", textBox6.Text);
            command.Parameters.AddWithValue("@productprice", textBox4.Text);
            command.Parameters.AddWithValue("@Status", st);        
            command.ExecuteNonQuery();
            MessageBox.Show("done");

            link.ERP.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
