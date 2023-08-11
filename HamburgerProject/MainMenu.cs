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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            OnaylananSiparisler = new List<Siparis>();
        }
        //property
        public static List<Menu> Menuler = new List<Menu>()
        {
            //uygulama açıldığında iki adet menüm olmasını istiyorum
            new Menu()
            {
                Ad="Whooper",
                Fiyat=120
            },
            new Menu()
            {
                Ad="Big King",
                Fiyat=120
            }
        };
        public static List<EkstraMalzeme> EkstraMalzeme = new List<EkstraMalzeme>()
        {
            //uygulama açıldığında iki adet menüm olmasını istiyorum
            new EkstraMalzeme()
            {
                Ad="Ketçap",
                Fiyat=10
            },
            new EkstraMalzeme()
            {
                Ad="Mayonez",
                Fiyat=12
            }
        };
        public static List<Siparis> OnaylananSiparisler;

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            SiparisEkrani siparisEkrani= new SiparisEkrani();
            EkranOlustur(siparisEkrani);
        }

        private void siparişOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EkranOlustur(new SiparisEkrani()); //bu şelidede metot içinde gönderebiliriz
        }

        private void siparişleriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EkranOlustur(new AlinanSiparislerEkrani());
        }

        private void menuEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EkranOlustur(new MenuEklemeEkrani());
        }

        private void ekstraMalzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EkranOlustur(new EkstraMalzemeEkle());
        }
        private void EkranOlustur(Form form)
        {
            FormlariKapat();
            form.MdiParent= this;
            form.Dock= DockStyle.Fill;
            this.Width= form.Width+30;
            this.Height = form.Height + 80;
            form.Show();
        }

        private void FormlariKapat()
        {
            Form[] forms = this.MdiChildren;
            foreach (Form form in forms)
            {
                form.Close();
            }
        }
    }
}
