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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD,SUM(ADET) as 'MİKTAR' FROM TBLURUNLER GROUP BY URUNAD ", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            // FİRMA ŞEHİR LİSTELE

            SqlDataAdapter da3 = new SqlDataAdapter("Select IL,Count(*) From TBLFIRMALAR Group By IL ", bgl.baglanti());
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            gridControl2.DataSource = dt3;

            // charta ürün miktarı çekme

            SqlCommand komut = new SqlCommand("SELECT URUNAD,SUM(ADET) as 'MİKTAR' FROM TBLURUNLER GROUP BY URUNAD ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();

            // charta firma şehir sayısı çekme

            SqlCommand komut2 = new SqlCommand("Select IL,Count(*) From TBLFIRMALAR Group By IL", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            bgl.baglanti().Close();

;        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           Frmstokdetay fr = new Frmstokdetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.ad = dr["URUNAD"].ToString();
            }
            fr.Show();
        }
    }   
}
