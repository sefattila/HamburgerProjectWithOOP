using HamburgerProject.Concrete;
using HamburgerProject.Enums;
using HamburgerProject.Utilitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamburgerProject
{
    public partial class SiparisEkrani : Form
    {
        public SiparisEkrani()
        {
            InitializeComponent();
        }
        List<Siparis> _alinanSiparisler = new List<Siparis>(); //field
        double _toplam = 0;
        private void SiparisEkrani_Load(object sender, EventArgs e)
        {
            //cboxMenu.DataSource = MainMenu.Menuler;  foreach le aynı işlem
            foreach (Menu menu in MainMenu.Menuler)
            {
                cboxMenu.Items.Add(menu);

            }

            foreach (EkstraMalzeme ekstraMalzeme in MainMenu.EkstraMalzeme)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = ekstraMalzeme.Ad;
                checkBox.Tag = ekstraMalzeme;

                flpEkstraMalzemeler.Controls.Add(checkBox);
            }

            rbKucuk.Checked = true;
            cboxMenu.SelectedIndex = 0;
            nudAdet.Value = 1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Siparis siparis = new Siparis();
            try
            {
                //Bu kısmı encapsulation ile de kontol ettik
                //adet 0 girilirse hiç bir şey yapmasın o yüzden return; yazdık
                //if (nudAdet.Value <= 0) 
                //{
                //    MessageBox.Show("Adet 0 Girdiniz");
                //    return;
                //}
                siparis.Menu = (Menu)cboxMenu.SelectedItem; //cast işlemi
                foreach (CheckBox checkBox in flpEkstraMalzemeler.Controls)
                {
                    EkstraMalzeme ekstraMalzeme = (EkstraMalzeme)checkBox.Tag;
                    siparis.Sos.Add(ekstraMalzeme);
                }

                if (rbOrta.Checked)
                {
                    siparis.Boy = Boy.Orta;
                }
                else if (rbBuyuk.Checked)
                {
                    siparis.Boy = Boy.Büyük;
                }
                else siparis.Boy = Boy.Küçük;

                //ikinci yöntem group box içinde dönerek yazabiliriz
                //foreach (RadioButton radioButton in groupBox1.Controls)
                //{
                //    if (radioButton.Checked)
                //    {
                //        siparis.Boy = (Boy)Enum.Parse(typeof(Boy), radioButton.Text);
                //    }
                //}

                siparis.Adet = (int)nudAdet.Value;
                _alinanSiparisler.Add(siparis);
                lboxSiparisler.Items.Add(siparis);
                _toplam += siparis.ToplamFiyat;
                lblToplam.Text = _toplam.ToString("C2");
                Helper.Temizle(this.Controls);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Helper.Temizle(this.Controls);
        }

        private void btnSiparisOnay_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Siparişi onalıyor musunuz?", "Onay Mesajı", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                //MainMenu.OnaylananSiparisler.AddRange(_alinanSiparisler); ikiside aynı şey
                foreach (Siparis siparis in _alinanSiparisler)
                {
                    MainMenu.OnaylananSiparisler.Add(siparis);
                }
                _alinanSiparisler.Clear();
                lboxSiparisler.Items.Clear();
                _toplam = 0;
                lblToplam.Text = "0.00";
            }
        }
    }
}
