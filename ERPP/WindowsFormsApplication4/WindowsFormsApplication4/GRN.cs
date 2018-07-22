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
    public partial class GRN : Form
    {
        connection link = new connection();
        OleDbCommand command;
        int grn;
        public GRN()
        {
            InitializeComponent();
        }

        private void GRN_Load(object sender, EventArgs e)
        {
            link.ERP.Open();
            OleDbCommand cmd = new OleDbCommand("select poid from  po where status = 'Open'",link.ERP);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["poid"].ToString());
            }         
            link.ERP.Close();



            link.ERP.Open();

            OleDbCommand command = new OleDbCommand("select count (grnid) from grn", link.ERP);
            OleDbDataReader dr1 = command.ExecuteReader();
            if(dr1.Read())
            {
                grn = Convert.ToInt32(dr1[0]);
                grn++;

            }    
            link.ERP.Close();
            this.textBox1.Text = "GRN" + "--" + grn + "--" + System.DateTime.Today.Year;
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            link.ERP.Open();

            OleDbCommand comd = new OleDbCommand("select * from po  where poid = '"+comboBox1.Text+"'",link.ERP);
            OleDbDataReader dr = comd.ExecuteReader();
            if (dr.Read())

            {
               /* textBox2.Text = dr[""].ToString();
                textBox3.Text = dr[""].ToString();
                textBox4.Text = dr[""].ToString();
                */textBox5.Text = dr["ddate"].ToString();
                textBox6.Text = dr["vname"].ToString();
                textBox7.Text = dr["vid"].ToString();
                textBox8.Text = dr["totalamount"].ToString();
            }
            link.ERP.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            link.ERP.Open();

            command = new OleDbCommand("insert into grn (poid,grnid,vname,ddate,grdate,status) values (@poid,@grnid,@vname,@ddate,@grdate,@status)", link.ERP);
            command.Parameters.AddWithValue("@poid",comboBox1.Text);
            command.Parameters.AddWithValue("@grnid", textBox1.Text);
            command.Parameters.AddWithValue("@vname", textBox6.Text);
            command.Parameters.AddWithValue("@ddate", textBox5.Text);
            command.Parameters.AddWithValue("@status","Open");
            command.Parameters.AddWithValue("@grdate", System.DateTime.Today);
            MessageBox.Show("Entered");
            link.ERP.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
