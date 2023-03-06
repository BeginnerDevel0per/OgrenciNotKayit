using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciNotKayit
{
    public class login
    {
        public int id { get; set; }
        public string kullaniciadi { get; set; }
        public string sifre { get; set; }

        public loginstatus status { get; set; }
    }
}
