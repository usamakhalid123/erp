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
    public partial class so_invoice : Form
    {
        connection link = new connection();
        public so_invoice()
        {
            InitializeComponent();
        }

        private void so_invoice_Load(object sender, EventArgs e)
        {
            int soinvoiceid = 0;
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("select * from sochallan where status='Open'", link.ERP);
                 OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["sochallanid"].ToString());

            }
            link.ERP.Close();
            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count(soinvoiceid) from soinvoice", link.ERP);
            OleDbDataReader dr1 = command.ExecuteReader();
            if (dr1.Read())
            {
                soinvoiceid = Convert.ToInt32(dr1[0]);
                soinvoiceid++;

            }
            link.ERP.Close();
            this.textBox4    .Text = "SOInvoice" + "--" + soinvoiceid + "--" + System.DateTime.Today.Year;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("select * from sochallan where sochallanid ='" + comboBox1.Text + "'", link.ERP);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                textBox8.Text = dr["rdate"].ToString();
                textBox7.Text = dr["sochallandate"].ToString();
                textBox6.Text = dr["soid"].ToString();
                textBox5.Text = dr["cname"].ToString();

            }

            link.ERP.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("insert into soinvoice(sochallanid,soinvoiceid,cname,soid,sochallandate,amountrecive,approval) values (@sochallanid,@soinvoiceid,@cname,@soid,@sochallandate,@amountrecive,@a    pproval)", link.ERP);
            cmd.Parameters.AddWithValue("@sochallanid", comboBox1.Text);
            cmd.Parameters.AddWithValue("@soinvoiceid", textBox4.Text);
            cmd.Parameters.AddWithValue("@amountrecive", textBox3.Text);
            cmd.Parameters.AddWithValue("@cname", textBox5.Text);
            cmd.Parameters.AddWithValue("@soid", textBox6.Text);
            cmd.Parameters.AddWithValue("@sochallandate", textBox7.Text);
            cmd.Parameters.AddWithValue("@approval", "Applied");
            MessageBox.Show("Done");
            link.ERP.Close();
        }
    }
}
