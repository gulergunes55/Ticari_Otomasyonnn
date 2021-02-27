using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace Ticarii_Otomasyonn
{
    public partial class FrmMaıl : Form
    {
        public FrmMaıl()
        {
            InitializeComponent();
        }
        public string maıl;

        private void FrmMaıl_Load(object sender, EventArgs e)
        {
          txtmaıladres.Text = maıl;
        }

        private void btngonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesajim.To.Add(txtmaıladres.Text);
            mesajim.From = new MailAddress("Mail");
            mesajim.Subject = txtkonu.Text;
            mesajim.Body = rchmesaj.Text;
            istemci.Send (mesajim);
        }
    }
}
