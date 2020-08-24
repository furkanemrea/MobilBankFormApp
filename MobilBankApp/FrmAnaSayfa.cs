using MobilBankApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilBankApp
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        Model1 m = new Model1();
        public string TcNo = "68745965214";
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            getBilgi();
            girisMesaj();
            Sinav();
        }

        void Sinav()
        {
            var musteri = m.Musteri.Where(x => x.Bakiye > 100).FirstOrDefault();
            lblMesaj.Text = musteri.Ad;
        }
        void girisMesaj()
        {
            Random rnd = new Random();
            int sayi = rnd.Next(1,5);
            var degerler = m.GirisMesaj.Find(sayi);
            lblMesaj.Text=degerler.Mesaj;
            
        }
        int MusteriId;
        void getBilgi()
        {
            


            
            var musterim = m.Musteri.Where(x => x.KimlikNo.Equals(TcNo) && x.Aktif==true).FirstOrDefault();
            lblAd.Text= musterim.Ad;
            lblSoyad.Text = musterim.Soyad;
            MusteriId = musterim.Id;
            lblKimlikNo.Text = musterim.KimlikNo;
            lblTelefon.Text = musterim.TelefonNumarasi;
            lblMusteriMail.Text = musterim.Mail;

            var sehir = m.Sehir.Where(x => x.Id == musterim.Sehir).FirstOrDefault();
            lblSube.Text = sehir.Ad;
            

            var IbanBul = m.Hesap.Where(x => x.MusteriId == MusteriId && x.Aktif==true).FirstOrDefault();

            lblIban.Text=IbanBul.IBAN;

            var bakiyem = m.Hesap.Where(x => x.MusteriId == MusteriId && x.Aktif==true).Sum(y => y.Bakiye).ToString();
            lblBakiye.Text = bakiyem;

        }

        private void lblSube_Click(object sender, EventArgs e)
        {

        }

        private void lblTelefon_Click(object sender, EventArgs e)
        {

        }

        private void lblMusteriMail_Click(object sender, EventArgs e)
        {

        }

        private void lblKimlikNo_Click(object sender, EventArgs e)
        {

        }

        private void lblIban_Click(object sender, EventArgs e)
        {

        }

        private void lblBakiye_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmHesaplar h = new FrmHesaplar();
            h.MusteriId = MusteriId;
            h.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            FrmFatura f = new FrmFatura();
            f.MusteriId = MusteriId;
            f.ShowDialog();
            getBilgi();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random rnd = new Random();
            int sayi=rnd.Next(1,5);
          var mesajlar=  m.YardimMesaj.Find(sayi);

            MessageBox.Show(mesajlar.Mesaj,"Bilgi");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            FrmSigortalar f = new FrmSigortalar();
            f.MusteriId = MusteriId;
            f.ShowDialog();
            getBilgi();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmParaTransfer f = new FrmParaTransfer();
            f.MusteriId = MusteriId;
            f.ShowDialog();
            getBilgi();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmKredi f = new FrmKredi();
            f.MusteriId = MusteriId;
            f.ShowDialog();
        }
    }
 
}
