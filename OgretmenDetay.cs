using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciNotKayit
{
    public partial class OgretmenDetay : Form
    {
        public OgretmenDetay()
        {
            InitializeComponent();
        }

        private void OgretmenDetay_Load(object sender, EventArgs e)
        {
            this.Cursor= Cursors.Default;
            repository repository = new repository();
            dataGridView1.DataSource = repository.GetOgrencibilgi();
            lbl_ortalama.Text= Convert.ToString(repository.Getavg());
            lbl_gecen.Text = repository.getgecen();
            lbl_kalan.Text = repository.getkalan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repository repository = new repository();
            loginstatus result = repository.insertOgrenci(txt_numarakayit.Text, txt_adkayit.Text, txt_soyadkayit.Text);
            if(result== loginstatus.basarili)
            {
                MessageBox.Show("BAŞARILI BİR ŞEKİLDE EKLENDİ.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information );
                dataGridView1.DataSource = repository.GetOgrencibilgi();
            }
            else
            {
                MessageBox.Show("EKLENEMEDİ.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OgretmenDetay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            repository repository = new repository();
            if (!string.IsNullOrEmpty(txt_snv1.Text) && !string.IsNullOrEmpty(txt_snv2.Text)&& !string.IsNullOrEmpty(txt_snv3.Text) && !string.IsNullOrEmpty(txt_numaragnc.Text))
            {
                loginstatus result = repository.updateOgrenci(Convert.ToByte(txt_snv1.Text), Convert.ToByte(txt_snv2.Text), Convert.ToByte(txt_snv3.Text), txt_numaragnc.Text);
                if (result == loginstatus.basarili)
                {
                    MessageBox.Show("BAŞARILI BİR ŞEKİLDE GÜNCELLENDİ.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = repository.GetOgrencibilgi();
                }
                else
                {
                    MessageBox.Show("GÜNCELLENEMEDİ.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("GÜNCELLENEMEDİ.\nBoş alan bırakılamaz." + " \nEğer öğrencinin notu yoksa 0 yazın 'HESAPLANMAYACAKTIR'\n(3 notu '0' yazamazsınız).", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}
