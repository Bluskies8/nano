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
    public partial class KasirHome : Form
    {
        public KasirHome()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        List<String> namab = new List<String>();
        List<int> hargab = new List<int>();
        List<int> warna = new List<int>();
        string temp;
        public void ambil(string k)
        {
            temp = k;
            temp.ToUpper();
        }
        private void KasirHome_Load(object sender, EventArgs e)
        {
            MessageBox.Show(temp);
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
            OracleDataAdapter dataAdapt = new OracleDataAdapter("SELECT * FROM JENIS_SERVICE", conn);
            DataTable dtservis = new DataTable();
            dataAdapt.Fill(dtservis);
            for (int i = 0; i < dtservis.Rows.Count; i++)
            {
                jenisServisComboBox.Items.Add(dtservis.Rows[i].ItemArray[1]);
            }

            OracleDataAdapter dataAdapt1 = new OracleDataAdapter("SELECT * FROM Barang", conn);
            DataTable dtbarang = new DataTable();
            dataAdapt1.Fill(dtbarang);
            for (int i = 0; i < dtbarang.Rows.Count; i++)
            {
                comboBox1.Items.Add(dtbarang.Rows[i].ItemArray[1]);
            }

            OracleDataAdapter dataAdapt2 = new OracleDataAdapter("SELECT * FROM teknisi", conn);
            DataTable dtteknisi = new DataTable();
            dataAdapt2.Fill(dtteknisi);
            for (int i = 0; i < dtteknisi.Rows.Count; i++)
            {
                comboBox2.Items.Add(dtteknisi.Rows[i].ItemArray[1]);
            }

            OracleDataAdapter dataAdapt3 = new OracleDataAdapter("SELECT * FROM CUSTOMER", conn);
            DataTable dtcus = new DataTable();
            dataAdapt3.Fill(dtcus);
            for (int i = 0; i < dtcus.Rows.Count; i++)
            {
                comboBox3.Items.Add(dtcus.Rows[i].ItemArray[1]);
            }
            
            OracleCommand h = new OracleCommand("select nama_kasir from kasir where id_kasir = '" + temp + "'", conn);
            textBox1.Text = h.ExecuteScalar().ToString();
            conn.Close();
        }
        public void refreshkasir()
        {
            int t = 0;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < namab.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].Cells[0].Value = namab[i].ToString();
                this.dataGridView1.Rows[i].Cells[1].Value = hargab[i];
               
                if (warna[i] == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SeaGreen;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;

                }
                t += hargab[i];
            }
            jumlahLabel.Text = t.ToString();
        }
        private void jenisServisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (jenisServisComboBox.Text.Equals("Servis"))
            {
                namab.Add("Service");
                hargab.Add(50000);
                warna.Add(0);
            }
            else if (jenisServisComboBox.Text.Equals("Ganti Oli"))
            {
                namab.Add("Ganti Oli");
                hargab.Add(25000);
                warna.Add(0);
            }
            else if (jenisServisComboBox.Text.Equals("Tambal Ban"))
            {
                namab.Add("Tambal Ban");
                hargab.Add(15000);
                warna.Add(0);
            }
            else if (jenisServisComboBox.Text.Equals("Ganti Ban"))
            {
                namab.Add("Ganti Ban");
                hargab.Add(10000);
                warna.Add(0);
            }
            else if (jenisServisComboBox.Text.Equals("Outing"))
            {
                namab.Add("Outing");
                hargab.Add(800000);
                warna.Add(0);
            }
            else if (jenisServisComboBox.Text.Equals("Beli Barang"))
            {
                namab.Add("Beli Barang");
                hargab.Add(0);
                warna.Add(0);
            }
            refreshkasir();

            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                int indexx = this.dataGridView1.CurrentRow.Index;
                MessageBox.Show(indexx.ToString());
                if (MessageBox.Show("Apakah Anda yakin mau di hapus?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    namab.RemoveAt(indexx);
                    hargab.RemoveAt(indexx);
                    this.dataGridView1.Rows[indexx].Cells[2].Value = "";
                }
            }
            refreshkasir();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            namab.Add(comboBox1.Text);
            OracleCommand h = new OracleCommand("select Harga from barang where nama_barang = '" + comboBox1.Text + "'", conn);
            string k = h.ExecuteScalar().ToString();
            int kk = Int32.Parse(k);
            hargab.Add(kk);
            warna.Add(1);
            refreshkasir();
            conn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            button1.Enabled = true;
            button2.Enabled = false;
            int totalTrans = Convert.ToInt32(jumlahLabel.Text);
            OracleCommand cmd1 = new OracleCommand("SELECT ID_KASIR FROM KASIR WHERE NAMA_KASIR = '" + textBox1.Text + "'", conn);
            string ID_Kasir = cmd1.ExecuteScalar().ToString();

            cmd1 = new OracleCommand("SELECT ID_CUSTOMER FROM CUSTOMER WHERE NAMA_CUSTOMER = '" + comboBox3.Text + "'", conn);
            string ID_Customer = cmd1.ExecuteScalar().ToString();

            cmd1 = new OracleCommand("SELECT ID_TEKNISI FROM TEKNISI WHERE NAMA_TEKNISI = '" + comboBox2.Text + "'", conn);
            string ID_Teknisi = cmd1.ExecuteScalar().ToString();

            cmd1 = new OracleCommand("SELECT ID_LSERVICE FROM JENIS_SERVICE WHERE NAMA_SERVICE = '" + namab[0] + "'", conn);
            string ID_LService = cmd1.ExecuteScalar().ToString();
            if (namab.Count > 0)
            {
                bool beliBarang = false;
                while (namab.Count != 0)
                {
                    if(warna[0]==0)
                    {
                        if (hargab[0] == 0)
                        {
                            beliBarang = true;
                            namab.RemoveAt(0);
                            hargab.RemoveAt(0);
                            warna.RemoveAt(0);
                            try
                            {
                                OracleCommand cmd = new OracleCommand("INSERT INTO H_JUAL VALUES('',TO_DATE(TO_CHAR(SYSDATE,'DD/MM/YYYY'),'DD/MM/YYYY')," + totalTrans + ",'" + ID_Kasir + "','" + ID_Customer + "')", conn);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            OracleCommand cmd = new OracleCommand("INSERT INTO H_SERVICE VALUES('',TO_DATE(TO_CHAR(SYSDATE,'DD/MM/YYYY'),'DD/MM/YYYY')," + totalTrans + ",'" + ID_Kasir + "','" + ID_Customer + "','" + ID_Teknisi + "','" + ID_LService + "')", conn);
                            cmd.ExecuteNonQuery();
                            namab.RemoveAt(0);
                            hargab.RemoveAt(0);
                            warna.RemoveAt(0);
                        }
                    }
                    else
                    {
                        if (beliBarang)
                        {
                            //MENGAMBIL ID HJUAL TERBARU
                            OracleCommand check = new OracleCommand("SELECT COUNT(*) FROM H_JUAL", conn);
                            string IDJual = check.ExecuteScalar().ToString();
                            IDJual = "HJ" + IDJual.PadLeft(4, '0');
                            //MENGECEK DJUAL DENGAN ID HJUAL TERBARU
                            OracleCommand checkIDBarang = new OracleCommand("SELECT ID_BARANG FROM BARANG WHERE NAMA_BARANG = '" + namab[0] + "'", conn);
                            string IDBarang = checkIDBarang.ExecuteScalar().ToString();
                            OracleCommand check1 = new OracleCommand("SELECT COUNT(*) FROM D_JUAL WHERE ID_JUAL = '" + IDJual + "' AND ID_BARANG = '" + IDBarang + "'", conn);
                            int countID_DJual = Convert.ToInt32(check1.ExecuteScalar());
                            if (countID_DJual == 0)
                            {
                                OracleCommand cmd = new OracleCommand("INSERT INTO D_JUAL VALUES('"+ IDJual +"','"+ IDBarang +"',"+ hargab[0] +", 1)", conn);
                                cmd.ExecuteNonQuery();
                                namab.RemoveAt(0);
                                hargab.RemoveAt(0);
                                warna.RemoveAt(0);
                            }
                            else
                            {
                                OracleCommand takeNumber = new OracleCommand("SELECT JUMLAH FROM D_JUAL WHERE ID_JUAL = '" + IDJual + "' AND ID_BARANG = '" + IDBarang + "'", conn);
                                int itemCount = Convert.ToInt32(takeNumber.ExecuteScalar());
                                OracleCommand cmd = new OracleCommand("UPDATE D_JUAL SET JUMLAH = "+ (itemCount+1) +" WHERE ID_JUAL = '" + IDJual + "' AND ID_BARANG = '" + IDBarang + "'", conn);
                                cmd.ExecuteNonQuery();
                                namab.RemoveAt(0);
                                hargab.RemoveAt(0);
                                warna.RemoveAt(0);
                            }
                        }
                        else
                        {
                            //MENGAMBIL ID HSERVICE TERBARU
                            OracleCommand check = new OracleCommand("SELECT COUNT(*) FROM H_SERVICE", conn);
                            string IDService = check.ExecuteScalar().ToString();
                            IDService = "HS" + IDService.PadLeft(4, '0');
                            //MENGECEK DSERVICE DENGAN ID HSERVICE TERBARU
                            OracleCommand checkIDBarang = new OracleCommand("SELECT ID_BARANG FROM BARANG WHERE NAMA_BARANG = '" + namab[0] + "'", conn);
                            string IDBarang = checkIDBarang.ExecuteScalar().ToString();
                            OracleCommand check1 = new OracleCommand("SELECT COUNT(*) FROM D_SERVICE WHERE ID_SERVICE = '" + IDService + "' AND ID_BARANG = '" + IDBarang + "'", conn);
                            int countID_DService = Convert.ToInt32(check1.ExecuteScalar());
                            if (countID_DService == 0)
                            {
                                OracleCommand cmd = new OracleCommand("INSERT INTO D_SERVICE VALUES('" + IDService + "','" + IDBarang + "'," + hargab[0] + ", 1)", conn);
                                cmd.ExecuteNonQuery();
                                namab.RemoveAt(0);
                                hargab.RemoveAt(0);
                                warna.RemoveAt(0);
                            }
                            else
                            {
                                OracleCommand takeNumber = new OracleCommand("SELECT JUMLAH FROM D_SERVICE WHERE ID_SERVICE = '" + IDService + "' AND ID_BARANG = '" + IDBarang + "'", conn);
                                int itemCount = Convert.ToInt32(takeNumber.ExecuteScalar());
                                OracleCommand cmd = new OracleCommand("UPDATE D_SERVICE SET JUMLAH = " + (itemCount+1) + " WHERE ID_SERVICE = '" + IDService + "' AND ID_BARANG = '" + IDBarang + "'", conn);
                                cmd.ExecuteNonQuery();
                                namab.RemoveAt(0);
                                hargab.RemoveAt(0);
                                warna.RemoveAt(0);
                            }
                        }
                    }
                }
                MessageBox.Show("Transaksi berhasil disimpan!");
            }
            else
            {
                MessageBox.Show("Tidak ada transaksi yang dapat dimasukkan!");
            }
            refreshkasir();
            conn.Close();
        }

        private void gantiPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ganti_password g = new ganti_password();
            g.ambil(textBox1.Text);
            g.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            namab.Clear();
            hargab.Clear();
            warna.Clear();
            refreshkasir();
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
