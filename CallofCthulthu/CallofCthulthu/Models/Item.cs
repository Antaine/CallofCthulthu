using System;

namespace CallofCthulthu.Models
{
    public class Item
    {
        //Facts
        public string Id { get; set; }
        public string Player { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Res { get; set; }
        public string Bp { get; set; }
        public string Ocu { get; set; }
        public string Hp { get; set; }
        public int Mp { get; set; }
        public int CrMin { get; set; }
        public int CrMax { get; set; }
        public int OcuPoint { get; set; }



        //Stats
        public int Str { get; set; }
        public int Con { get; set; }
        public int Siz { get; set; }
        public int Dex { get; set; }
        public int App { get; set; }
        public int Int { get; set; }
        public int Pow { get; set; }
        public int Edu { get; set; }
        public int Luck { get; set; }
        public int Sanity { get; set; }
    }
}