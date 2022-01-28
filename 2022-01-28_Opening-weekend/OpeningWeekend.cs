using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022_01_28_Opening_weekend
{
    class OpeningWeekend
    {
        static void Main(string[] args) {
            List<Film> filmek = new List<Film>();
            File.ReadAllLines("nyitohetvege.txt").Skip(1).ToList().ForEach((s) => {
                filmek.Add(new Film(s));
            });
            Console.ReadKey();
        }
    }
}
