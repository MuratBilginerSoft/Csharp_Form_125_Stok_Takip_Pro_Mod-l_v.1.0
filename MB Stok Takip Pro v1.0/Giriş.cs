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
    public partial class Giriş : Form
    {
        #region Değişkenler

        string kullanıcıadı, şifre;

        #endregion

        #region Tanımlamalar


        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adaptor = new OleDbDataAdapter();
        DataTable tablo = new DataTable();
       

        #endregion

        #region Metodlar

        public void verigöster()
        {
            OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=StokTakip.accdb");
            bağlantı.Open();
            tablo.Clear();
            string sorgu = "select * from Login";
            komut = new OleDbCommand(sorgu,bağlantı);
            adaptor = new OleDbDataAdapter(komut);
            adaptor.Fill(tablo);
            adaptor.Dispose();
            bağlantı.Dispose();
            bağlantı.Close();
        }
        

        #endregion

        public Giriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verigöster();
            kullanıcıadı = textBox1.Text;
            şifre = textBox2.Text;

            int i;

            for (i = 0; i < tablo.Rows.Count; i++)
            {
                if (kullanıcıadı == tablo.Rows[i]["KullanıcıAdı"].ToString() && şifre == tablo.Rows[i]["Şifre"].ToString())
                {
                    StokTakip stoktakip = new StokTakip();
                    this.Hide();
                    stoktakip.ShowDialog();
                    this.Show();
                    break;
                }
            }


            if (i == tablo.Rows.Count)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
