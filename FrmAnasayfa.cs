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
using System.Xml;

namespace Ticarii_Otomasyonn
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,SUM(ADET) AS'adet' FROM TBLURUNLER GROUP BY URUNAD HAVING SUM(ADET) <= 20 ORDER BY SUM(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridcontrolstoklar.DataSource = dt;
;        }
       
        void ajanda()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select TOP 10 TARIH,SAAT,BASLIK from TBLNOTLAR ORDER BY ID DESC", bgl.baglanti());
            da2.Fill(dt2);
            gridControlajanda.DataSource = dt2;
        }
        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FırmaHareket2", bgl.baglanti());
            da.Fill(dt);
            gridControlfirmahareket.DataSource = dt;

        }
        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 from TBLFIRMALAR ORDER BY AD ASC", bgl.baglanti());
            da.Fill(dt);
            gridControlfihrist.DataSource = dt;
        }
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }

        }
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            FirmaHareketleri();
            fihrist();
            haberler();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
