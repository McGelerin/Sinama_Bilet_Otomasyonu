using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projem
{
    public class Personel_Kayıt
    {
        public string Kullanici_ad { get; set; }
        public string Kullanici_sifre{ get; set; }


        public Personel_Kayıt (string k_ad, string k_sifre)
        {
            this.Kullanici_ad = k_ad;
            this.Kullanici_sifre = k_sifre;
        }

    }
}
