namespace Ticarii_Otomasyonn
{
    partial class FrmRaporlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRaporlar));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TNLMUSTERILERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet1 = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSet1();
            this.TBLFIRMALARBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSet();
            this.TBLGIDERLERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet2 = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSet2();
            this.TBLPERSONELLERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet3 = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSet3();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewer6 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TBLFIRMALARTableAdapter = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSetTableAdapters.TBLFIRMALARTableAdapter();
            this.TNLMUSTERILERTableAdapter = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSet1TableAdapters.TNLMUSTERILERTableAdapter();
            this.TBLGIDERLERTableAdapter = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSet2TableAdapters.TBLGIDERLERTableAdapter();
            this.TBLPERSONELLERTableAdapter = new Ticarii_Otomasyonn.DboTicariOtomasyonDataSet3TableAdapters.TBLPERSONELLERTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TNLMUSTERILERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLFIRMALARBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLGIDERLERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLPERSONELLERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // TNLMUSTERILERBindingSource
            // 
            this.TNLMUSTERILERBindingSource.DataMember = "TNLMUSTERILER";
            this.TNLMUSTERILERBindingSource.DataSource = this.DboTicariOtomasyonDataSet1;
            // 
            // DboTicariOtomasyonDataSet1
            // 
            this.DboTicariOtomasyonDataSet1.DataSetName = "DboTicariOtomasyonDataSet1";
            this.DboTicariOtomasyonDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TBLFIRMALARBindingSource
            // 
            this.TBLFIRMALARBindingSource.DataMember = "TBLFIRMALAR";
            this.TBLFIRMALARBindingSource.DataSource = this.DboTicariOtomasyonDataSet;
            // 
            // DboTicariOtomasyonDataSet
            // 
            this.DboTicariOtomasyonDataSet.DataSetName = "DboTicariOtomasyonDataSet";
            this.DboTicariOtomasyonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TBLGIDERLERBindingSource
            // 
            this.TBLGIDERLERBindingSource.DataMember = "TBLGIDERLER";
            this.TBLGIDERLERBindingSource.DataSource = this.DboTicariOtomasyonDataSet2;
            // 
            // DboTicariOtomasyonDataSet2
            // 
            this.DboTicariOtomasyonDataSet2.DataSetName = "DboTicariOtomasyonDataSet2";
            this.DboTicariOtomasyonDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TBLPERSONELLERBindingSource
            // 
            this.TBLPERSONELLERBindingSource.DataMember = "TBLPERSONELLER";
            this.TBLPERSONELLERBindingSource.DataSource = this.DboTicariOtomasyonDataSet3;
            // 
            // DboTicariOtomasyonDataSet3
            // 
            this.DboTicariOtomasyonDataSet3.DataSetName = "DboTicariOtomasyonDataSet3";
            this.DboTicariOtomasyonDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1370, 561);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.reportViewer2);
            this.xtraTabPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.ImageOptions.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1368, 517);
            this.xtraTabPage1.Text = "Müşteri Raporları";
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TNLMUSTERILERBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Ticarii_Otomasyonn.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1368, 517);
            this.reportViewer2.TabIndex = 5;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.reportViewer3);
            this.xtraTabPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.ImageOptions.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1368, 517);
            this.xtraTabPage2.Text = "Firma Raporları";
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.TBLFIRMALARBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Ticarii_Otomasyonn.Report1.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(1368, 517);
            this.reportViewer3.TabIndex = 5;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.reportViewer5);
            this.xtraTabPage4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage4.ImageOptions.Image")));
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1368, 517);
            this.xtraTabPage4.Text = "Gider Raporları";
            // 
            // reportViewer5
            // 
            this.reportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.TBLGIDERLERBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "Ticarii_Otomasyonn.Report3.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(0, 0);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.ServerReport.BearerToken = null;
            this.reportViewer5.Size = new System.Drawing.Size(1368, 517);
            this.reportViewer5.TabIndex = 5;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.reportViewer6);
            this.xtraTabPage5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage5.ImageOptions.Image")));
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(1368, 517);
            this.xtraTabPage5.Text = "Personel Raporları";
            // 
            // reportViewer6
            // 
            this.reportViewer6.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.TBLPERSONELLERBindingSource;
            this.reportViewer6.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer6.LocalReport.ReportEmbeddedResource = "Ticarii_Otomasyonn.Report4.rdlc";
            this.reportViewer6.Location = new System.Drawing.Point(0, 0);
            this.reportViewer6.Name = "reportViewer6";
            this.reportViewer6.ServerReport.BearerToken = null;
            this.reportViewer6.Size = new System.Drawing.Size(1368, 517);
            this.reportViewer6.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(1, 43);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1368, 517);
            this.reportViewer1.TabIndex = 5;
            // 
            // TBLFIRMALARTableAdapter
            // 
            this.TBLFIRMALARTableAdapter.ClearBeforeFill = true;
            // 
            // TNLMUSTERILERTableAdapter
            // 
            this.TNLMUSTERILERTableAdapter.ClearBeforeFill = true;
            // 
            // TBLGIDERLERTableAdapter
            // 
            this.TBLGIDERLERTableAdapter.ClearBeforeFill = true;
            // 
            // TBLPERSONELLERTableAdapter
            // 
            this.TBLPERSONELLERTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 561);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmRaporlar";
            this.Text = "Raporlar";
            this.Load += new System.EventHandler(this.FrmRaporlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TNLMUSTERILERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLFIRMALARBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLGIDERLERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBLPERSONELLERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TBLFIRMALARBindingSource;
        private DboTicariOtomasyonDataSet DboTicariOtomasyonDataSet;
        private DboTicariOtomasyonDataSetTableAdapters.TBLFIRMALARTableAdapter TBLFIRMALARTableAdapter;
        private System.Windows.Forms.BindingSource TNLMUSTERILERBindingSource;
        private DboTicariOtomasyonDataSet1 DboTicariOtomasyonDataSet1;
        private DboTicariOtomasyonDataSet1TableAdapters.TNLMUSTERILERTableAdapter TNLMUSTERILERTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer6;
        private System.Windows.Forms.BindingSource TBLGIDERLERBindingSource;
        private DboTicariOtomasyonDataSet2 DboTicariOtomasyonDataSet2;
        private DboTicariOtomasyonDataSet2TableAdapters.TBLGIDERLERTableAdapter TBLGIDERLERTableAdapter;
        private System.Windows.Forms.BindingSource TBLPERSONELLERBindingSource;
        private DboTicariOtomasyonDataSet3 DboTicariOtomasyonDataSet3;
        private DboTicariOtomasyonDataSet3TableAdapters.TBLPERSONELLERTableAdapter TBLPERSONELLERTableAdapter;
    }
}