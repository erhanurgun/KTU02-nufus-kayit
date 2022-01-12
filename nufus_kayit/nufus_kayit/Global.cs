using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Net.Mail;

namespace nufus_kayit
{
    class Global
    {
        #region void: hataSatiriniBul(), yukleniyor()

        #region 01: hataSatiriniBul()
        public int hataSatiriniBul(Exception ex)
        {
            var satir_no = 0;
            const string satir_ara = ":line ";
            var veri = ex.StackTrace.LastIndexOf(satir_ara);
            if (veri != -1)
            {
                var satir_nerede = ex.StackTrace.Substring(veri + satir_ara.Length);
                if (int.TryParse(satir_nerede, out satir_no))
                {
                }
            }
            return satir_no;
        }

        #endregion

        #region 02: yukleniyor()
        /* Değişkenler:
         * Timer, TabControl, Form
         * tmr, tCtrl, frm
         */
        public void imgYukleniyor()
        {
            tmr.Start();
            tCtrl.Visible = false;

            PictureBox pic = new PictureBox
            {
                Name = "imgPreloader",
                Size = new Size(frm.Width - 100, frm.Height - 50),
                Location = new Point(0, 0)
            };
            frm.Controls.Add(pic);
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.ImageLocation = @"../../Resources/preloader.gif";
        }
        #endregion

        #endregion

        #region A1: Global Değişkenler
        SqlConnection baglan = new SqlConnection();
        SqlCommand komut = new SqlCommand();
        SqlDataReader veri_oku;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        OpenFileDialog opnDia = new OpenFileDialog();

        public ComboBox cmb;
        public Form frm;
        public CheckBox chb;
        public ErrorProvider err;
        public Random rnd;
        public TextBox txt;
        public Timer tmr;
        public TabControl tCtrl;
        public PictureBox picBx;
        public DataGridView dataGdVi;

        //GroupBox grb;
        //Control ctrl;
        #endregion

