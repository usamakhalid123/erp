namespace WindowsFormsApplication4
{
    partial class connection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ERP = new System.Data.OleDb.OleDbConnection();
            this.SuspendLayout();
            // 
            // ERP
            // 
            this.ERP.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Haier\\Desktop\\USama\\BS3B\\" +
    "VP\\ERPP\\WindowsFormsApplication4\\WindowsFormsApplication4\\bin\\Debug\\erp databse." +
    "accdb\"";
            // 
            // connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "connection";
            this.Text = "connection";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Data.OleDb.OleDbConnection ERP;

    }
}