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
using DevExpress.Charts;
namespace Ticarii_Otomasyonn
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void musterıhareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusterıHareketler ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void giderlistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from TBLGIDERLER", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }
        void firmahareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(" Execute  FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }
        public string ad;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lbkaktıf.Text = ad;
            musterıhareket();
            firmahareket();
            giderlistele();
            //toplam tutarı hesaplama

            SqlCommand komut1 = new SqlCommand("select sum(TUTAR) from TBLFATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltplmtutar.Text = dr1[0].ToString() + " TL ";
            }
            bgl.baglanti().Close();

            //SON AYIN FATURALARI 
            SqlCommand komut2 = new SqlCommand("SELECT (ELEKTRIK+SU+DOGALGAZ) FROM TBLGIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblodemeler.Text = dr2[0].ToString() + " TL ";
            }
            bgl.baglanti().Close();

            //son ayın personel maaşları 

            SqlCommand komut3 = new SqlCommand("select(MAASLAR) FROM TBLGIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblpsnl.Text = dr3[0].ToString() + " TL ";
            }
            bgl.baglanti().Close();

            // MÜŞTERİ SAYISI

            SqlCommand komut4 = new SqlCommand("select Count(*) From TNLMUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblmuster.Text = dr4[0].ToString() + " Kişi ";
            }
            bgl.baglanti().Close();

            // FİRMA SAYISI

            SqlCommand komut5 = new SqlCommand("select Count(*) From TBLFIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblfırma.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            // FİRMA ŞEHİR SAYISI

            SqlCommand komut6 = new SqlCommand("select Count(Distinct(IL)) From TBLFIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblsehır.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            // MÜŞTERİ ŞEHİR SAYISI

            SqlCommand komut7 = new SqlCommand("select Count(Distinct(IL)) From TNLMUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblshr2.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            // PERSONEL SAYISI

            SqlCommand komut8 = new SqlCommand("select Count(*) From TBLPERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblper.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            // STOK SAYISI

            SqlCommand komut9 = new SqlCommand("select SUM(ADET) From TBLURUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblstok.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();



        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void groupControl10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac > 0 && sayac <= 5)
            {
                // CHART CONTROLE ELEKTRIK FATURASI SON 4 AY LİSTELEME
                groupControl10.Text = "Elektrık";
                SqlCommand komut10 = new SqlCommand("select top 4 AY,ELEKTRIK FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();


            }
            //su
            if (sayac > 5 && sayac <= 10)
            {
                groupControl10.Text = "Su";

                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,SU FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();

            }
            //doğalgaz
            if (sayac > 11 && sayac <= 15)
            {
                groupControl10.Text = "Doğalgaz";

                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,DOGALGAZ FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //internet
            if (sayac > 16 && sayac <= 20)
            {
                groupControl10.Text = "İnternet";

                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,INTERNET FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //ekstra
            if (sayac > 21 && sayac <= 26)
            {
                groupControl10.Text = "Ekstra";

                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,EKSTRA FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac == 26)
            {
                sayac = 0;
            }
        }

        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            if (sayac2 > 0 && sayac2 <= 5)
            {
                // CHART CONTROLE ELEKTRIK FATURASI SON 4 AY LİSTELEME
                groupControl12.Text = "Elektrık";
                SqlCommand komut10 = new SqlCommand("select top 4 AY,ELEKTRIK FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();


            }
            //su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl12.Text = "Su";

                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,SU FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();

            }
            //doğalgaz
            if (sayac2 > 11 && sayac2 <= 15)
            {
                groupControl12.Text = "Doğalgaz";

                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,DOGALGAZ FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //internet
            if (sayac2 > 16 && sayac2 <= 20)
            {
                groupControl12.Text = "İnternet";

                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,INTERNET FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //ekstra
            if (sayac2 > 21 && sayac2 <= 26)
            {
                groupControl12.Text = "Ekstra";

                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 4 AY,EKSTRA FROM TBLGIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}