        #region A2: Veritabanına Bağlan:
        public string yol = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=app_nufus_kayit;Integrated Security=True";
        public string sorgu, sutun_adi;
        public void dbBaglan(int tip)
        {
            try
            {
                baglan.ConnectionString = yol;
                komut.CommandText = sorgu;
                komut.Connection = baglan;
                komut.CommandType = CommandType.Text;

                if (baglan.State == ConnectionState.Closed) baglan.Open();

                if (tip == 1) btnGirisYap();
                else if (tip == 2) btnSifreAl();
                else if (tip == 3) cmbSecimYap();
                else
                    MessageBox.Show("Veritabanına bağlantı sağlandı fakat herhangi bir işlem yapılmadı!", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                baglan.Close();
            }
            catch (Exception exp)
            {
                //MessageBox.Show("Beklenmedik bir hata oluştu!", "HATA !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(exp.ToString(), "Hata Mesajı !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(hataSatiriniBul(exp).ToString() + " numaralı satırda hata var!", "Hata Mesajı !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region A3: Verileri İşle:

        #region 01: btnGirisYap()
        public string txt_kadi, txt_sifre, db_kadi, db_sifre;
        public void btnGirisYap()
        {
            veri_oku = komut.ExecuteReader();
            while (veri_oku.Read())
            {
                db_kadi = veri_oku["kullanici_adi"].ToString();
                db_sifre = veri_oku["sifre"].ToString();

                if (txt_kadi == db_kadi && txt_sifre == db_sifre)
                {
                    //Form.ActiveForm.Hide();
                    frm = new frmVatandas();
                    frm.ShowDialog();
                    break;
                }
            }

            if (txt_kadi != db_kadi || txt_sifre != db_sifre)
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region 02: btnSifreAl()
        public string db_email, txt_email;
        public bool gonder;
        public void btnSifreAl()
        {
            veri_oku = komut.ExecuteReader();
            while (veri_oku.Read())
            {
                db_email = veri_oku["email"].ToString();
                send_konu = "Şifre Hatırlatma Servisi";
                send_mesaj = "<b>Email Adresiniz.: </b>" + veri_oku["email"] + "<br />" + 
                             "<b>Kullanıcı Adınız: </b>" + veri_oku["kullanici_adi"] + "<br />" +
                             "<b>Şifreniz .............: </b>" + veri_oku["sifre"];
                if (db_email.ToLower() == txt_email.ToLower())
                {
                    gonder = true;
                    emailGonder();
                    break;
                }
            }
            if (txt_email == "")
                MessageBox.Show("Lütfen bir mail adresi giriniz", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txt_email != "" && gonder == false)
                MessageBox.Show("Bu email adresine ait bir kullanıcı bulunamadı!", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region 03: cmbSecimYap()
        public void cmbSecimYap()
        {
            veri_oku = komut.ExecuteReader();
            while (veri_oku.Read())
                cmb.Items.Add(veri_oku[sutun_adi]);
            if (cmb.Items.Count == 0)
                MessageBox.Show("Veri bulunamadı!", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region 04: kayitAra();
        // sorgu, dataGridView
        public void kayitAra()
        {
            string conString = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=app_nufus_kayit;Integrated Security=True;";
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            string kayit = "SELECT * FROM vatandaslar WHERE tc_no LIKE '%" + txt.Text + "%' ORDER BY adi ASC, soyadi ASC";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGdVi.DataSource = dt;
            baglanti.Close();
        }
        #endregion

        #region 03: kayitGetir();
        public void kayitGetir()
        {
            string conString = @"Data Source=PCI-ACER\SQLSERVEREXP;Initial Catalog=app_nufus_kayit;Integrated Security=True;";
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            string kayit = "SELECT * FROM vatandaslar ORDER BY adi ASC, soyadi ASC";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGdVi.DataSource = dt;
            baglanti.Close();
        }
        #endregion

        #endregion

        #region A4: Kontrolleri Sağla:

        #region 01: frmTemizle()
        public void frmTemizle(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (typeof(TextBox) == c.GetType())
                    ((TextBox)(c)).Text = "";
                else if (typeof(MaskedTextBox) == c.GetType())
                    ((MaskedTextBox)(c)).Text = "";
                else if (typeof(RichTextBox) == c.GetType())
                    ((RichTextBox)(c)).Text = "";
                else if (typeof(RadioButton) == c.GetType())
                    ((RadioButton)(c)).Checked = false;
                else if (typeof(CheckBox) == c.GetType())
                    ((CheckBox)(c)).Checked = false;
                else if (typeof(DateTimePicker) == c.GetType())
                    ((DateTimePicker)(c)).Text = "";
                else if (typeof(ComboBox) == c.GetType())
                    ((ComboBox)(c)).SelectedIndex = -1;
                else if (typeof(PictureBox) == c.GetType())
                    ((PictureBox)(c)).ImageLocation = @"../../Resources/no-photo.png";
                else
                    frmTemizle(c);
            }
        }
        #endregion

        #region 02: emailGonder()
        public string smtp_email = "btsmtpdemo@gmail.com";
        public string smtp_sifre = "Smtp785*?";
        public string send_baslik = "Kargo Takip Uygulaması";
        public string send_konu, send_mesaj;
        public void emailGonder()
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Credentials = new NetworkCredential(smtp_email, smtp_sifre),
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(smtp_email, send_baslik),
                    Subject = send_konu,
                    Body = send_mesaj,
                    IsBodyHtml = true
                };

                mail.To.Add(txt_email);
                client.Send(mail);

                MessageBox.Show("Email gönderme işlemi başarılı bir şekilde tamamlandı!", "BAŞARILI !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form.ActiveForm.Close();
            }
            catch (Exception exp)
            {
                //MessageBox.Show("Beklenmedik bir sorun oluştu!", "HATA !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(exp.ToString());
            }
        }

        #endregion

        #region 03: tcKontrol()
        public string tc_cek, tc_bul;
        public void tcKontrol(ErrorProvider err, MaskedTextBox txt, bool veri_al)
        {
            if (tc_cek.Length > 8)
            {
                string str_sayi = "";

                for (int i = 0; i < 9; i++)
                    str_sayi += tc_cek[i].ToString();

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
                tc_bul = str_sayi + bas_10.ToString() + bas_11.ToString();

                if (tc_cek.Length == 11 && (tc_cek != tc_bul))
                    err.SetError(txt, "T.C. kimlik numarası yanlış girildi!");
                else if (tc_cek == tc_bul && veri_al)
                    dbBaglan(3);
                else
                    err.SetError(txt, "");
            }
        }
        #endregion

        #region 04: bosMu()
        public bool hata_var_mi = false;
        public bool bosMu(GroupBox grb)
        {
            foreach (Control c in grb.Controls)
            {
                if (c is TextBox || c is MaskedTextBox || c is RichTextBox || c is DateTimePicker || c is ComboBox)
                {
                    if (c.Text == string.Empty && c.Enabled)
                    {
                        err.SetError(c, "Bu alan boş bırakılamaz!");
                        hata_var_mi = true;
                    }
                    else if (c.Text != string.Empty)
                        err.SetError(c, string.Empty);
                }
            }
            return hata_var_mi;
        }
        #endregion

        #region 05: beniHatirla()
        public void ayarAl(int param)
        {
            if (param == 1)
            {
                if (chb.Checked)
                {
                    Ayarlar.Default.kul_adi = txt_kadi;
                    Ayarlar.Default.kul_sifre = txt_sifre;
                    Ayarlar.Default.beni_hatirla = true;
                }
                else
                {
                    Ayarlar.Default.kul_adi = null;
                    Ayarlar.Default.kul_sifre = null;
                    Ayarlar.Default.beni_hatirla = false;
                }
            }
            else if (param == 2)
            {
                if (chb.Checked)
                {
                    Ayarlar.Default.img_yukleniyor = true;
                }
                else
                {
                    Ayarlar.Default.img_yukleniyor = false;
                }
            }

            Ayarlar.Default.Save();
        }
        #endregion

        #endregion

        #region A5: Diğer İşlemler:

        #region 01: dosyaAl()
        // pictureBox, textBox, param
        public void dosyaAl(int param)
        {
            if (param == 1)
                opnDia.Filter = "Image Files(*.png; *.jpg; *.jpeg;)|*.png; *.jpg; *.jpeg;";

            if (opnDia.ShowDialog() == DialogResult.OK)
            {
                picBx.Image = new Bitmap(opnDia.FileName);
                txt.Text = opnDia.FileName;
            }
        }

        #endregion

        #endregion
    }
}
