using DevExpress.XtraPrinting;
using MobilBankApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilBankApp
{
    public partial class FrmHesapOzeti : Form
    {
        public FrmHesapOzeti()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "output.xlsx";
                gridControl1.ExportToXlsx(path);
                // Open the created XLSX file with the default application. 
                Process.Start(path);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        Model1 m = new Model1();
        public int HesapId;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                link.Component = gridControl1; //yazdıracağımız grid’i gösteriyoruz.
                link.Landscape = true; //kenarlıkların, boşlukların görüntülenmesini sağlıyoruz.
                link.ShowPreview(); //yazdırılacak gridi ekranda gösteriyoruz
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FrmHesapOzeti_Load(object sender, EventArgs e)
        {
            //var hesapOzet = m.HesapOzetis.Where(x => x.HesapId == HesapId).ToList();

            var hesapOzet = (from x in m.HesapOzeti
                             where x.HesapId == HesapId
                             select new
                             {
                                 x.Ad,
                                
                                 x.Hesap.HesapAdi,
                                IslemTur = x.IslemTur.Ad,
                                 x.IslemTutar,
                                 x.Tarih,

                             }).ToList();
            gridControl1.DataSource = hesapOzet;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
