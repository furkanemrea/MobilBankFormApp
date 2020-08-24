using MobilBankApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilBankApp
{
    public partial class FrmSifremiUnuttum : Form
    {
        public FrmSifremiUnuttum()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            this.Hide();
        }
        Model1 m = new Model1();
        int yeniSifre;
        private void btnSifreAl_Click(object sender, EventArgs e)
        {
            try
            {
                var degerler = m.Musteri.Where(x => x.KimlikNo == txtTcNo.Text && x.Mail == txtMailAdresi.Text).FirstOrDefault();
                if (degerler.KimlikNo == txtTcNo.Text && degerler.Mail == txtMailAdresi.Text)
                {
                    Random rnd = new Random();
                    yeniSifre = rnd.Next(1000, 99999);
                    MailMessage mail = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("onaybank@gmail.com", "Onaybank321.");
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;

                    mail.To.Add(degerler.Mail.ToString());
                    mail.From = new MailAddress("onaybank@gmail.com");
                    mail.Subject = "Onaylama Kodu";
                    mail.Body = "Sayın ," + " " + degerler.Ad + " " + degerler.Soyad + " " + " Yeni Şifreniz :" + yeniSifre.ToString();
                    client.Send(mail);

                    degerler.Sifre = yeniSifre.ToString();
                    m.SaveChanges();

                    MessageBox.Show("Yeni Şifreniz Mail Adresinize Gönderilmiştir","Bilgi");

                    

                   

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
