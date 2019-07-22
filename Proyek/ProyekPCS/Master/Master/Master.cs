using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Master
{
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        private void Master_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(
                    "user id=system;" +
                    "password=michael123;" +
                    "data source=laptop-c8ps48dq"
                );
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataRefresh();
        }

        private void kasirButton_CheckedChanged(object sender, EventArgs e)
        {
            string query = "SELECT ID_KASIR, NAMA_KASIR, ALAMAT, TELEPON FROM KASIR WHERE STATUS = 1";
            OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dataAdapt.Fill(dt);
            dataGridView1.DataSource = dt;
            resetData();
            dataRefresh();
        }

        private void teknisiButton_CheckedChanged(object sender, EventArgs e)
        {
            string query = "SELECT ID_TEKNISI, NAMA_TEKNISI, ALAMAT, TELEPON FROM TEKNISI WHERE STATUS = 1";
            OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dataAdapt.Fill(dt);
            dataGridView1.DataSource = dt;
            resetData();
            dataRefresh();
        }

        private void customerButton_CheckedChanged(object sender, EventArgs e)
        {
            string query = "SELECT ID_CUSTOMER, NAMA_CUSTOMER, ALAMAT, TELEPON FROM CUSTOMER WHERE STATUS = 1";
            OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dataAdapt.Fill(dt);
            dataGridView1.DataSource = dt;
            resetData();
            dataRefresh();
        }
        string passwordb = "";
        string hash = "f0xle@rn";
        private void insertButton_Click(object sender, EventArgs e)
        {
            
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    passwordb = Convert.ToBase64String(results, 0, results.Length);
                    
                }
            }
            
            string query="";
            string jenis;
            if (kasirButton.Checked)
            {
                jenis = "KASIR";
                query = "INSERT INTO " + jenis + " VALUES('','" + namaTextBox.Text + "','" + alamatTextBox.Text + "','" + noTelpTextBox.Text + "', 1, '"+passwordb+"')";
            }
            else if (teknisiButton.Checked)
            {

                jenis = "TEKNISI";
                query = "INSERT INTO " + jenis + " VALUES('','" + namaTextBox.Text + "','" + alamatTextBox.Text + "','" + noTelpTextBox.Text + "', 1, '123456')";
            }
            else if (customerButton.Checked)
            {
                jenis = "CUSTOMER";
                query = "INSERT INTO " + jenis + " VALUES('','" + namaTextBox.Text + "','" + alamatTextBox.Text + "','" + noTelpTextBox.Text + "', 1, '123456')";

            }
            else
                jenis = "";
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataRefresh();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string jenis;
            if (kasirButton.Checked)
                jenis = "KASIR";
            else if (teknisiButton.Checked)
                jenis = "TEKNISI";
            else if (customerButton.Checked)
                jenis = "CUSTOMER";
            else
                jenis = "";
            string ID = IDTextBox.Text;
            string nama = namaTextBox.Text;
            string query = "UPDATE " + jenis + " SET NAMA_" + jenis + " = '" + nama + "'," +
                           "ALAMAT = '" + alamatTextBox.Text + "'," +
                           "TELEPON = '" + noTelpTextBox.Text + "' WHERE ID_" + jenis + " = '" + ID + "'";
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataRefresh();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string jenis;
            if (kasirButton.Checked)
                jenis = "KASIR";
            else if (teknisiButton.Checked)
                jenis = "TEKNISI";
            else if (customerButton.Checked)
                jenis = "CUSTOMER";
            else
                jenis = "";
            string ID = IDTextBox.Text;
            string nama = namaTextBox.Text;
            string telepon = noTelpTextBox.Text;
            string alamat = alamatTextBox.Text;
            string query = "UPDATE " + jenis + " SET STATUS = 0 " +
                           "WHERE ID_" + jenis + " = '" + ID + "'";
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataRefresh();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!searchTextBox.Text.Equals(""))
            {
                string jenis;
                if (kasirButton.Checked)
                    jenis = "KASIR";
                else if (teknisiButton.Checked)
                    jenis = "TEKNISI";
                else if (customerButton.Checked)
                    jenis = "CUSTOMER";
                else
                    jenis = "";
                string search = searchTextBox.Text.ToUpper();
                if (IDBtn.Checked)
                {
                    string query = "SELECT ID_" + jenis + ", NAMA_" + jenis + ", ALAMAT, TELEPON FROM " + jenis + " WHERE STATUS = 1 AND UPPER(ID_" + jenis + ") LIKE '%"+ search +"%'";
                    OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dataAdapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if(namaBtn.Checked)
                {
                    string query = "SELECT ID_" + jenis + ", NAMA_" + jenis + ", ALAMAT, TELEPON FROM " + jenis + " WHERE STATUS = 1 AND UPPER(NAMA_" + jenis + ") LIKE '%" + search + "%'";
                    OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dataAdapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                dataRefresh();
            }
        }

        public void dataRefresh()
        {
            if (kasirButton.Checked)
            {
                string query = "SELECT ID_KASIR, NAMA_KASIR, ALAMAT, TELEPON FROM KASIR WHERE STATUS = 1";
                OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dataAdapt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if(teknisiButton.Checked)
            {
                string query = "SELECT ID_TEKNISI, NAMA_TEKNISI, ALAMAT, TELEPON FROM TEKNISI WHERE STATUS = 1";
                OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dataAdapt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if(customerButton.Checked)
            {
                string query = "SELECT ID_CUSTOMER, NAMA_CUSTOMER, ALAMAT, TELEPON FROM CUSTOMER WHERE STATUS = 1";
                OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dataAdapt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        public void resetData()
        {
            namaTextBox.Text = "";
            noTelpTextBox.Text = "";
            IDTextBox.Text = "";
            alamatTextBox.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            IDTextBox.Text = dataGridView1[0, row].Value.ToString();
            namaTextBox.Text = dataGridView1[1, row].Value.ToString();
            alamatTextBox.Text = dataGridView1[2, row].Value.ToString();
            noTelpTextBox.Text = dataGridView1[3, row].Value.ToString();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminHome a = new AdminHome();
            a.Show();
            this.Close();
        }
    }
}
