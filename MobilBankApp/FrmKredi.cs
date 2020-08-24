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
    public partial class FrmKredi : Form
    {
        public FrmKredi()
        {
            InitializeComponent();
        }
        Model1 m = new Model1();
        public int MusteriId;
        private void FrmKredi_Load(object sender, EventArgs e)
        {
            getKrediTur();
        }
        void getKrediTur()
        {
            var sorgu = (from k in m.KrediTur
                         select new { k.Id, k.Ad }).ToList();



            cmbKrediTur.DisplayMember = "Ad";
            cmbKrediTur.ValueMember = "Id";
            cmbKrediTur.DataSource = sorgu;
        }
       

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        public delegate void MessageHandler();
        public void olumlu()
        {
            MessageBox.Show("İşlem Başarıyla Gerçekleştirildi");
        }
        public void olumsuz()
        {
            MessageBox.Show("Maalesef Çağrınıza olumlu cevap veremiyoruz ");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            KrediBasvuru k = new KrediBasvuru();
            k.MusteriId = MusteriId;
            k.KrediTur = int.Parse(cmbKrediTur.SelectedValue.ToString());
            k.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            k.Vade = int.Parse(cmbVade.Text);
            k.Tutar = decimal.Parse(cmbTutar.Text);
            m.KrediBasvuru.Add(k);
            m.SaveChanges();

            decimal tutar = decimal.Parse(cmbTutar.Text);
            var bakiyem = m.Hesap.Where(x => x.MusteriId == MusteriId && x.Aktif == true).Sum(y => y.Bakiye).ToString();
            decimal bakiye= decimal.Parse(bakiyem);
            if (bakiye > tutar)
            {
                var musterim = m.Hesap.Where(x => x.MusteriId == MusteriId ).OrderByDescending(y => y.Bakiye).FirstOrDefault();
                musterim.Bakiye = musterim.Bakiye + decimal.Parse(tutar.ToString());
                m.SaveChanges();
                HesapOzeti hesapOzeti = new HesapOzeti();
                hesapOzeti.HesapId = musterim.Id;
                hesapOzeti.IslemId = 5;
                hesapOzeti.IslemTutar = tutar;
                hesapOzeti.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                hesapOzeti.Ad = "Kredi Tutarınız Hesabınıza Yattı";

                m.HesapOzeti.Add(hesapOzeti);
                m.SaveChanges();

                MessageHandler show = new MessageHandler(olumlu);
                show();
               
            }
            else
            {
                MessageHandler show = new MessageHandler(olumsuz);
                show();
            }

        }
    }
}
