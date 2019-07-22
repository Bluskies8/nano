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
    public partial class ganti_password : Form
    {
        string temp;
        public void ambil(string k)
        {
            temp = k;
           
        }
        public ganti_password()
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
            
            
        }
        string hash= "f0xle@rn";
        string passwordb;
        private void button1_Click(object sender, EventArgs e)
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
            string query = "UPDATE kasir SET password  = '" + passwordb + "' WHERE ID_kasir  = '" + textBox2.Text + "'";
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Sukses");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //tes
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ganti_password_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(
                    "user id=system;" +
                    "password=865022;" +
                    "data source=orcl"
                );
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show(temp);
            OracleCommand h = new OracleCommand("select id_kasir from kasir where nama_kasir = '" + temp + "'", conn);
            textBox2.Text = h.ExecuteScalar().ToString();
        }
    }
}
