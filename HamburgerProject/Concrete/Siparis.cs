using HamburgerProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.Concrete
{
    public class Siparis
    {
        public Siparis()
        {
            Sos = new List<EkstraMalzeme>();
        }
        public Menu Menu { get; set; }
        public List<EkstraMalzeme> Sos { get; set; }
        public Boy Boy { get; set; }
        public int Adet { get; set; }
        private double _toplamFiyat;

        public double ToplamFiyat
        {
            get 
            {
                _toplamFiyat = Menu.Fiyat;
                switch (this.Boy)
                {
                    case Boy.Orta:
                        _toplamFiyat *= 1.1;
                        break;
                    case Boy.Büyük:
                        _toplamFiyat *= 1.2;
                        break;
                }
                foreach (EkstraMalzeme ekstraMalzeme in this.Sos)
                {
                    _toplamFiyat += ekstraMalzeme.Fiyat;
                }
                _toplamFiyat *= this.Adet;
                return _toplamFiyat;
            }
        }


        public override string ToString()
        {
            string siparisBilgi = $"{this.Adet} {this.Menu.Ad}";
            foreach (EkstraMalzeme ekstraMalzeme in this.Sos)
            {
                siparisBilgi += ", " + ekstraMalzeme.Ad;
            }
            siparisBilgi += ", " + this.Boy+"==> Toplam: "+this.ToplamFiyat.ToString("C2");

            return siparisBilgi; 
        }

        public double EkstraMalzemeGeliriGetir()
        {
            double toplam = 0;
            foreach (EkstraMalzeme ekstraMalzeme in this.Sos)
            {
                toplam += ekstraMalzeme.Fiyat;
            }
            return toplam;
        }
    }
}
