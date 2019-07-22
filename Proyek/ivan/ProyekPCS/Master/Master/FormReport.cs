using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Master
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        private void FormReport_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(
                    "user id=system;" +
                    "password=orcl;" +
                    "data source=laptop-c8ps48dq"
                );
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                reportService rptservice = new reportService();
                rptservice.SetDatabaseLogon("system","orcl");
                rptservice.SetParameterValue("tgl_service", dateTimePicker1.Value);
                crystalReportViewer1.ReportSource = rptservice;
            }
            else if(radioButton2.Checked)
            {
                reportBarang rptbarang = new reportBarang();
                rptbarang.SetDatabaseLogon("system", "orcl");
                rptbarang.SetParameterValue("tanggalTransaksi", dateTimePicker1.Value);
                crystalReportViewer1.ReportSource = rptbarang;
                
            }
        }
    }
}
