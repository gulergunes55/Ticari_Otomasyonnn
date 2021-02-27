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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from TBLGIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            
        }

        void gidertemizleme()
        {
            txtelektrık.Text = "";
            txtsu.Text = "";
            txtdogalgaz.Text = "";
            txtıd.Text = "";
            txtekstra.Text = "";
            txtmaaslar.Text = "";
            txtınternet.Text = "";
            rchnotlar.Text = "";
            cmbay.Text = "";
            cmbyıl.Text = "";
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderlistesi();
            gidertemizleme();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLGIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR, EKSTRA, NOTLAR)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbay.Text);
            komut.Parameters.AddWithValue("@p2", cmbyıl.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse( txtelektrık.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtınternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtmaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtekstra.Text));
            komut.Parameters.AddWithValue("@p9", rchnotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider tabloya eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistesi();
            gidertemizleme();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtıd.Text = dr["ID"].ToString();
                cmbay.Text = dr["AY"].ToString();
                cmbyıl.Text = dr["YIL"].ToString();
                txtelektrık.Text = dr["ELEKTRIK"].ToString();
                txtsu.Text = dr["SU"].ToString();
                txtdogalgaz.Text = dr["DOGALGAZ"].ToString();
                txtınternet.Text = dr["INTERNET"].ToString();
                txtmaaslar.Text = dr["MAASLAR"].ToString();
                txtekstra.Text = dr["EKSTRA"].ToString();
                rchnotlar.Text = dr["NOTLAR"].ToString();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            gidertemizleme();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Giderler Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("Delete from TBLGIDERLER where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtıd.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                giderlistesi();
                gidertemizleme();
            }
              
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand(" update TBLGIDERLER set AY=@p1, YIL=@p2,ELEKTRIK=@p3,SU=@p4,DOGALGAZ=@p5,INTERNET=@p6,MAASLAR=@p7,EKSTRA=@p8,NOTLAR=@p9 where ID=@p10" , bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", cmbay.Text);
            komutguncelle.Parameters.AddWithValue("@p2", cmbyıl.Text);
            komutguncelle.Parameters.AddWithValue("@p3", decimal.Parse(txtelektrık.Text));
            komutguncelle.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            komutguncelle.Parameters.AddWithValue("@p5", decimal.Parse(txtdogalgaz.Text));
            komutguncelle.Parameters.AddWithValue("@p6", decimal.Parse(txtınternet.Text));
            komutguncelle.Parameters.AddWithValue("@p7", decimal.Parse(txtmaaslar.Text));
            komutguncelle.Parameters.AddWithValue("@p8", decimal.Parse(txtekstra.Text));
            komutguncelle.Parameters.AddWithValue("@p9", rchnotlar.Text);
            komutguncelle.Parameters.AddWithValue("@p10", txtıd.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider tablosu Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            giderlistesi();
            gidertemizleme();
        }
    }
}
