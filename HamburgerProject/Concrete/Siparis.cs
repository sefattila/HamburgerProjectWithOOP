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
        private Menu _menu;
        private Boy _boy;
        private int _adet;
        public Siparis()
        {
            Sos = new List<EkstraMalzeme>();
        }
        public Menu Menu
        {
            get { return _menu; }
            set
            {
                if (value != null) _menu = value;
                else throw new Exception("Menu Seçimi Yapınız");
            }
        }
        public List<EkstraMalzeme> Sos { get; set; }
        public Boy Boy
        {
            get { return _boy; }
            set
            {
                if (value != null) _boy = value;
                else throw new Exception("Boy Seçimi Yapınız");
            }
        }
        public int Adet {
            get { return _adet; }
            set
            {
                if (value >= 1) _adet = value;
                else throw new Exception("Adet Sayısı 1'den Küçük Olamaz");
            }
        }
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
            siparisBilgi += ", " + this.Boy + "==> Toplam: " + this.ToplamFiyat.ToString("C2");

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
