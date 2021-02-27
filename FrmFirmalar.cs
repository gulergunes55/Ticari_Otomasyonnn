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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void firmalistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select* from TBLFIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizleme()
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtyetgorev.Text = "";
            txtyetkili.Text = "";
            mastc.Text = "";
            txtsektor.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            msktel3.Text = "";
            txtmaıl.Text = "";
            mskfax.Text = "";
            txtvergı.Text = "";
            rchadres.Text = "";
            txtkod1.Text = "";
            txtkod2.Text = "";
            txtkod3.Text = "";
            
            txtad.Focus();

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

        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("select FIRMAKOD1 from TBLKODLAR",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchkod1.Text = dr[0].ToString();

            }
            bgl.baglanti().Close();

        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmalistele();

            temizleme();

            sehirlistesi();
            carikodaciklamalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtıd.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtyetgorev.Text = dr["YETKILISTATU"].ToString();
                txtyetkili.Text = dr["YETKILIADSOYAD"].ToString();
                mastc.Text = dr["YETKILITC"].ToString();
                txtsektor.Text = dr["SEKTOR"].ToString();
                msktel1.Text = dr["TELEFON1"].ToString();
                msktel2.Text = dr["TELEFON2"].ToString();
                msktel3.Text = dr["TELEFON3"].ToString();
                txtmaıl.Text = dr["MAIL"].ToString();
                mskfax.Text = dr["FAX"].ToString();
                cmbıl.Text = dr["IL"].ToString();
                cmbılce.Text = dr["ILCE"].ToString();
                txtvergı.Text = dr["VERGIDAIRE"].ToString();
                rchadres.Text = dr["ADRES"].ToString();
                txtkod1.Text = dr["OZELKOD1"].ToString();
                txtkod2.Text = dr["OZELKOD2"].ToString();
                txtkod3.Text = dr["OZELKOD3"].ToString();

            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLFIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtyetgorev.Text);
            komut.Parameters.AddWithValue("@p3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", mastc.Text);
            komut.Parameters.AddWithValue("@p5", txtsektor.Text);
            komut.Parameters.AddWithValue("@p6", msktel1.Text);
            komut.Parameters.AddWithValue("@p7", msktel2.Text);
            komut.Parameters.AddWithValue("@p8", msktel3.Text);
            komut.Parameters.AddWithValue("@p9", txtmaıl.Text);
            komut.Parameters.AddWithValue("@p10", mskfax.Text);
            komut.Parameters.AddWithValue("@p11", cmbıl.Text);
            komut.Parameters.AddWithValue("@p12", cmbılce.Text);
            komut.Parameters.AddWithValue("@p13", txtvergı.Text);
            komut.Parameters.AddWithValue("@p14", rchadres.Text);
            komut.Parameters.AddWithValue("@p15", txtkod1.Text);
            komut.Parameters.AddWithValue("@p16", txtkod2.Text);
            komut.Parameters.AddWithValue("@p17", txtkod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistele();
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

        private void btnsil_Click(object sender, EventArgs e)
        {
            {
                DialogResult secim = new DialogResult();
                secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Firma Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (secim == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand(" Delete from TBLFIRMALAR where ID=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", txtıd.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    firmalistele();
                    temizleme();
                }


            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBLFIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5,TELEFON1=@p6,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9,FAX=@p10,IL=@p11,ILCE=@p12,VERGIDAIRE=@p13,ADRES=@p14,OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17 where ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtyetgorev.Text);
            komut.Parameters.AddWithValue("@p3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", mastc.Text);
            komut.Parameters.AddWithValue("@p5", txtsektor.Text);
            komut.Parameters.AddWithValue("@p6", msktel1.Text);
            komut.Parameters.AddWithValue("@p7", msktel2.Text);
            komut.Parameters.AddWithValue("@p8", msktel3.Text);
            komut.Parameters.AddWithValue("@p9", txtmaıl.Text);
            komut.Parameters.AddWithValue("@p10", mskfax.Text);
            komut.Parameters.AddWithValue("@p11", cmbıl.Text);
            komut.Parameters.AddWithValue("@p12", cmbılce.Text);
            komut.Parameters.AddWithValue("@p13", txtvergı.Text);
            komut.Parameters.AddWithValue("@p14", rchadres.Text);
            komut.Parameters.AddWithValue("@p15", txtkod1.Text);
            komut.Parameters.AddWithValue("@p16", txtkod2.Text);
            komut.Parameters.AddWithValue("@p17", txtkod3.Text);
            komut.Parameters.AddWithValue("@p18", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Güncelledi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistele();
            temizleme();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizleme();
        }
    }
}
