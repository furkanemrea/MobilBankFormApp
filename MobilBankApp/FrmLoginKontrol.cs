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
    public partial class FrmLoginKontrol : Form
    {
        public FrmLoginKontrol()
        {
            InitializeComponent();
        }
        public string TcNo;
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.Show();

            this.Close();
        }
        FrmLogin frm = new FrmLogin();
        public int sifre;
        private void FrmLoginKontrol_Load(object sender, EventArgs e)
        {

        }

        private void btnOnayKabul_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtOnayKodu.Text) == sifre)
            {
                FrmAnaSayfa f = new FrmAnaSayfa();
                f.TcNo = TcNo;
                f.Show();

                this.Close();
            }
            else
            {
                lblUyari.Visible = true;
            }
        }

        private void txtOnayKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
