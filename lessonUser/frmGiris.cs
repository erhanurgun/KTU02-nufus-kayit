using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lessonUser
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            txtKadi.Text = "erhanurgun";
            txtSifre.Text = "pass123";
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Sorgular giris_yap = new Sorgular();
            giris_yap.txt_kadi = txtKadi.Text;
            giris_yap.txt_sifre = txtSifre.Text;
            giris_yap.yol = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=lesson_user;Integrated Security=True";
            giris_yap.sorgu = "SELECT kullanici_adi, sifre FROM personeller";
            giris_yap.dbBaglan(1);
        }

        private void linkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://erhanurgun.com.tr/");
        }
    }
}
