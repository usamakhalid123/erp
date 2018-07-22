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
    public partial class sales_order_challan : Form
    {
        connection link = new connection();
        int soid;
        public sales_order_challan()
        { 
            InitializeComponent();
        }

        private void sales_order_challan_Load(object sender, EventArgs e)
        {
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("select soid from  so where status ='Open'", link.ERP);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["soid"].ToString());
            }
            link.ERP.Close();

            //challan id 

            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count (soid) from so challanid", link.ERP);
            OleDbDataReader dr1 = command.ExecuteReader();
            if (dr1.Read())
            {
                soid = Convert.ToInt32(dr1[0]);
                soid++;

            }
            link.ERP.Close();
            this.textBox1.Text = "soid" + "--" + soid + "--" + System.DateTime.Today.Year;
          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            link.ERP.Open();

            OleDbCommand comd = new OleDbCommand("select * from so  where soid = '" + comboBox1.Text + "'", link.ERP);
            OleDbDataReader dr = comd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr["sodate"].ToString();
                textBox6.Text = dr["cname"].ToString();
                textBox7.Text = dr["cid"].ToString();
               // textBox8.Text = dr["totalamount"].ToString();
            }
            link.ERP.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("insert into so challan(soid,sochallanid,cid,cname,rdate,sochallandate,status) values (@soid,@sochallanid,@cid,@cname,@rdate,@sochallandate,@status)", link.ERP);
            command.Parameters.AddWithValue("@soid", comboBox1.Text);
            command.Parameters.AddWithValue("@sochallanid", textBox1.Text);
            command.Parameters.AddWithValue("@cid", textBox7.Text);
            command.Parameters.AddWithValue("@cname", textBox6.Text);
            command.Parameters.AddWithValue("@rdate", textBox5.Text);
            command.Parameters.AddWithValue("@sochallandate", System.DateTime.Today);
            command.Parameters.AddWithValue("@status","Open");
            MessageBox.Show("Entered");
            link.ERP.Close();
        }
    }
}
