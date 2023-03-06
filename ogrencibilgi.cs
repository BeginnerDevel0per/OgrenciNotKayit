using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciNotKayit
{
    public class ogrencibilgi
    {
        public int id { get; set; }
        public string ogrnumara { get; set; }

        public string ograd { get; set; }

        public string ogrsoyad { get; set; }
        public byte ogrs1 { get; set; }
        public byte ogrs2 { get; set; }
        public byte ogrs3 { get; set; }
        public decimal ortalama { get; set; }

        public string durum { get; set; }

        public loginstatus status { get; set; }
    }
}
