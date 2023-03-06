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
    public partial class ogretmengiris : Form
    {
        public ogretmengiris()
        {
            InitializeComponent();
        }

        private void ogretmengiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            repository repository = new repository();
           login result=repository.ogretmengiris(txt_kulad.Text ,txt_sifre.Text);
            if(result.status==loginstatus.basarili)
            {
                OgretmenDetay ogretmenDetay = new OgretmenDetay();
                ogretmenDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("GİRDİĞİNİZ BİLGİLER HATALIDIR.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
