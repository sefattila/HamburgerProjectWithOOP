using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.Abstract
{
    public abstract class Urun
    {
        private string _ad;
        private double _fiyat;
        public string Ad {
            get { return _ad; }
            set
            {
                if (!string.IsNullOrEmpty(value)) _ad = value;
                else throw new Exception("Adı Kısmını Boş Geçemezsiniz");
            }
        }
        public double Fiyat {
            get { return _fiyat; }
            set
            {
                if (value >= 1) _fiyat = value;
                else throw new Exception("Fiyat 0 Girilemez");
            } 
        }
    }
}
