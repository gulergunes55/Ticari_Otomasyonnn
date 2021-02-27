using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticarii_Otomasyonn
{
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet3.TBLPERSONELLER' table. You can move, or remove it, as needed.
            this.TBLPERSONELLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet3.TBLPERSONELLER);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet2.TBLGIDERLER' table. You can move, or remove it, as needed.
            this.TBLGIDERLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet2.TBLGIDERLER);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet1.TNLMUSTERILER' table. You can move, or remove it, as needed.
            this.TNLMUSTERILERTableAdapter.Fill(this.DboTicariOtomasyonDataSet1.TNLMUSTERILER);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet.TBLFIRMALAR' table. You can move, or remove it, as needed.
            this.TBLFIRMALARTableAdapter.Fill(this.DboTicariOtomasyonDataSet.TBLFIRMALAR);

            // this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
           // this.reportViewer4.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
           // this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
            this.reportViewer6.RefreshReport();
        }
    }
}
