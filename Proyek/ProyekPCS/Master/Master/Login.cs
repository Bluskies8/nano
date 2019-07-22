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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        private void Form1_Load(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        string passwordb;
        string hash = "f0xle@rn";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                AdminHome a = new AdminHome();
                a.Show();
            }
            else
            {
                string pass;
                OracleCommand h = new OracleCommand("select password from kasir where id_kasir = '" + textBox1.Text + "'", conn);
                pass = h.ExecuteScalar().ToString();
                byte[] data1 = Convert.FromBase64String(pass);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripdes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data1, 0, data1.Length);
                        passwordb = UTF8Encoding.UTF8.GetString(results);

                    }
                }
                MessageBox.Show(passwordb);
                if (pass != "")
                {
                    if (textBox2.Text == passwordb)
                    {
                        KasirHome a = new KasirHome();
                        a.ambil(textBox1.Text);
                        a.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("password salah");
                    }
                }
                else
                {
                    MessageBox.Show("username tidak ada");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                
                
            }
        }
    }
}
