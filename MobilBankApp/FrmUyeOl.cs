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
    public partial class FrmUyeOl : Form
    {
        public FrmUyeOl()
        {
            InitializeComponent();
        }

        private void FrmUyeOl_Load(object sender, EventArgs e)
        {
            comboSehirDoldur();

        }
        void comboSehirDoldur()
        {
            var sorgu = (from k in m.Sehir
                         select new { k.Id, k.Ad }).ToList();



            cmbSehir.DisplayMember = "Ad";
            cmbSehir.ValueMember = "Id";
            cmbSehir.DataSource = sorgu;
        }
        Model1 m = new Model1();
        

        //private void ekle_click(object sender ,EventArgs e)
        //{
        //    SirketDataContext context = new SirketDataContext();
        //    Departmanlar departmanlar = new Departmanlar();

        //    departmanlar.DepartmanAdi = txtDepartmanAdi.Text;
        //    departmanlar.DepartmanTanimi = txtDepartmanTanimi.Text;
        //    departmanlar.DepartmanMudurAdi = txtDepartmanMudurAdi.Text;
        //    departmanlar.DepartmanCalisanSayisi = int.Parse(txtCalisanSayisi.Text);
        //    context.Departmanlar.add(departmanlar);
        //    context.SaveChanges();
        //    MessageBox.Show("Eklendi !");
        //}
        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            string IbanOlustur = "1515";
            Musteri musteri = new Musteri();
            musteri.KimlikNo = txtTcNo.Text;
            musteri.Ad = txtAd.Text;
            musteri.Soyad = txtSoyad.Text;
            musteri.Mail = txtMail.Text;
            musteri.TelefonNumarasi = txtTelefon.Text;
            musteri.Sehir = Convert.ToInt32(cmbSehir.SelectedValue.ToString());
            musteri.Sifre = txtSifre.Text;
            musteri.Aktif = true;


            m.Musteri.Add(musteri);
            m.SaveChanges();

            var degerler = m.Musteri.Where(x => x.KimlikNo == txtTcNo.Text).FirstOrDefault();
           
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                int sayi = rnd.Next(1000, 9999);
                
           
                IbanOlustur += sayi.ToString();
            }

            Hesap hesap = new Hesap();
            hesap.MusteriId = degerler.Id;
            hesap.IBAN = IbanOlustur;
            hesap.Bakiye = 0;
            hesap.HesapAdi = "Ana Hesap";
            hesap.Aktif = true;

            m.Hesap.Add(hesap);
            m.SaveChanges();


            MessageBox.Show("Yeni Üyelik Başarıyla Oluşturuldu","Bilgi");
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.Show();
            this.Close();
            
        }
    }
}
