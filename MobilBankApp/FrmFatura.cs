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
    public partial class FrmFatura : Form
    {
        public FrmFatura()
        {
            InitializeComponent();
        }
        Model1 m = new Model1();
        public int MusteriId;
        private void FrmFatura_Load(object sender, EventArgs e)
        {
            getComboFaturaTur();

            getFatura();
        }
        void getFatura()

        {
            int faturaTur = int.Parse(cmbFatura.SelectedValue.ToString());
            var fatura = (from x in m.Fatura
                          where x.MusteriId == MusteriId && x.Aktif == true && x.FaturaTur == faturaTur
                          select new
                          {
                              x.Id,
                              x.FaturaTur1.Ad,
                              x.Tutar,


                          }).ToList();
            gridControl1.DataSource = fatura;
        }
        void getComboFaturaTur()
        {
            var sorgu = (from k in m.FaturaTur
                         select new { k.Id, k.Ad }).ToList();



            cmbFatura.DisplayMember = "Ad";
            cmbFatura.ValueMember = "Id";
            cmbFatura.DataSource = sorgu;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void cmbFatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            getFatura();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtTutar.Text = gridView1.GetFocusedRowCellValue("Tutar").ToString();
                txtFaturaTur.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            }
            catch (Exception ex)
            {


            }


        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            decimal odenecekTutar = decimal.Parse(txtTutar.Text);
            var musterim = m.Hesap.Where(x => x.MusteriId == MusteriId && x.Bakiye >= odenecekTutar).OrderByDescending(y => y.Bakiye).FirstOrDefault();
            if (musterim != null)
            {
                int faturaId = int.Parse(txtId.Text);
                var faturalarim = m.Fatura.Find(faturaId);
                faturalarim.Aktif = false;

                musterim.Bakiye = musterim.Bakiye - odenecekTutar;


                var bakiye = m.Musteri.Find(MusteriId);
                bakiye.Bakiye = m.Hesap.Where(y => y.MusteriId == MusteriId && y.Aktif == true).Sum(x => x.Bakiye);

                int hesapId = musterim.Id;
                HesapOzeti hesapOzeti = new HesapOzeti();
                hesapOzeti.HesapId = hesapId;
                hesapOzeti.IslemId = 1;
                hesapOzeti.IslemTutar = odenecekTutar;
                hesapOzeti.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                hesapOzeti.Ad = cmbFatura.Text;

                m.HesapOzeti.Add(hesapOzeti);

               



                m.SaveChanges();

                MessageBox.Show("Faturanız Ödenmiştir.", "Bilgi");

                this.Close();
            }
            else
            {
                MessageBox.Show("Hesabınızda Yeterli Bakiye Bulunmamaktadır.","Bilgi");
            }









        }
    }
}
