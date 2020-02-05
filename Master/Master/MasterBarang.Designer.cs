namespace Master
{
    partial class MasterBarang
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numHargaBarang = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteBarang = new System.Windows.Forms.Button();
            this.btnUpdateBarang = new System.Windows.Forms.Button();
            this.btnInsertBarang = new System.Windows.Forms.Button();
            this.tbIDBarang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNamaBarang = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSearchBarang = new System.Windows.Forms.TextBox();
            this.radioNamaSearch = new System.Windows.Forms.RadioButton();
            this.radioIDsearch = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHargaBarang)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numHargaBarang);
            this.groupBox2.Controls.Add(this.btnDeleteBarang);
            this.groupBox2.Controls.Add(this.btnUpdateBarang);
            this.groupBox2.Controls.Add(this.btnInsertBarang);
            this.groupBox2.Controls.Add(this.tbIDBarang);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbNamaBarang);
            this.groupBox2.Location = new System.Drawing.Point(9, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 203);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Barang";
            // 
            // numHargaBarang
            // 
            this.numHargaBarang.Location = new System.Drawing.Point(89, 97);
            this.numHargaBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numHargaBarang.Name = "numHargaBarang";
            this.numHargaBarang.Size = new System.Drawing.Size(204, 20);
            this.numHargaBarang.TabIndex = 13;
            // 
            // btnDeleteBarang
            // 
            this.btnDeleteBarang.Location = new System.Drawing.Point(218, 150);
            this.btnDeleteBarang.Name = "btnDeleteBarang";
            this.btnDeleteBarang.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBarang.TabIndex = 12;
            this.btnDeleteBarang.Text = "Delete";
            this.btnDeleteBarang.UseVisualStyleBackColor = true;
            this.btnDeleteBarang.Click += new System.EventHandler(this.btnDeleteBarang_Click);
            // 
            // btnUpdateBarang
            // 
            this.btnUpdateBarang.Location = new System.Drawing.Point(115, 150);
            this.btnUpdateBarang.Name = "btnUpdateBarang";
            this.btnUpdateBarang.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateBarang.TabIndex = 11;
            this.btnUpdateBarang.Text = "Update";
            this.btnUpdateBarang.UseVisualStyleBackColor = true;
            this.btnUpdateBarang.Click += new System.EventHandler(this.btnUpdateBarang_Click);
            // 
            // btnInsertBarang
            // 
            this.btnInsertBarang.Location = new System.Drawing.Point(9, 150);
            this.btnInsertBarang.Name = "btnInsertBarang";
            this.btnInsertBarang.Size = new System.Drawing.Size(75, 23);
            this.btnInsertBarang.TabIndex = 10;
            this.btnInsertBarang.Text = "Insert";
            this.btnInsertBarang.UseVisualStyleBackColor = true;
            this.btnInsertBarang.Click += new System.EventHandler(this.btnInsertBarang_Click);
            // 
            // tbIDBarang
            // 
            this.tbIDBarang.Enabled = false;
            this.tbIDBarang.Location = new System.Drawing.Point(89, 29);
            this.tbIDBarang.Name = "tbIDBarang";
            this.tbIDBarang.Size = new System.Drawing.Size(204, 20);
            this.tbIDBarang.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ID Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Harga Barang";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nama Barang";
            // 
            // tbNamaBarang
            // 
            this.tbNamaBarang.Location = new System.Drawing.Point(89, 63);
            this.tbNamaBarang.Name = "tbNamaBarang";
            this.tbNamaBarang.Size = new System.Drawing.Size(204, 20);
            this.tbNamaBarang.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbSearchBarang);
            this.groupBox3.Controls.Add(this.radioNamaSearch);
            this.groupBox3.Controls.Add(this.radioIDsearch);
            this.groupBox3.Location = new System.Drawing.Point(9, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 88);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Barang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Search by";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Search";
            // 
            // tbSearchBarang
            // 
            this.tbSearchBarang.Location = new System.Drawing.Point(77, 19);
            this.tbSearchBarang.Name = "tbSearchBarang";
            this.tbSearchBarang.Size = new System.Drawing.Size(216, 20);
            this.tbSearchBarang.TabIndex = 2;
            this.tbSearchBarang.TextChanged += new System.EventHandler(this.tbSearchBarang_TextChanged);
            // 
            // radioNamaSearch
            // 
            this.radioNamaSearch.AutoSize = true;
            this.radioNamaSearch.Location = new System.Drawing.Point(137, 55);
            this.radioNamaSearch.Name = "radioNamaSearch";
            this.radioNamaSearch.Size = new System.Drawing.Size(53, 17);
            this.radioNamaSearch.TabIndex = 1;
            this.radioNamaSearch.TabStop = true;
            this.radioNamaSearch.Text = "Nama";
            this.radioNamaSearch.UseVisualStyleBackColor = true;
            // 
            // radioIDsearch
            // 
            this.radioIDsearch.AutoSize = true;
            this.radioIDsearch.Location = new System.Drawing.Point(77, 55);
            this.radioIDsearch.Name = "radioIDsearch";
            this.radioIDsearch.Size = new System.Drawing.Size(36, 17);
            this.radioIDsearch.TabIndex = 0;
            this.radioIDsearch.TabStop = true;
            this.radioIDsearch.Text = "ID";
            this.radioIDsearch.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(339, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(624, 486);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(218, 464);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(91, 34);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // MasterBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 510);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MasterBarang";
            this.Text = "Master Barang";
            this.Load += new System.EventHandler(this.MasterBarang_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHargaBarang)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteBarang;
        private System.Windows.Forms.Button btnUpdateBarang;
        private System.Windows.Forms.Button btnInsertBarang;
        private System.Windows.Forms.TextBox tbIDBarang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNamaBarang;
        private System.Windows.Forms.NumericUpDown numHargaBarang;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearchBarang;
        private System.Windows.Forms.RadioButton radioNamaSearch;
        private System.Windows.Forms.RadioButton radioIDsearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button backButton;
    }
}