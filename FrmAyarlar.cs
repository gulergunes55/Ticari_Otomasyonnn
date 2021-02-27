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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select* from TBLADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (btnkaydet.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBLADMIN(KullaniciAd,Sifre)values(@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtkullanici.Text);
                komut.Parameters.AddWithValue("@p2", txtsifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni Admin Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                txtkullanici.Text = "";
                txtsifre.Text = "";
            }
            if (btnkaydet.Text == "Güncelle")
            {
                SqlCommand komut2 = new SqlCommand("Update TBLADMIN set Sifre=@p2 where KullaniciAd=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtkullanici.Text);
                komut2.Parameters.AddWithValue("@p2", txtsifre.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Admin Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
                txtkullanici.Text = "";
                txtsifre.Text = "";

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtkullanici.Text = dr["KullaniciAd"].ToString();
                txtsifre.Text = dr["Sifre"].ToString();
            }
        }

        private void txtkullanici_TextChanged(object sender, EventArgs e)
        {
            if(txtkullanici.Text != "")
            {
                btnkaydet.Text = "Güncelle";
                btnkaydet.BackColor = Color.Green;
            }

            else
            {
                btnkaydet.Text = "Kaydet";
                btnkaydet.BackColor = Color.Teal;
            }
        }
    }
}

    
    

