using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nufus_kayit
{
    public partial class frmVatandas : Form
    {
        public frmVatandas()
        {
            InitializeComponent();
        }

        private void frmVatandas_Load(object sender, EventArgs e)
        {
            Global global = new Global();
            // yukleniyor
            chbYukleniyor.Checked = Ayarlar.Default.img_yukleniyor;
            if (Ayarlar.Default.img_yukleniyor)
            {
                global.tmr = tmrZamanlama;
                global.frm = this;
                global.tCtrl = tabControl1;
                global.imgYukleniyor();
            }
            // kayit getir
            global.txt = txtTcAra;
            global.dataGdVi = dataKayitListesi;
            global.kayitGetir();
        }

        public int say_saniye = 0;
        private void tmrZamanlama_Tick(object sender, EventArgs e)
        {
            say_saniye++;
            if (say_saniye % 2 == 0)
            {
                tabControl1.Visible = true;
                tmrZamanlama.Stop();
            }
        }

        private void btnAyarKaydet_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            global.chb = chbYukleniyor;
            global.ayarAl(2);

            MessageBox.Show("Ayarlar güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            global.frmTemizle(this);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            global.err = errHataMesaji;
            global.bosMu(grpKisi);
            global.bosMu(grpAdres);
            global.bosMu(grpDiger);

            if (global.hata_var_mi == false)
            {
                MessageBox.Show("Tebrikler Hatanız Yok!!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSecFoto_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            global.picBx = picFotograf;
            global.txt = txtImgFoto;
            global.dosyaAl(1);
        }

        private void btnSecImza_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            global.picBx = picImza;
            global.txt = txtImgImza;
            global.dosyaAl(1);
        }

        private void btnKayitAra_Click(object sender, EventArgs e)
        {
            Global global = new Global();
            global.txt = txtTcAra;
            global.dataGdVi = dataKayitListesi;
            global.kayitAra();
        }

        private void cmbUlke_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUlke.SelectedIndex != -1)
            {
                cmbIl.Enabled = true;
                Global global = new Global();
                global.yol = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=ortak_adres;Integrated Security=True";
                global.sorgu = "SELECT sehir_adi FROM iller ORDER BY sehir_adi";
                global.sutun_adi = "sehir_adi";
                global.cmb = cmbIl;
                global.dbBaglan(3);
            }
            else
                cmbIl.Enabled = false;
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.SelectedIndex = -1;
            cmbIlce.Items.Clear();

            if (cmbIl.SelectedIndex != -1)
            {
                cmbIlce.Enabled = true;
                Global global = new Global();
                global.yol = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=ortak_adres;Integrated Security=True";
                global.sorgu = "SELECT ilceler.sehir_id, iller.id, sehir_adi, ilce_adi FROM ilceler JOIN iller ON ilceler.sehir_id = iller.id WHERE sehir_adi = '" + cmbIl.Text + "' ORDER BY ilce_adi";
                global.sutun_adi = "ilce_adi";
                global.cmb = cmbIlce;
                global.dbBaglan(3);
            }
            else
                cmbIlce.Enabled = false;
        }

        private void cmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtAdres.Enabled = true;
        }
    }
}
