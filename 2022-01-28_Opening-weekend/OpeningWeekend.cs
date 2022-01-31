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

            bool vanFilm = false;
            filmek.ForEach((f) => {
                string[] dbMagyarCim = f.magyarCim.Split(' ');
                string[] dbEredetiCim = f.eredetiCim.Split(' ');
                if (dbMagyarCim[0].StartsWith("W") && dbMagyarCim[1].StartsWith("W") && dbEredetiCim[0].StartsWith("W") && dbEredetiCim[1].StartsWith("W")) {
                    vanFilm = true;
                }
            });

            Console.WriteLine(vanFilm ? "6. feladat: Volt ilyen film!" : "6. feladat: Nem volt ilyen film!");

            Dictionary<string, int> forgalmazoEsFilmek = new Dictionary<string, int>();

            filmek.ForEach((f) => {
                if (!forgalmazoEsFilmek.ContainsKey(f.forgalmazo)) {
                    forgalmazoEsFilmek.Add(f.forgalmazo, 1);
                } else {
                    forgalmazoEsFilmek[f.forgalmazo]++;
                }
            });

            List<string> fileKimenet = new List<string>();
            fileKimenet.Add("forgalmazo;filmekSzama");

            foreach (var f in forgalmazoEsFilmek) {
                if (f.Value > 1) {
                    fileKimenet.Add($"{f.Key};{f.Value}");
                }
            }

            File.WriteAllLines("stat.csv", fileKimenet);

            Console.ReadKey();
        }
    }
}
