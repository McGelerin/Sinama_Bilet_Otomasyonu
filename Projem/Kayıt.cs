using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projem
{
    public class Kayıt
    {
        public string Film_ad { get; set; }
        public string Film_tur{ get; set; }

        public string Film_yönetmen { get; set; }



        public Kayıt (string f_ad, string f_tur, string f_yönetmen)
        {
            this.Film_ad = f_ad;
            this.Film_tur = f_tur;
            this.Film_yönetmen = f_yönetmen;
        }
    }
}
