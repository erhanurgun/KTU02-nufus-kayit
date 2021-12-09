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
using System.Threading;

namespace lessonUser
{
    public partial class frmVatandas : Form
    {
        #region GLOBAL:

        #region 01: preloader();
        public int sayac = 0;
        public void preloader()
        {
            timer1.Start();
            tabControl1.Visible = false;

            PictureBox pic = new PictureBox
            {
                Name = "imgPreloader",
                Size = new Size(990, 668),
                Location = new Point(0, 0)
            };
            this.Controls.Add(pic);
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.ImageLocation = @"C:\Users\erhan\Desktop\okul\VisualStudio\lessonUser\lessonUser\Resources\preloader.gif";
        }
        #endregion

        #region 02: txtZorunlu();
        public bool txtZorunlu(TextBox txt)
        {
            bool durum = true;
            if (txt.Text.Trim() == "")
                errorProvider1.SetError(txt, "Lütfen bu alanı doldurunuz!");
            else
                errorProvider1.SetError(txt, "");
            return durum;
        }
        #endregion

        /*
         * TODO: Dikkat
         * kayitGetir() ve kayitAra() da benzer "tekrar eden kod" bulunmakta (örnek olarak gösterilecek)...
         */

        #region 03: kayitGetir();
        private void kayitGetir()
        {
            string conString = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=lesson_user;Integrated Security=True;";
            SqlConnection baglanti = new SqlConnection(conString);

            baglanti.Open();
            string kayit = "SELECT * FROM temel_bilgiler ORDER BY ad ASC, soyad ASC";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataKayitListesi.DataSource = dt;
            baglanti.Close();
        }
        #endregion

        #region 04: kayitAra();
        private void kayitAra()
        {
            string conString = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=lesson_user;Integrated Security=True;";
            SqlConnection baglanti = new SqlConnection(conString);

            baglanti.Open();
            string kayit = "SELECT * FROM temel_bilgiler WHERE tc LIKE '%" + txtTcAra.Text + "%' ORDER BY ad ASC, soyad ASC";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataKayitListesi.DataSource = dt;
            baglanti.Close();
        }
        #endregion

