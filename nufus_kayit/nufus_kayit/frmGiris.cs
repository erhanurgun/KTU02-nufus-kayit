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

namespace nufus_kayit
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            txtKadi.Text = Ayarlar.Default.kul_adi;
            txtSifre.Text = Ayarlar.Default.kul_sifre;
            chbBeniHatirla.Checked = Ayarlar.Default.beni_hatirla;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Global global = new Global
            {
                sorgu = "SELECT * FROM personeller WHERE durum = 1",
                txt_kadi = txtKadi.Text,
                txt_sifre = txtSifre.Text
            };
            global.chb = chbBeniHatirla;
            global.beniHatirla(1);
            global.dbBaglan(1);
        }

        private void linkSifrem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSifre sifre = new frmSifre();
            sifre.ShowDialog();
        }

        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://erhanurgun.com.tr/");
        }
    }
}
