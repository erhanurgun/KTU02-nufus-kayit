using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lessonUser
{
    public class Sorgular
    {
        #region Global Değerler;
        // Gelen değişkenler 
        public string yol, sorgu, verilis_tarihi, gecerlilik_tarihi;
        public int kisi_id;
        public bool var_mi;
        // girisYap() değişkenleri
        public string txt_kadi, txt_sifre, db_kadi, db_sifre;
        // veriKaydet() değişkenleri
        // temel_bilgiler:
        public string tc, ad, soyad, anne_adi, baba_adi, dogum_tarihi, dogum_yeri, seri_no, uyrugu, evlenme_tarihi, bosanma_tarihi, telefon, email;
        public int verilis_turu, aile_sira_no, birey_sira_no, cilt_no, medeni_hali, cinsiyet;
        public double boy, kilo;
        // adres_bilgileri
        public string ulke, il, ilce, acik_adres;
        // saglik_bilgileri
        public string hes_kodu, kan_grubu, hastalik_detayi;
        // sabika_bilgileri
        public string sabika_detay;
        // ehliyet_bilgileri
        public char ehliyet_sinifi;
        // diger_bilgiler
        public string veren_makam, olum_tarihi, img_foto, img_imza;
        public bool olu_mu;

        public frmVatandas frmVt = new frmVatandas();
        public frmGiris frmGr = new frmGiris();
        public SqlConnection baglan = new SqlConnection();
        public SqlCommand komut = new SqlCommand();
        public SqlDataReader veri_oku;

        //public SqlDataAdapter veri_aktar = new SqlDataAdapter();
        //public DataTable veri_tablosu = new DataTable();

        #endregion

        #region Genel Veritabanı Bağlantısı: dbBaglan();
        public void dbBaglan(int param)
        {
            try
            {
                baglan.ConnectionString = yol;

                if (baglan.State == ConnectionState.Closed) baglan.Open();

                komut.CommandText = sorgu;
                komut.Connection = baglan;
                komut.CommandType = CommandType.Text;

                if (param == 1) girisYap();
                else if (param == 2) veriKaydet();

                baglan.Close();
            }
            catch (Exception exp)
            {
                //MessageBox.Show("Beklenmedik bir hata oluştu!", "Hata - #Sorgular.cs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(exp.ToString());
                frmGr.Close();
            }
        }
        #endregion

        #region 1: girisYap();
        public void girisYap()
        {
            veri_oku = komut.ExecuteReader();
            while (veri_oku.Read())
            {
                db_kadi = veri_oku["kullanici_adi"].ToString();
                db_sifre = veri_oku["sifre"].ToString();
                //MessageBox.Show(db_kadi + " " + db_sifre);

                if (txt_kadi == db_kadi && txt_sifre == db_sifre)
                {
                    frmVt.ShowDialog();
                    //frmGr.Hide();
                    break;
                }
            }
            if (txt_kadi != db_kadi || txt_sifre != db_sifre)
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region 2: veriKaydet();
        public void veriKaydet()
        {
            komut.Parameters.AddWithValue("@verilis_turu", verilis_turu);
            komut.Parameters.AddWithValue("@tc", tc);
            komut.Parameters.AddWithValue("@ad", ad);
            komut.Parameters.AddWithValue("@soyad", soyad);
            komut.Parameters.AddWithValue("@anne_adi", anne_adi);
            komut.Parameters.AddWithValue("@baba_adi", baba_adi);
            komut.Parameters.AddWithValue("@dogum_tarihi", dogum_tarihi);
            komut.Parameters.AddWithValue("@dogum_yeri", dogum_yeri);
            komut.Parameters.AddWithValue("@aile_sira_no", aile_sira_no);
            komut.Parameters.AddWithValue("@birey_sira_no", birey_sira_no);
            komut.Parameters.AddWithValue("@cilt_no", cilt_no);
            komut.Parameters.AddWithValue("@seri_no", seri_no);
            komut.Parameters.AddWithValue("@uyrugu", uyrugu);
            komut.Parameters.AddWithValue("@medeni_hali", medeni_hali);
            komut.Parameters.AddWithValue("@telefon", telefon);
            komut.Parameters.AddWithValue("@email", email);
            komut.Parameters.AddWithValue("@boy", boy);
            komut.Parameters.AddWithValue("@kilo", kilo);
            komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);

            //komut.Parameters.AddWithValue("@", );
            komut.ExecuteNonQuery();
        }
        #endregion

    }
}
