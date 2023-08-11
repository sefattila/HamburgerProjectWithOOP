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
    public partial class MenuEklemeEkrani : Form
    {
        public MenuEklemeEkrani()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Menu menu=new Menu();
            menu.Ad=txtAd.Text;
            menu.Fiyat = (double)nudFiyat.Value;
            MainMenu.Menuler.Add(menu);
            Helper.Temizle(this.Controls);
        }
    }
}
