using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticarii_Otomasyonn
{
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public string urunid;

        private void FaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txturunıd.Text = urunid;

            SqlCommand komut = new SqlCommand("select * from TBLFATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtfıyat.Text = dr[3].ToString();
                txtmıktar.Text = dr[2].ToString();
                txttutar.Text = dr[4].ToString();
                txturunad.Text = dr[1].ToString();

                bgl.baglanti().Close();
            }
        }

        private void groupControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBLFATURADETAY set URUNAD=@p1,MIKTAR=@p2,FIYAT=@p3,TUTAR=@p4 where FATURAURUNID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txturunad.Text);
            komut.Parameters.AddWithValue("@p2", txtmıktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtfıyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txttutar.Text));
            komut.Parameters.AddWithValue("@p5", txturunıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Ürün Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("DELETE FROM TBLFATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txturunıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                
            }
               

        }
    }
}
