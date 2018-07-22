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
    public partial class Form2 : Form
    {
        int cid;
        OleDbCommand command;
        connection link = new connection();

        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox8.Enabled = false;
            this.groupBox1.Enabled = false;
            this.button1.Visible = false;
           
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.textBox1.Visible = false;
            this.Text = "Customer Details";
            this.button5.Location = new Point(253, 324);
            comboBox1.Items.Clear();


            link.ERP.Open();

            OleDbCommand command1 = new OleDbCommand("select cid from customer",link.ERP);
            OleDbDataReader dr1 = command1.ExecuteReader();
            while
                (dr1.Read())
            {
                comboBox1.Items.Add( dr1["cid"].ToString());
            }
            link.ERP.Close();

            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count (cid) from customer",link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if
                (dr.Read())
            {
                cid = Convert.ToInt32(dr[0]);
                cid ++;

            }
            link.ERP.Close();
            this.textBox1.Text = "Cus" + "--" + cid + "--" + System.DateTime.Today.Year;






        }

       

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox6.Enabled = true;
            this.textBox7.Enabled = true;
            this.textBox8.Enabled = true;
            this.groupBox1.Enabled = true;
            this.button1.Visible = true;
            this.textBox1.Visible = true;
            this.deleteToolStripMenuItem.Visible = false;
            this.searchToolStripMenuItem.Visible = false;
            this.upadateToolStripMenuItem.Visible = false;
            this.Text = "Insert Info";
            this.button5.Location = new Point(156, 324);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
              //  this.button2.Visible = true;
                
            //    this.textBox2.Enabled = true;
               // this.textBox3.Enabled = true;
                //this.textBox4.Enabled = true;
                //this.textBox6.Enabled = true;
                //this.textBox7.Enabled = true;
                //this.textBox8.Enabled = true; 
             
            this.searchToolStripMenuItem.Visible = false;
                this.upadateToolStripMenuItem.Visible = false;
                this.insertToolStripMenuItem.Visible = false;
                this.groupBox1.Enabled = true;
                this.comboBox1.Enabled = true;
                this.Text = "Delete Info";
                this.button5.Location = new Point(156, 324);
            
            



        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
           
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            this.comboBox1.Enabled = true;
            this.textBox1.Enabled = false;
            this.upadateToolStripMenuItem.Visible = false;
            this.insertToolStripMenuItem.Visible = false;
            this.deleteToolStripMenuItem.Visible = false;
            this.button5.Location = new Point(253, 324);
            this.Text = "Search Info";
        }

        private void upadateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            this.textBox1.Visible = false;
            this.comboBox1.Enabled = true;
            this.insertToolStripMenuItem.Visible = false;
            this.deleteToolStripMenuItem.Visible = false;
            this.searchToolStripMenuItem.Visible = false;
            this.button4.Visible = true;
            this.button4.Visible = true;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox6.Enabled = true;
            this.textBox7.Enabled = true;
            this.textBox8.Enabled = true;
            this.Text = "Update Info";
            this.button5.Location = new Point(156, 324);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("select * from customer where cid='" + comboBox1.Text + "'", link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                textBox8.Text = dr["cname"].ToString();
                textBox3.Text = dr["cdate"].ToString();
                textBox4.Text = dr["ph"].ToString();
                textBox6.Text = dr["city"].ToString();
                textBox7.Text = dr["cemail"].ToString();
                textBox2.Text = dr["caddress"].ToString();
            }




            link.ERP.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("insert into customer (cid,cname,caddress,city,ph,cemail,cdate) values (@cid,@cname,@caddress,@city,@ph,@cemail,@cdate)", link.ERP);
            command.Parameters.AddWithValue("@cid", textBox1.Text);
            command.Parameters.AddWithValue("@cname", textBox8.Text);
            command.Parameters.AddWithValue("@caddress", textBox2.Text);
            command.Parameters.AddWithValue("@city", textBox6.Text);
            command.Parameters.AddWithValue("@ph", textBox4.Text);
            command.Parameters.AddWithValue("@cemail", textBox7.Text);
            command.Parameters.AddWithValue("@cdate", textBox3.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("done");

            link.ERP.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("select * from customer where cid='"+comboBox1.Text+"'",link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                textBox8.Text = dr["cname"].ToString();
                textBox3.Text = dr["cdate"].ToString();
                textBox4.Text = dr["ph"].ToString();
                textBox6.Text = dr["city"].ToString();
                textBox7.Text = dr["cemail"].ToString();
                textBox2.Text = dr["caddress"].ToString();
            }
            

            
            
            link.ERP.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("update customer set cname=@cname,caddress=@caddress,city=@city,ph=@ph,cemail=@cemail,cdate=@cdate where cid='" + comboBox1.Text +"'", link.ERP);
           // command.Parameters.AddWithValue("@cid", textBox1.Text);
            command.Parameters.AddWithValue("@cname", textBox8.Text);
            command.Parameters.AddWithValue("@caddress", textBox2.Text);
            command.Parameters.AddWithValue("@city", textBox6.Text);
            command.Parameters.AddWithValue("@ph", textBox4.Text);
            command.Parameters.AddWithValue("@cemail", textBox7.Text);
            command.Parameters.AddWithValue("@cdate", textBox3.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("done");

            link.ERP.Close();

        }
    }
}
