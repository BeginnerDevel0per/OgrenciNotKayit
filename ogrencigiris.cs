using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OgrenciNotKayit
{
    public partial class ogrencigiris : Form
    {
        public ogrencigiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repository repository= new repository();
            
           ogrencibilgi result= repository.login(textBox1.Text.ToString());
            if (result.status == loginstatus.basarili)
            {
                OgrenciDetay ogrenciDetay = new OgrenciDetay();
                ogrenciDetay.Show();
                ogrenciDetay.lbl_adsoyad.Text = result.ograd + " " + result.ogrsoyad;
                ogrenciDetay.lbl_numara.Text = result.ogrnumara;
                ogrenciDetay.lbl_snv1.Text = result.ogrs1.ToString();
                ogrenciDetay.lbl_snv2.Text = result.ogrs2.ToString();
                ogrenciDetay.lbl_snv3.Text = result.ogrs3.ToString();
                ogrenciDetay.lbl_ortalama.Text = result.ortalama.ToString();
                ogrenciDetay.lbl_durum.Text = result.durum.ToString();
                

            }
            else
            {
                MessageBox.Show("GİRDİĞİNİZ NUMARAYA AİT ÖĞRENCİ BULUNAMADI.", "UYARI", MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }
        }
    }
}
