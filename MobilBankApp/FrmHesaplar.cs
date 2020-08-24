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
    public partial class FrmHesaplar : Form
    {
        public FrmHesaplar()
        {
            InitializeComponent();
        }
        public int HesapId;
        public int MusteriId;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmYeniHesap f = new FrmYeniHesap();
            f.MusteriID = MusteriId;
            f.ShowDialog();
            getHesap();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        Model1 m = new Model1();
        private void FrmHesaplar_Load(object sender, EventArgs e)
        {
            getHesap();
        }
        void getHesap()
        {
            var hesaplar = (from x in m.Hesap
                            where x.MusteriId == MusteriId && x.Aktif == true
                            select new
                            {
                                x.Id,
                                x.HesapAdi,
                                x.Bakiye,
                                x.IBAN

                            }).ToList();

            gridControl1.DataSource = hesaplar;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtIban.Text = gridView1.GetFocusedRowCellValue("IBAN").ToString();
            txtBakiye.Text = gridView1.GetFocusedRowCellValue("Bakiye").ToString();
            txtHesapAdi.Text = gridView1.GetFocusedRowCellValue("HesapAdi").ToString();
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmHesapOzeti hesapOzeti = new FrmHesapOzeti();
            hesapOzeti.HesapId = Convert.ToInt32(txtId.Text);
            
            hesapOzeti.ShowDialog();
            getHesap();
            
           

        }
    }
}
