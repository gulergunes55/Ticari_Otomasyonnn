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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void personelliste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLPERSONELLER ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("select*from TBLILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbıl.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        void temizleme()
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            mastelbir.Text= "";
            mastc.Text = "";
            txtmaıl.Text = "";
            rcadres.Text = "";
            txtgorev.Text = "";
            txtad.Focus();

        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personelliste();
            sehirlistesi();
            temizleme();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLPERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mastelbir.Text);
            komut.Parameters.AddWithValue("@p4", mastc.Text);
            komut.Parameters.AddWithValue("@p5", txtmaıl.Text);
            komut.Parameters.AddWithValue("@p6", cmbıl.Text);
            komut.Parameters.AddWithValue("@p7", cmbılce.Text);
            komut.Parameters.AddWithValue("@p8", rcadres.Text);
            komut.Parameters.AddWithValue("@p9", txtgorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Sisteme Eklemdi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();
            temizleme();
        }

        private void cmbıl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbılce.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("select ILCE from TBLILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbıl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbılce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtıd.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtsoyad.Text = dr["SOYAD"].ToString();
                mastelbir.Text = dr["TELEFON"].ToString();
                mastc.Text = dr["TC"].ToString();
                txtmaıl.Text = dr["MAIL"].ToString();
                cmbıl.Text = dr["IL"].ToString();
                cmbılce.Text = dr["ILCE"].ToString();
                txtgorev.Text = dr["GOREV"].ToString();
                rcadres.Text = dr["ADRES"].ToString();

            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizleme();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Personel Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("DELETE from TBLPERSONELLER where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                personelliste();
                temizleme();
            }
                
           
        


        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBLPERSONELLER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mastelbir.Text);
            komut.Parameters.AddWithValue("@p4", mastc.Text);
            komut.Parameters.AddWithValue("@p5", txtmaıl.Text);
            komut.Parameters.AddWithValue("@p6", cmbıl.Text);
            komut.Parameters.AddWithValue("@p7", cmbılce.Text);
            komut.Parameters.AddWithValue("@p8", rcadres.Text);
            komut.Parameters.AddWithValue("@p9", txtgorev.Text);
            komut.Parameters.AddWithValue("@p10", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personelliste();
            temizleme();

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
