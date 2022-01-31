using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_01_28_Opening_weekend
{
    class Film
    {
        public string eredetiCim { get; set; }
        public string magyarCim { get; set; }
        public DateTime bemutato { get; set; }
        public string forgalmazo { get; set; }
        public int bevetel { get; set; }
        public int latogatok { get; set; }

        public Film(string s) {
            string[] db = s.Split(';');
            eredetiCim = db[0];
            magyarCim = db[1];
            bemutato = DateTime.Parse(db[2]);
            forgalmazo = db[3];
            bevetel = int.Parse(db[4]);
            latogatok = int.Parse(db[5]);
        }
    }
}
