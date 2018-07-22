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
    public partial class po_invoice : Form
    {
        connection link = new connection();
        int invoiceid;

        public po_invoice()
        {
            InitializeComponent();
        }

        private void po_invoice_Load(object sender, EventArgs e)
        {
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("select grnid from grn where status='Open'",link.ERP);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                comboBox1.Items.Add(dr["grnid"].ToString());
            
            }
            link.ERP.Close();
            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count   (invoiceid) from invoice", link.ERP);
            OleDbDataReader dr1 = command.ExecuteReader();
            if (dr1.Read())
            {
                invoiceid = Convert.ToInt32(dr1[0]);
                invoiceid++;

            }
            link.ERP.Close();
            this.textBox3.Text = "Invoice" + "--" + invoiceid + "--" + System.DateTime.Today.Year;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("select * from grn where grnid ='" +comboBox1.Text +"'" ,link.ERP);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                //textBox4.Text = dr[""].ToString();
                textBox5.Text = dr["ddate"].ToString();
                textBox6.Text = dr["grdate"].ToString();
                textBox7.Text = dr["poid"].ToString();
                textBox8.Text = dr["vname"].ToString();
            
            }

            link.ERP.Close();
            link.ERP.Open();
            OleDbCommand cmd1 = new OleDbCommand("select totalamount from po where poid='" + textBox7.Text + "'", link.ERP);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox4.Text = dr1["totalamount"].ToString();
            }
            link.ERP.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Invoice(grnid,invoiceid,amountpayable,cdate,dcdate,grndate,poid,vname) values (@grnid,@invoiceid,@amountpayable,@cdate,@dcdate,@grndate,@poid,@vname)", link.ERP);
            cmd.Parameters.AddWithValue("@grnid",comboBox1.Text);
            cmd.Parameters.AddWithValue("@invoiceid",textBox3.Text);
            cmd.Parameters.AddWithValue("@amountpayable",textBox4.Text);
            cmd.Parameters.AddWithValue("@cdate",System.DateTime.Today);
            cmd.Parameters.AddWithValue("@dcdate", textBox5.Text);    
            cmd.Parameters.AddWithValue("@grndate",textBox6.Text);
            cmd.Parameters.AddWithValue("@poid",textBox7.Text);
            cmd.Parameters.AddWithValue("@vname",textBox8.Text);
            MessageBox.Show("Done");
            link.ERP.Close();
        }
    }
}
