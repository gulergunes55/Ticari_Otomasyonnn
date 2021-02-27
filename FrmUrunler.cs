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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from TBLURUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizleme()
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtmatka.Text = "";
            txtad.Text = "";
            txtmodel.Text = "";
            masyıl.Text = "";
            nutadet.Text = "";
            txtalıs.Text = "";
            txtsatıs.Text = "";
            rchdetay.Text = "";


            txtad.Focus();

        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            temizleme();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //Ürün Kaydetme
            SqlCommand komut = new SqlCommand("insert into TBLURUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtmatka.Text);
            komut.Parameters.AddWithValue("@p3", txtmodel.Text);
            komut.Parameters.AddWithValue("@p4", masyıl.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nutadet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtalıs.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtsatıs.Text));
            komut.Parameters.AddWithValue("@p8", rchdetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
           temizleme();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            // Silme İşlemi

            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Ürün Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {

                SqlCommand komutsil = new SqlCommand("Delete from TBLURUNLER where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtıd.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                temizleme();
            }

           
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // gridden araçlara taşıma
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtıd.Text = dr["ID"].ToString();
            txtad.Text = dr["URUNAD"].ToString();
            txtmatka.Text = dr["MARKA"].ToString();
            txtmodel.Text = dr["MODEL"].ToString();
            masyıl.Text = dr["YIL"].ToString();
            nutadet.Value = decimal.Parse(dr["ADET"].ToString());
            txtalıs.Text = dr["ALISFIYAT"].ToString();
            txtsatıs.Text = dr["SATISFIYAT"].ToString();
            rchdetay.Text = dr["DETAY"].ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLURUNLER set URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7, DETAY=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtmatka.Text);
            komut.Parameters.AddWithValue("@p3", txtmodel.Text);
            komut.Parameters.AddWithValue("@p4", masyıl.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nutadet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtalıs.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtsatıs.Text));
            komut.Parameters.AddWithValue("@p8", rchdetay.Text);
            komut.Parameters.Add("@p9", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizleme();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizleme();
        }
    }
}