        #region 05: kayitAl();
        public void kayitAl(Sorgular sorgu)
        {
            try
            {
                if (cmbVerilisTuru.SelectedIndex == 0)
                    sorgu.verilis_turu = 0;
                else if (cmbVerilisTuru.SelectedIndex == 1)
                    sorgu.verilis_turu = 1;

                sorgu.tc = txtTc.Text;
                sorgu.ad = txtAd.Text;
                sorgu.soyad = txtSoyad.Text;
                sorgu.anne_adi = txtAnaAdi.Text;
                sorgu.baba_adi = txtBabaAdi.Text;
                sorgu.dogum_tarihi = dateDogumTarihi.Text;
                sorgu.dogum_yeri = txtDogumYeri.Text;
                sorgu.aile_sira_no = Convert.ToInt16(txtAileSiraNo.Text);
                sorgu.birey_sira_no = Convert.ToInt16(txtBireySiraNo.Text);
                sorgu.cilt_no = Convert.ToInt16(txtCiltNo.Text);
                sorgu.seri_no = txtSeriNo.Text;
                sorgu.uyrugu = cmbUyrugu.Text;

                if (cmbMedeniHali.SelectedIndex == 0)
                    sorgu.medeni_hali = 0;
                else if (cmbMedeniHali.SelectedIndex == 1)
                    sorgu.medeni_hali = 1;
                else if (cmbMedeniHali.SelectedIndex == 2)
                    sorgu.medeni_hali = 2;
                else if (cmbMedeniHali.SelectedIndex == 3)
                    sorgu.medeni_hali = 3;

                sorgu.telefon = mtxtTelefon.Text;
                sorgu.email = txtEmail.Text;
                sorgu.boy = Convert.ToDouble(txtBoy.Text);
                sorgu.kilo = Convert.ToDouble(txtKilo.Text);

                if (rbtnErkek.Checked)
                    sorgu.cinsiyet = 1;
                else if (rbtnKadin.Checked)
                    sorgu.cinsiyet = 0;

                sorgu.dbBaglan(2);

                MessageBox.Show("İşlem başarılı bir şekilde tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
            }
            catch (Exception err)
            {
                //MessageBox.Show("Beklenmedik bir hata oluştu!", "Hata - #frmVatandas.cs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(err.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Algoritmalar: Uret();
        // TODO: Bu kısım daha sonra başka yere taşınacak !
        class Uret
        {
            public string yeni_tc, db_tc;
            public string yeni_seri_no, db_seri_no;

            #region 01: tcUret();
            public void tcUret()
            {
                Random rast = new Random();
                int rast_sayi = rast.Next(100000000, 999999999);
                string str_sayi = "13265028";
                //string str_sayi = rast_sayi.ToString();
                int tek = 0, cift = 0;

                for (int i = 0; i < 9; i += 2)
                    tek += str_sayi[i] - '0';

                for (int i = 1; i < 9; i += 2)
                    cift += str_sayi[i] - '0';

                int bas_10 = ((tek * 7) - cift) % 10;
                int ilk_9 = 0;

                for (int i = 0; i < 9; i++)
                    ilk_9 += str_sayi[i] - '0';

                int bas_11 = (ilk_9 + bas_10) % 10;

                yeni_tc = str_sayi + bas_10.ToString() + bas_11.ToString();

                //MessageBox.Show(txt_tc);
            }
            #endregion

            #region 02: seriNoUret();
            public void seriNoUret()
            {
                Random rast = new Random();
                char harf1, harf2;
                int sayi1, sayi2;

                int ascii1 = rast.Next(65, 91);
                harf1 = Convert.ToChar(ascii1);
                int ascii2 = rast.Next(65, 91);
                harf2 = Convert.ToChar(ascii2);

                sayi1 = rast.Next(10, 99);
                sayi2 = rast.Next(10000, 99999);

                yeni_seri_no = harf1 + sayi1.ToString() + harf2 + sayi2.ToString();
            }
            #endregion
        }
        #endregion

        #endregion

        public frmVatandas()
        {
            InitializeComponent();
        }

        #region timer1_Tick():
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac % 2 == 0)
            {
                tabControl1.Visible = true;
                timer1.Stop();
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            // Yükleme Ekranı
            preloader();
            // DB Kayıtların Listesi
            kayitGetir();
        }


        #region 01: Buttons_Click();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            #region 01: Alanlar Boş Mu Kontrol Et
            txtZorunlu(txtAd);
            txtZorunlu(txtSoyad);
            txtZorunlu(txtAnaAdi);
            txtZorunlu(txtBabaAdi);

            txtZorunlu(txtDogumYeri);
            txtZorunlu(txtAileSiraNo);
            txtZorunlu(txtBireySiraNo);
            txtZorunlu(txtCiltNo);

            txtZorunlu(txtEmail);
            txtZorunlu(txtBoy);
            txtZorunlu(txtKilo);
            #endregion

            #region 02: Veritabanına Kayıt Ekle;
            Sorgular kayit_yap = new Sorgular();
            kayit_yap.yol = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=lesson_user;Integrated Security=True";
            kayit_yap.sorgu = "INSERT INTO temel_bilgiler(verilis_turu, tc, ad, soyad, anne_adi, baba_adi, dogum_tarihi, dogum_yeri, aile_sira_no, birey_sira_no, cilt_no, seri_no, uyrugu, medeni_hali, telefon, email, boy, kilo, cinsiyet) " +
                              "VALUES(@verilis_turu, @tc, @ad, @soyad, @anne_adi, @baba_adi, @dogum_tarihi, @dogum_yeri, @aile_sira_no, @birey_sira_no, @cilt_no, @seri_no, @uyrugu, @medeni_hali, @telefon, @email, @boy, @kilo, @cinsiyet)";
            kayitAl(kayit_yap);
            #endregion
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // TODO: Eklenecek...
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            #region 02: Veritabanıda ki Kaydı Güncelleme;
            Sorgular kayit_guncelle = new Sorgular();
            kayit_guncelle.yol = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=lesson_user;Integrated Security=True";
            kayit_guncelle.sorgu = "UPDATE temel_bilgiler SET (verilis_turu, tc, ad, soyad, anne_adi, baba_adi, dogum_tarihi, dogum_yeri, aile_sira_no, birey_sira_no, cilt_no, seri_no, uyrugu, medeni_hali, telefon, email, boy, kilo, cinsiyet) " +
                                   "VALUES(@verilis_turu, @tc, @ad, @soyad, @anne_adi, @baba_adi, @dogum_tarihi, @dogum_yeri, @aile_sira_no, @birey_sira_no, @cilt_no, @seri_no, @uyrugu, @medeni_hali, @telefon, @email, @boy, @kilo, @cinsiyet) " +
                                   "WHERE tc = @tc";
            kayitAl(kayit_guncelle);
            #endregion
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // TODO: Eklenecek...
            // Şimdilik Buraya Eklendi !!!
            Uret uret = new Uret();
            //uret.db_tc = "23276502826";
            uret.tcUret();
            //uret.db_seri_no = "A11Z79634";
            uret.seriNoUret();

            //while (uret.yeni_tc == uret.db_tc)
            //    uret.tcUret();

            //while (uret.yeni_seri_no == uret.db_seri_no)
            //    uret.seriNoUret();

            txtTc.Text = uret.yeni_tc;
            txtSeriNo.Text = uret.yeni_seri_no;

            //MessageBox.Show($"T.C: {uret.yeni_tc} - Seri No: {uret.yeni_seri_no}");
        }

        private void btnKayitAra_Click(object sender, EventArgs e)
        {
            kayitAra();
        }
        #endregion

        private void lblYenile_Click(object sender, EventArgs e)
        {
            preloader();
            txtTcAra.Clear();
            kayitGetir();
        }

        #region 02: ComboBoxs_SelectedIndexChanged();
        private void cmbUlke_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUlke.SelectedIndex != -1)
                cmbIl.Enabled = true;
            else
                cmbIl.Enabled = false;
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIl.SelectedIndex != -1)
                cmbIlce.Enabled = true;
            else
                cmbIlce.Enabled = false;
        }

        private void cmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIlce.SelectedIndex != -1)
                rtxtAcikAdres.Enabled = true;
            else
                rtxtAcikAdres.Enabled = false;
        }
        #endregion

        #region 03: CheckBoxs_CheckedChanged();
        private void chHastaMi_CheckedChanged(object sender, EventArgs e)
        {
            if (chHastaMi.Checked)
                rtxtHastalikDetayi.Enabled = true;
            else
                rtxtHastalikDetayi.Enabled = false;
        }

        private void chSabikaliMi_CheckedChanged(object sender, EventArgs e)
        {
            if (chSabikaliMi.Checked)
                rtxtSabikaDetayi.Enabled = true;
            else
                rtxtSabikaDetayi.Enabled = false;
        }

        private void chEhliyetiVarMi_CheckedChanged(object sender, EventArgs e)
        {
            if (chEhliyetiVarMi.Checked)
            {
                cmbEhliyetSinifi.Enabled = true;
                dateEhliyetVerTarihi.Enabled = true;
                dateEhliyetGecTarihi.Enabled = true;
            }
            else
            {
                cmbEhliyetSinifi.Enabled = false;
                dateEhliyetVerTarihi.Enabled = false;
                dateEhliyetGecTarihi.Enabled = false;
            }
        }

        private void chOluMu_CheckedChanged(object sender, EventArgs e)
        {
            if (chOluMu.Checked)
                dateOlumTarihi.Enabled = true;
            else
                dateOlumTarihi.Enabled = false;
        }
        #endregion
    }
}
