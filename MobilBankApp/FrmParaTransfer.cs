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
    public partial class FrmParaTransfer : Form
    {
        public FrmParaTransfer()
        {
            InitializeComponent();
        }
        public int MusteriId;
        private void FrmParaTransfer_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        Model1 m = new Model1();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
  
            decimal gonderilecek = decimal.Parse(txtTutarHavale.Text);
            var musterim = m.Hesap.Where(x => x.MusteriId == MusteriId && x.Bakiye >= gonderilecek).OrderByDescending(y => y.Bakiye).FirstOrDefault();
            if (musterim != null)
            {
                Havale h = new Havale();
                h.GonderenID = musterim.Id;
                h.IBAN = txtHavaleAliciHesap.Text;
                h.Tutar = decimal.Parse(txtTutarHavale.Text);
                h.Aciklama = txtAciklamaHavale.Text;

                m.Havale.Add(h);

                m.SaveChanges();
                HesapOzeti hesapOzeti = new HesapOzeti();
                hesapOzeti.Ad = "Farklı Hesaba Para Gönderimi";
                hesapOzeti.IslemId = 3;
                hesapOzeti.IslemTutar = decimal.Parse(txtTutarHavale.Text);
                hesapOzeti.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                hesapOzeti.HesapId = musterim.Id;
                m.HesapOzeti.Add(hesapOzeti);
                m.SaveChanges();
                musterim.Bakiye = musterim.Bakiye - gonderilecek;



                var alici = m.Hesap.Where(x => x.IBAN.Equals(txtHavaleAliciHesap.Text)).FirstOrDefault();
                alici.Bakiye = alici.Bakiye + gonderilecek;
                HesapOzeti hesapOzeti2 = new HesapOzeti();
                hesapOzeti2.Ad = "Farklı Hesaptan  Para Alımı";
                hesapOzeti2.IslemId = 3;
                hesapOzeti2.IslemTutar = decimal.Parse(txtTutarHavale.Text);
                hesapOzeti2.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                hesapOzeti2.HesapId = alici.Id;
                m.HesapOzeti.Add(hesapOzeti2);
            
                m.SaveChanges();

                MessageBox.Show("Para Gönderim İşlemi Onaylandı ","Bilgi");





            }
            else
            {
                MessageBox.Show("Hesabınızda Yeterli Bakiye Yok","Uyarı");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            decimal gonderilecek = decimal.Parse(txtEftTutar.Text);
            var musterim = m.Hesap.Where(x => x.MusteriId == MusteriId && x.Bakiye >= gonderilecek).OrderByDescending(y => y.Bakiye).FirstOrDefault();
            if (musterim != null)
            {
                Havale h = new Havale();
                h.GonderenID = musterim.Id;
                h.IBAN = txtAliciEftHesap.Text;
                h.Tutar = decimal.Parse(txtEftTutar.Text);
                h.Aciklama = txtAciklamaEft.Text;

                m.Havale.Add(h);

                m.SaveChanges();
                HesapOzeti hesapOzeti = new HesapOzeti();
                hesapOzeti.Ad = "Farklı Hesaba Para Gönderimi";
                hesapOzeti.IslemId = 4;
                hesapOzeti.IslemTutar = decimal.Parse(txtEftTutar.Text);
                hesapOzeti.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                hesapOzeti.HesapId = musterim.Id;
                m.HesapOzeti.Add(hesapOzeti);
                m.SaveChanges();
                musterim.Bakiye = musterim.Bakiye - gonderilecek;



                

                m.SaveChanges();

                MessageBox.Show("Para Gönderim İşlemi Onaylandı ", "Bilgi");





            }
            else
            {
                MessageBox.Show("Hesabınızda Yeterli Bakiye Yok", "Uyarı");
            }
        }
    }
}
