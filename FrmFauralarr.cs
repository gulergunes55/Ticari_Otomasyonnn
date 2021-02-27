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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLFATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void faturatemızle()
        {
            txxserı.Text = "";
            txtsıra.Text = "";
            mastarıh.Text = "";
            massaat.Text = "";
            txtvergıdaıre.Text = "";
            txtalıcı.Text = "";
            txtteslımeden.Text = "";
            txtteslımalan.Text = "";
            txtıd.Text = "";
        }
       

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            faturatemızle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)

        {
            //firma carisi
            if (txtfaturaıd.Text == "" && comboBox1.Text == "Firma")
            {
                SqlCommand komut = new SqlCommand("insert into TBLFATURABILGI(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txxserı.Text);
                komut.Parameters.AddWithValue("@p2", txtsıra.Text);
                komut.Parameters.AddWithValue("@p3", mastarıh.Text);
                komut.Parameters.AddWithValue("@p4", massaat.Text);
                komut.Parameters.AddWithValue("@p5", txtvergıdaıre.Text);
                komut.Parameters.AddWithValue("@p6", txtalıcı.Text);
                komut.Parameters.AddWithValue("@p7", txtteslımeden.Text);
                komut.Parameters.AddWithValue("@p8", txtteslımalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                faturatemızle();
            }
            if (txtfaturaıd.Text != "")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfıyat.Text);
                miktar = Convert.ToDouble(txtmıktar.Text);
                tutar = miktar * fiyat;
                txttutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBLFATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURID) values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txturunad.Text);
                komut2.Parameters.AddWithValue("@p2", txtmıktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(txtfıyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(txttutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtfaturaıd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //hareket tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("insert into TBLFIRMAHAREKETLER(URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txturunıd.Text);
                komut3.Parameters.AddWithValue("@h2", txtmıktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtpersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtfırma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtfıyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txttutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtfaturaıd.Text);
                komut3.Parameters.AddWithValue("@h8", mastarıh.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //stok sayısını azaltma
                SqlCommand komut4 = new SqlCommand("update TBLURUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtmıktar.Text);
                komut4.Parameters.AddWithValue("@s2", txturunıd.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();


            }
            //Müşteri carisi
            if (txtfaturaıd.Text == "" && comboBox1.Text == "Müşteri")
            {
                SqlCommand komut = new SqlCommand("insert into TBLFATURABILGI(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txxserı.Text);
                komut.Parameters.AddWithValue("@p2", txtsıra.Text);
                komut.Parameters.AddWithValue("@p3", mastarıh.Text);
                komut.Parameters.AddWithValue("@p4", massaat.Text);
                komut.Parameters.AddWithValue("@p5", txtvergıdaıre.Text);
                komut.Parameters.AddWithValue("@p6", txtalıcı.Text);
                komut.Parameters.AddWithValue("@p7", txtteslımeden.Text);
                komut.Parameters.AddWithValue("@p8", txtteslımalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                faturatemızle();
            }
            if (txtfaturaıd.Text != "")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfıyat.Text);
                miktar = Convert.ToDouble(txtmıktar.Text);
                tutar = miktar * fiyat;
                txttutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBLFATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURID) values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txturunad.Text);
                komut2.Parameters.AddWithValue("@p2", txtmıktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(txtfıyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(txttutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtfaturaıd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //hareket tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("insert into  TBLMUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txturunıd.Text);
                komut3.Parameters.AddWithValue("@h2", txtmıktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtpersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtfırma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtfıyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txttutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtfaturaıd.Text);
                komut3.Parameters.AddWithValue("@h8", mastarıh.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //stok sayısını azaltma
                SqlCommand komut4 = new SqlCommand("update TBLURUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtmıktar.Text);
                komut4.Parameters.AddWithValue("@s2", txturunıd.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();


                MessageBox.Show("Fatura Detay Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                faturatemızle();

            }
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtıd.Text = dr["FATURABILGIID"].ToString();
                txxserı.Text = dr["SERI"].ToString();
                txtsıra.Text = dr["SIRANO"].ToString();
                mastarıh.Text = dr["TARIH"].ToString();
                massaat.Text = dr["SAAT"].ToString();
                txtvergıdaıre.Text = dr["VERGIDAIRE"].ToString();
                txtalıcı.Text = dr["ALICI"].ToString();
                txtteslımeden.Text = dr["TESLIMEDEN"].ToString();
                txtteslımalan.Text = dr["TESLIMALAN"].ToString();
                

            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            faturatemızle();
        }

      

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Fatura Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from TBLFATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                faturatemızle();

            }
                
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(" UPDATE TBLFATURABILGI set SERI=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRE=@p5,ALICI=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 where FATURABILGIID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txxserı.Text);
            komut.Parameters.AddWithValue("@p2", txtsıra.Text);
            komut.Parameters.AddWithValue("@p3", mastarıh.Text);
            komut.Parameters.AddWithValue("@p4", massaat.Text);
            komut.Parameters.AddWithValue("@p5", txtvergıdaıre.Text);
            komut.Parameters.AddWithValue("@p6", txtalıcı.Text);
            komut.Parameters.AddWithValue("@p7", txtteslımeden.Text);
            komut.Parameters.AddWithValue("@p8", txtteslımalan.Text);
            komut.Parameters.AddWithValue("@p9", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            faturatemızle();

        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            faturatemızle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void groupControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select URUNAD,SATISFIYAT FROM TBLURUNLER WHERE ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txturunıd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txturunad.Text = dr[0].ToString();
                txtfıyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }
    }    
}
