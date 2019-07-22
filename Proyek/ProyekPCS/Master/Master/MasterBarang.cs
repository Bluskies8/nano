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
    public partial class MasterBarang : Form
    {
        public MasterBarang()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        private void MasterBarang_Load(object sender, EventArgs e)
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

        public void dataRefresh()
        {
            string query = "SELECT * FROM BARANG";
            OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dataAdapt.Fill(dt);
            dataGridView1.DataSource = dt;            
        }

        public void resetData()
        {
            tbNamaBarang.Text = "";
            tbIDBarang.Text = "";
            numHargaBarang.Value = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            tbIDBarang.Text = dataGridView1[0, row].Value.ToString();
            tbNamaBarang.Text = dataGridView1[1, row].Value.ToString();
            numHargaBarang.Value = (int)dataGridView1[2, row].Value;
        }

        private void tbSearchBarang_TextChanged(object sender, EventArgs e)
        {
            if (!tbSearchBarang.Text.Equals(""))
            {
                string search = tbSearchBarang.Text.ToUpper();
                if (radioIDsearch.Checked)
                {
                    string query = "SELECT * FROM BARANG WHERE UPPER(ID_BARANG) LIKE '%" + search + "%'";
                    OracleDataAdapter dataAdapt = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dataAdapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (radioNamaSearch.Checked)
                {
                    string query = "SELECT * FROM BARANG WHERE UPPER(NAMA_BARANG) LIKE '%" + search + "%'";
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

        private void btnInsertBarang_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO BARANG VALUES('','" + tbNamaBarang.Text + "','" + (int)numHargaBarang.Value + ")";
            //MessageBox.Show(query);
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

        private void btnUpdateBarang_Click(object sender, EventArgs e)
        {
            string query = "UPDATE BARANG SET NAMA_BARANG = '" + tbNamaBarang + "'," +
                           "HARGA  = '" + (int)numHargaBarang.Value;
            //MessageBox.Show(query);
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

        private void btnDeleteBarang_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM BARANG WHERE NAMA_BARANG = '" + tbNamaBarang + "' OR " +
                           "HARGA = '" + (int)numHargaBarang.Value;
            //MessageBox.Show(query);
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

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminHome a = new AdminHome();
            a.Show();
            this.Close();
        }
    }
}
