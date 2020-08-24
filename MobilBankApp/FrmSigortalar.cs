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
    public partial class FrmSigortalar : Form
    {
        public FrmSigortalar()
        {
            InitializeComponent();
        }
        Model1 m = new Model1();
        public int MusteriId;
        private void FrmSigortalar_Load(object sender, EventArgs e)
        {
            getSigortalar();
        }
        void getSigortalar()
        {
            var sigortalar = (from x in m.SigortaKampanya
                              select new
                              {
                                  x.Id,
                                  x.Ad,
                                  x.Tutar

                              }).ToList();
            gridControl1.DataSource = sigortalar;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            decimal odenecekTutar = decimal.Parse(txtTutar.Text);
            var musterim = m.Hesap.Where(x => x.MusteriId == MusteriId && x.Bakiye >= odenecekTutar).OrderByDescending(y => y.Bakiye).FirstOrDefault();
           
            if (musterim != null)
            {
                SigortaHareket sigortaHareket = new SigortaHareket();
                sigortaHareket.Yaptiran = MusteriId;
                sigortaHareket.SigortaKampanya = int.Parse(txtId.Text);
                m.SigortaHareket.Add(sigortaHareket);
                m.SaveChanges();
                musterim.Bakiye = musterim.Bakiye - odenecekTutar;
                m.SaveChanges();
                int hesapId = musterim.Id;

                HesapOzeti hesapOzeti = new HesapOzeti();
                hesapOzeti.Ad = txtAd.Text;
                hesapOzeti.IslemId = 2;
                hesapOzeti.IslemTutar = decimal.Parse(txtTutar.Text);
                hesapOzeti.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                hesapOzeti.HesapId = hesapId;
                m.HesapOzeti.Add(hesapOzeti);



                m.SaveChanges();

                MessageBox.Show("Tebrikler ! , Bankamızda kayıtlı olan varlığınız sigortalanmıştır. ", "Bilgi");


            }
            else
            {
                MessageBox.Show("Bakiye yetersiz , Lütfen Tüm paranız tek bir hesapta toplamayı deneyin !","Uyarı");
            }




        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtTutar.Text = gridView1.GetFocusedRowCellValue("Tutar").ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
