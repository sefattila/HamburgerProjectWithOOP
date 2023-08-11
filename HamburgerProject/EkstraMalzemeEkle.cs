using HamburgerProject.Concrete;
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
    public partial class EkstraMalzemeEkle : Form
    {
        public EkstraMalzemeEkle()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //try catch yapılacak
            EkstraMalzeme ekstra= new EkstraMalzeme();
            ekstra.Ad = txtAd.Text;
            ekstra.Fiyat = (double)nudFiyat.Value;
            MainMenu.EkstraMalzeme.Add(ekstra);
            Helper.Temizle(this.Controls);
        }
    }
}
