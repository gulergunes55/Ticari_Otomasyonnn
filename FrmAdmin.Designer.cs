namespace Ticarii_Otomasyonn
{
    partial class FrmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.txtkullaniciad = new DevExpress.XtraEditors.TextEdit();
            this.txtsıfre = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btngırısyap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtkullaniciad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsıfre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(82, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // txtkullaniciad
            // 
            this.txtkullaniciad.Location = new System.Drawing.Point(179, 21);
            this.txtkullaniciad.Name = "txtkullaniciad";
            this.txtkullaniciad.Properties.Appearance.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkullaniciad.Properties.Appearance.Options.UseFont = true;
            this.txtkullaniciad.Size = new System.Drawing.Size(146, 24);
            this.txtkullaniciad.TabIndex = 1;
            // 
            // txtsıfre
            // 
            this.txtsıfre.Location = new System.Drawing.Point(179, 51);
            this.txtsıfre.Name = "txtsıfre";
            this.txtsıfre.Properties.Appearance.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsıfre.Properties.Appearance.Options.UseFont = true;
            this.txtsıfre.Properties.UseSystemPasswordChar = true;
            this.txtsıfre.Size = new System.Drawing.Size(146, 24);
            this.txtsıfre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(134, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifre:";
            // 
            // btngırısyap
            // 
            this.btngırısyap.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btngırısyap.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngırısyap.Location = new System.Drawing.Point(208, 81);
            this.btngırısyap.Name = "btngırısyap";
            this.btngırısyap.Size = new System.Drawing.Size(88, 34);
            this.btngırısyap.TabIndex = 4;
            this.btngırısyap.Text = "Giriş Yap";
            this.btngırısyap.UseVisualStyleBackColor = false;
            this.btngırısyap.Click += new System.EventHandler(this.btngırısyap_Click);
            this.btngırısyap.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.btngırısyap.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(111, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "GÜLER GÜNEŞ TİCARİ OTOMASYON 2021";
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(507, 272);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btngırısyap);
            this.Controls.Add(this.txtsıfre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtkullaniciad);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.txtkullaniciad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsıfre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtkullaniciad;
        private DevExpress.XtraEditors.TextEdit txtsıfre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btngırısyap;
        private System.Windows.Forms.Label label3;
    }
}