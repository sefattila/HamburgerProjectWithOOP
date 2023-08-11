using HamburgerProject.Concrete;
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
    public partial class AlinanSiparislerEkrani : Form
    {
        public AlinanSiparislerEkrani()
        {
            InitializeComponent();
        }

        private void AlinanSiparislerEkrani_Load(object sender, EventArgs e)
        {
            double ciro = 0;
            double ekstraMalzemeGeliri = 0;
            int satilanUrunAdedi = 0;
            foreach (Siparis siparis in MainMenu.OnaylananSiparisler)
            {
                lboxSiparisler.Items.Add(siparis);
                ciro += siparis.ToplamFiyat;
                ekstraMalzemeGeliri += siparis.EkstraMalzemeGeliriGetir();
                satilanUrunAdedi += siparis.Adet + siparis.Sos.Count;
            }
            lblCiro.Text=ciro.ToString("C2");
            lblToplamSiparis.Text=MainMenu.OnaylananSiparisler.Count.ToString();
            lblEkMalzemeGeliri.Text = ekstraMalzemeGeliri.ToString();
            lblSatilanUrunAdedi.Text = satilanUrunAdedi.ToString();
        }
    }
}
