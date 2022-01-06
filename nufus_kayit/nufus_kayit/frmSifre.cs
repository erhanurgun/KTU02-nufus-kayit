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
    public partial class frmSifre : Form
    {
        public frmSifre()
        {
            InitializeComponent();
        }

        private void btnSifreAl_Click(object sender, EventArgs e)
        {
            Global global = new Global
            {
                sorgu = "SELECT * FROM personeller WHERE durum = 1",
                txt_email = txtEposta.Text
            };
            global.dbBaglan(2);
        }
    }
}
