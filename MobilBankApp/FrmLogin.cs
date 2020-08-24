
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string TcNo;
        public int sifre;
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
        Model1 m = new Model1();
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                var degerler = m.Musteri.Where(x => x.KimlikNo == txtTcNo.Text && x.Sifre == txtSifre.Text).FirstOrDefault();
                if (degerler!=null)
                {
                    if (degerler.KimlikNo == txtTcNo.Text && degerler.Sifre == txtSifre.Text)
                    {
                        TcNo = txtTcNo.Text;
                        Random rnd = new Random();
                        sifre = rnd.Next(1000, 9999);
                        MailMessage mail = new MailMessage();
                        SmtpClient client = new SmtpClient();
                        client.Credentials = new System.Net.NetworkCredential("onaybank@gmail.com", "Onaybank321.");
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;

                        mail.To.Add(degerler.Mail.ToString());
                        mail.From = new MailAddress("onaybank@gmail.com");
                        mail.Subject = "Onaylama Kodu";
                        mail.Body = "Sayın ," + " " + degerler.Ad + " " + degerler.Soyad + " " + " Tek kullanımlık Şifreniz :" + sifre.ToString();
                        client.Send(mail);

                        FrmLoginKontrol f = new FrmLoginKontrol();
                        f.sifre = sifre;
                        f.TcNo = TcNo;
                        this.Hide();

                        f.Show();

                    }
                    
                }
                else
                {
                    MessageBox.Show("T.C Kimlik Numaranız ile Şifreniz Eşleşmiyor .", "Uyarı");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifremiUnuttum frm = new FrmSifremiUnuttum();
            frm.Show();
            this.Hide();
        }

        private void linkLabelUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUyeOl frm = new FrmUyeOl();
            this.Hide();
            frm.Show();
            
        }
        int sayac = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            sayac++;
            if (sayac%2==1)
            {
                txtSifre.UseSystemPasswordChar = true;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = false;
            }
        }
    }
}
