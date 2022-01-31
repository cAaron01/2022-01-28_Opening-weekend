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

            Console.WriteLine($"3. feladat: Filmek száma az állományban: {filmek.Count} db");

            long uipBevetel = 0;
            filmek.ForEach((f) => {
                if (f.forgalmazo == "UIP") {
                    uipBevetel += f.bevetel;
                }
            });

            Console.WriteLine($"4. feladat: UIP Duna Film forgalmazó 1. hetes bevételeinek összege: {uipBevetel.ToString("C2")}");

            Film legtobbLatogato = filmek.OrderBy(f => f.latogatok).Last();

            Console.WriteLine("5. feladat: Legtöbb látogató az első héten:");
            Console.WriteLine($"\tEredeti cím: {legtobbLatogato.eredetiCim}");
            Console.WriteLine($"\tMagyar cím: {legtobbLatogato.magyarCim}");
            Console.WriteLine($"\tForgalmazó: {legtobbLatogato.forgalmazo}");
            Console.WriteLine($"\tBevétel az első héten: {legtobbLatogato.bevetel.ToString("C2")}");
            Console.WriteLine($"\tLátogatók száma: {legtobbLatogato.latogatok} fő");
            Console.ReadKey();
        }
    }
}
