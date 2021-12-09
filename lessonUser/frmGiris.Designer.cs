
namespace lessonUser
{
    partial class frmGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiris));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.linkSifrem = new System.Windows.Forms.LinkLabel();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtKadi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkSite = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGiris);
            this.groupBox1.Controls.Add(this.linkSifrem);
            this.groupBox1.Controls.Add(this.txtSifre);
            this.groupBox1.Controls.Add(this.txtKadi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(97, 81);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(156, 48);
            this.btnGiris.TabIndex = 3;
            this.btnGiris.Text = " 🔒 GİRİŞ YAP";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // linkSifrem
            // 
            this.linkSifrem.AutoSize = true;
            this.linkSifrem.Location = new System.Drawing.Point(140, 140);
            this.linkSifrem.Name = "linkSifrem";
            this.linkSifrem.Size = new System.Drawing.Size(113, 15);
            this.linkSifrem.TabIndex = 4;
            this.linkSifrem.TabStop = true;
            this.linkSifrem.Text = "Şifreni mi unuttun ?";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(97, 48);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(156, 21);
            this.txtSifre.TabIndex = 2;
            // 
            // txtKadi
            // 
            this.txtKadi.Location = new System.Drawing.Point(97, 17);
            this.txtKadi.Name = "txtKadi";
            this.txtKadi.Size = new System.Drawing.Size(156, 21);
            this.txtKadi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Şifre: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "powered by";
            // 
            // linkSite
            // 
            this.linkSite.AutoSize = true;
            this.linkSite.Location = new System.Drawing.Point(114, 179);
            this.linkSite.Name = "linkSite";
            this.linkSite.Size = new System.Drawing.Size(138, 15);
            this.linkSite.TabIndex = 5;
            this.linkSite.TabStop = true;
            this.linkSite.Text = "www.erhanurgun.com.tr";
            this.linkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSite_LinkClicked);
            // 
            // frmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 204);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkSite);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(326, 243);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(326, 243);
            this.Name = "frmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yetkili Girişi";
            this.Load += new System.EventHandler(this.frmGiris_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtKadi;
        private System.Windows.Forms.LinkLabel linkSifrem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkSite;
    }
}