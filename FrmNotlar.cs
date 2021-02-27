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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select* from TBLNOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizleme()
        {
            txtbaslık.Text = "";
            txthitap.Text = "";
            txtoluşturan.Text = "";
            txtıd.Text = "";
            massaat.Text = "";
            mastarıh.Text = "";
            rcdetay.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizleme();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLNOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mastarıh.Text);
            komut.Parameters.AddWithValue("@p2", massaat.Text);
            komut.Parameters.AddWithValue("@p3", txtbaslık.Text);
            komut.Parameters.AddWithValue("@p4", rcdetay.Text);
            komut.Parameters.AddWithValue("@p5", txtoluşturan.Text);
            komut.Parameters.AddWithValue("@p6", txthitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizleme();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr !=null)
            {
                txtıd.Text = dr["ID"].ToString();
                txtbaslık.Text = dr["TARIH"].ToString();
                txthitap.Text = dr["HITAP"].ToString();
                txtoluşturan.Text = dr["OLUSTURAN"].ToString();
                massaat.Text = dr["SAAT"].ToString();
                mastarıh.Text = dr["TARIH"].ToString();
                rcdetay.Text = dr["DETAY"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Not Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {

                SqlCommand komut = new SqlCommand("DELETE from TBLNOTLAR where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                temizleme();

            }

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizleme();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBLNOTLAR set TARIH=@p1,SAAT=@p2,BASLIK=@p3,DETAY=@p4,OLUSTURAN=@p5,HITAP=@p6 where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mastarıh.Text);
            komut.Parameters.AddWithValue("@p2", massaat.Text);
            komut.Parameters.AddWithValue("@p3", txtbaslık.Text);
            komut.Parameters.AddWithValue("@p4", rcdetay.Text);
            komut.Parameters.AddWithValue("@p5", txtoluşturan.Text);
            komut.Parameters.AddWithValue("@p6", txthitap.Text);
            komut.Parameters.AddWithValue("@p7", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizleme();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr!= null)
            {
                fr.metin = dr["DETAY"].ToString();
            }
            fr.Show();
        }
    }
}
