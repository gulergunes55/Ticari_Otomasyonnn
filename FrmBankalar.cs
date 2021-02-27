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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void bankalistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute Bankabilgisi", bgl.baglanti());
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

        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD from TBLFIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;

           
        }
        void temizleme()
        {
            txtbankaad.Text = "";
            txthesapno.Text = "";
            txthesapturu.Text = "";
            txtsube.Text = "";
            txtyetkılı.Text = "";
            txtıban.Text = "";
            txtıd.Text = "";
            mastarıh.Text = "";
            mastelefon.Text = "";
            lookUpEdit1.Text = "";
            cmbıl.Text = "";
            cmbılce.Text = "";
        }


        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            bankalistele();
            sehirlistesi();
            firmalistesi();
            temizleme();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLBANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbankaad.Text);
            komut.Parameters.AddWithValue("@p2", cmbıl.Text);
            komut.Parameters.AddWithValue("@p3", cmbılce.Text);
            komut.Parameters.AddWithValue("@p4", txtsube.Text);
            komut.Parameters.AddWithValue("@p5", txtıban.Text);
            komut.Parameters.AddWithValue("@p6", txthesapno.Text);
            komut.Parameters.AddWithValue("@p7", txtyetkılı.Text);
            komut.Parameters.AddWithValue("@p8", mastelefon.Text);
            komut.Parameters.AddWithValue("@p9", mastarıh.Text);
            komut.Parameters.AddWithValue("@p10", txthesapturu.Text);
            komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bankalistele();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtbankaad.Text = dr["BANKAADI"].ToString();
                cmbıl.Text = dr["IL"].ToString();
                cmbılce.Text = dr["ILCE"].ToString();
                txtsube.Text = dr["SUBE"].ToString();
                txtıban.Text = dr["IBAN"].ToString();
                txthesapno.Text = dr["HESAPNO"].ToString();
                txtyetkılı.Text = dr["YETKILI"].ToString();
                mastelefon.Text = dr["TELEFON"].ToString();                
                mastarıh.Text = dr["TARIH"].ToString();
                txthesapturu.Text = dr["HESAPTURU"].ToString();
                //lookUpEdit1.Text = dr["FIRMAID"].ToString();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizleme();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Silmek istediğinize Emin misiniz?", "Banka Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (secim == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from TBLBANKALAR where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                bankalistele();
                temizleme();
            }
                
          

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLBANKALAR set BANKAADI=@p1,IL=@p2,ILCE=@p3,SUBE=@p4,IBAN=@p5,HESAPNO=@p6,YETKILI=@p7,TELEFON=@p8,TARIH=@p9,HESAPTURU=@p10,FIRMAID=@p11 where ID=@p12" , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbankaad.Text);
            komut.Parameters.AddWithValue("@p2", cmbıl.Text);
            komut.Parameters.AddWithValue("@p3", cmbılce.Text);
            komut.Parameters.AddWithValue("@p4", txtsube.Text);
            komut.Parameters.AddWithValue("@p5", txtıban.Text);
            komut.Parameters.AddWithValue("@p6", txthesapno.Text);
            komut.Parameters.AddWithValue("@p7", txtyetkılı.Text);
            komut.Parameters.AddWithValue("@p8", mastelefon.Text);
            komut.Parameters.AddWithValue("@p9", mastarıh.Text);
            komut.Parameters.AddWithValue("@p10", txthesapturu.Text);
            komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            komut.Parameters.AddWithValue("@p12", txtıd.Text);
            komut.ExecuteNonQuery();
            bankalistele();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
