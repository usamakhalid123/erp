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
    public partial class Form3 : Form
    {
        int cid;
        OleDbCommand command;
        connection link = new connection();
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox8.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox9.Enabled = false;
            this.groupBox1.Enabled = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.textBox1.Visible = false;
            this.Text = "Vendor Details";
            this.button5.Location = new Point(253, 324);


            link.ERP.Open();

            OleDbCommand command1 = new OleDbCommand("select vid from vendor", link.ERP);
            OleDbDataReader dr1 = command1.ExecuteReader();
            while
                (dr1.Read())
            {
                comboBox1.Items.Add(dr1["vid"].ToString());
            }
            link.ERP.Close();


            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count (vid) from vendor", link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if
                (dr.Read())
            {
                cid = Convert.ToInt32(dr[0]);
                cid++;

            }
            link.ERP.Close();
            this.textBox1.Text = "Ven" + "--" + cid + "--" + System.DateTime.Today.Year;
        
        
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
            this.button5.Location = new Point(183, 351);
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.button2.Visible = true;
            this.searchToolStripMenuItem.Visible = false;
            this.upadateToolStripMenuItem.Visible = false;
            this.insertToolStripMenuItem.Visible = false;
            this.groupBox1.Enabled = true;
            this.comboBox1.Enabled = true;
            this.Text = "Delete Info";
            this.button5.Location = new Point(183, 351);
            
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
            this.button5.Location = new Point(183, 351);
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("insert into vendor (vid,vname,vaddress,vcity,ph,vemail,vdate,cpname,vdept) values (@vid,@vname,@vaddress,@vcity,@ph,@vemail,@vdate,@vdept,@cpname)", link.ERP);
            command.Parameters.AddWithValue("@vid", textBox1.Text);
            command.Parameters.AddWithValue("@vname", textBox8.Text);
            command.Parameters.AddWithValue("@vaddress", textBox2.Text);
            command.Parameters.AddWithValue("@vcity", textBox6.Text);
            command.Parameters.AddWithValue("@ph", textBox4.Text);
            command.Parameters.AddWithValue("@vemail", textBox7.Text);
            command.Parameters.AddWithValue("@vdate", textBox3.Text);

            command.Parameters.AddWithValue("@cpname", textBox9.Text);
            command.Parameters.AddWithValue("@vdept", textBox5.Text);

           // textBox9.Text = dr["cpname"].ToString();
            //textBox5.Text = dr["vdept"].ToString();
            
            command.ExecuteNonQuery();
            MessageBox.Show("done");

            link.ERP.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("select * from vendor where vid='" + comboBox1.Text + "'", link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                textBox8.Text = dr["vname"].ToString();
                textBox3.Text = dr["vdate"].ToString();
                textBox4.Text = dr["ph"].ToString();
                textBox6.Text = dr["vcity"].ToString();
                textBox7.Text = dr["vemail"].ToString();
                textBox2.Text = dr["vaddress"].ToString();
               
                textBox9.Text = dr["cpname"].ToString();
                textBox5.Text = dr["vdept"].ToString();
            }




            link.ERP.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("select * from vendor where vid='" + comboBox1.Text + "'", link.ERP);
            OleDbDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                textBox8.Text = dr["vname"].ToString();
                textBox3.Text = dr["vdate"].ToString();
                textBox4.Text = dr["ph"].ToString();
                textBox6.Text = dr["vcity"].ToString();
                textBox7.Text = dr["vemail"].ToString();
                textBox2.Text = dr["vaddress"].ToString();
                textBox9.Text = dr["cpname"].ToString();
                textBox5.Text = dr["vdept"].ToString();

            }




            link.ERP.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("update vendor set vname=@vname,vaddress=@vaddress,vcity=@vcity,ph=@ph,vemail=@vemail,vdate=@vdate,cpname=@cpname,vdept=@vdept where vid='" + comboBox1.Text + "'", link.ERP);
            // command.Parameters.AddWithValue("@cid", textBox1.Text);
            command.Parameters.AddWithValue("@vname", textBox8.Text);
            command.Parameters.AddWithValue("@vaddress", textBox2.Text);
            command.Parameters.AddWithValue("@vcity", textBox6.Text);
            command.Parameters.AddWithValue("@ph", textBox4.Text);
            command.Parameters.AddWithValue("@vemail", textBox7.Text);
            command.Parameters.AddWithValue("@vdate", textBox3.Text);

            command.Parameters.AddWithValue("@cpname", textBox9.Text);
            command.Parameters.AddWithValue("@vdept", textBox5.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("done");

            link.ERP.Close();
        }
    }
}
