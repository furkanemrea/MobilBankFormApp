using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobilBankApp.Entity;
namespace MobilBankApp
{
    public partial class FrmYeniHesap : Form
    {
        public FrmYeniHesap()
        {
            InitializeComponent();
        }
        public int MusteriID;
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmHesaplar h =new FrmHesaplar();
            h.Show();
        }

        private void FrmYeniHesap_Load(object sender, EventArgs e)
        {

        }
        Model1 m = new Model1();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string IbanOlustur = "1515";
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                int sayi = rnd.Next(1000, 9999);


                IbanOlustur += sayi.ToString();
            }

            Hesap h = new Hesap();
            h.MusteriId = MusteriID;
            h.IBAN = IbanOlustur;
            h.Bakiye = 0;
            h.Aktif = true;
            h.HesapAdi = txtHesapAdi.Text;
            m.Hesap.Add(h);
            m.SaveChanges();
            MessageBox.Show("Yeni Hesap Oluşturuldu","Bilgi");

            this.Close();

        }
    }
}
