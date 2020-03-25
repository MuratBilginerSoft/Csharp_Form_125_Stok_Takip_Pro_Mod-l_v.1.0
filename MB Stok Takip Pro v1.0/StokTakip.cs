using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace MB_Stok_Takip_Pro_v1._0
{
    public partial class StokTakip : Form
    {
        #region Değişkenler

        #endregion 

        #region Tanımlamalar

        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adaptor = new OleDbDataAdapter();
        DataTable tablo = new DataTable();
        DataSet veri = new DataSet();

        #endregion

        #region Metodlar

        public void verilerigöster()

        {
            OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=StokTakip.accdb");
            bağlantı.Open();
            tablo.Clear();
            string sorgu = "select * from Stok";
            komut = new OleDbCommand(sorgu, bağlantı);
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adaptor.Dispose();
            bağlantı.Dispose();
            bağlantı.Close();
            DgwDüzenle();
        
        }

        public void DgwDüzenle()
        {

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;        
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "SERİ NO";
            dataGridView1.Columns[2].HeaderText = "STOK ADI";
            dataGridView1.Columns[3].HeaderText = "STOK BÖLÜMÜ";
            dataGridView1.Columns[4].HeaderText = "STOK MODELİ";
            dataGridView1.Columns[5].HeaderText = "STOK ADETİ";
            dataGridView1.Columns[6].HeaderText = "GİRİŞ TARİHİ";
            dataGridView1.Columns[7].HeaderText = "KAYIT YAPAN";
            dataGridView1.Columns[8].HeaderText = "BİRİM FİYAT";
            dataGridView1.Columns[9].HeaderText = "RESİM";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 120;
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 120; 
        
        
        }

        #endregion

        public StokTakip()
        {
            InitializeComponent();
        }

        private void StokTakip_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells[9].Value.ToString());
        }
    }
}
