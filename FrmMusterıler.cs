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
    public partial class FrmMusterıler : Form
    {
        public FrmMusterıler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from TNLMUSTERILER", bgl.baglanti());
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
            mastelbir.Text = "";
            mastelıkı.Text = "";
            mastc.Text = "";
            txtmaıl.Text = "";
            txtvergı.Text = "";
            rcadres.Text = "";


            txtad.Focus();

        }



        private void FrmMusterıler_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
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

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TNLMUSTERILER (AD,SOYAD,TELEFON, TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mastelbir.Text);
            komut.Parameters.AddWithValue("@p4", mastelıkı.Text);
            komut.Parameters.AddWithValue("@p5", mastc.Text);
            komut.Parameters.AddWithValue("@p6", txtmaıl.Text);
            komut.Parameters.AddWithValue("@p7", cmbıl.Text);
            komut.Parameters.AddWithValue("@p8", cmbılce.Text);
            komut.Parameters.AddWithValue("@p9", rcadres.Text);
            komut.Parameters.AddWithValue("@p10", txtvergı.Text);
            
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Sisteme Eklemdi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizleme();
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
                mastelıkı.Text = dr["TELEFON2"].ToString();
                mastc.Text = dr["TC"].ToString();
                txtmaıl.Text = dr["MAIL"].ToString();
                cmbıl.Text = dr["IL"].ToString();
                cmbılce.Text = dr["ILCE"].ToString();
                txtvergı.Text = dr["VERGIDAIRE"].ToString();
                rcadres.Text = dr["ADRES"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Müşteri Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from TNLMUSTERILER where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                temizleme();

            }

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TNLMUSTERILER set AD=@p1, SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,VERGIDAIRE=@p9,ADRES=@p10 where ID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mastelbir.Text);
            komut.Parameters.AddWithValue("@p4", mastelıkı.Text);
            komut.Parameters.AddWithValue("@p5", mastc.Text);
            komut.Parameters.AddWithValue("@p6", txtmaıl.Text);
            komut.Parameters.AddWithValue("@p7", cmbıl.Text);
            komut.Parameters.AddWithValue("@p8", cmbılce.Text);
            komut.Parameters.AddWithValue("@p9", txtvergı.Text);
            komut.Parameters.AddWithValue("@p10", rcadres.Text);

            komut.Parameters.AddWithValue("@p11", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizleme();
            
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizleme();
        }
    }
}
