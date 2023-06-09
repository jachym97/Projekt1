using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaverecny2Verze1
{
    internal class Vlak
    {
        public string NazevVlaku;
        public double Rychlost;
        public int PocetSouradnic;
        public double DelkaTrasy;
        public int[] SouradniceX;
        public int[] SouradniceY;
        public DateTime[] CasSouradnice;
        public DateTime CasOdjezdu;
   


        public void ZadavejSouradnice()
        {
            Console.Write("Zadejte počet souřadnic: ");
            PocetSouradnic = int.Parse(Console.ReadLine());
            SouradniceX = new int[PocetSouradnic];
            SouradniceY = new int[PocetSouradnic];

            for (int i = 0; i < PocetSouradnic; i++)
            {
                Console.Write("Zadejte souřadnici x: ");
                SouradniceX[i] = int.Parse(Console.ReadLine());
                Console.Write("Zadejte souřadnici y: ");
                SouradniceY[i] = int.Parse(Console.ReadLine());
            }
        }

        public void VypocitejDelkuTrasy()
        {
            DelkaTrasy = 0;
            for (int i = 1; i < PocetSouradnic; i++)
            {
                DelkaTrasy = DelkaTrasy + Math.Sqrt(Math.Pow(SouradniceX[i] - SouradniceX[i - 1], 2) + Math.Pow(SouradniceY[i] - SouradniceY[i - 1], 2));
            }
        }

        public void SrovnejCasySouradnice(Vlak vlak)
        {
            for(int i = 0; i < PocetSouradnic; i++)
            {
                for(int j = 0; j < vlak.PocetSouradnic; j++)
                {
                    if (SouradniceX[i] == vlak.SouradniceX[j] && SouradniceY[i] == vlak.SouradniceY[j] && CasSouradnice[i] == vlak.CasSouradnice[j])
                    {
                        Console.WriteLine("Kolize v bodě: [" + SouradniceX[i] + "," + SouradniceY[i] + "]");
                        Console.WriteLine("Čas: " + CasSouradnice[i]);
                    }
                  
                }
            }
        }

        public void ZadejNazevVlaku()
        {
            Console.Write("Zadejte název vlaku: ");
            NazevVlaku = Console.ReadLine();
        }

        public void VypisSouradniceVlaku()
        {
            Console.WriteLine("Souřadnice vlaku " + NazevVlaku);

            for (int i = 0; i < PocetSouradnic; i++) 
            {
                Console.WriteLine("Souřadnice " + (i+1) + ": [" + SouradniceX[i] + "," + SouradniceY[i] + "]");
            }
        }

        public void ZadejCasOdjezdu()
        {
            DateTime dateTime = DateTime.Now;
            int pocetHodin = -1;
            int pocetMinut = -1;

            while(pocetHodin < 0 || pocetHodin > 23)
            {
                Console.Write("Zadej hodiny (odjezd): ");
                pocetHodin = int.Parse(Console.ReadLine());
            }

            while (pocetMinut < 0 || pocetMinut > 59)
            {
                Console.Write("Zadej minuty (odjezd): ");
                pocetMinut = int.Parse(Console.ReadLine());
            }

            CasOdjezdu = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, pocetHodin, pocetMinut, 00);
        }

        public void ZadejRychlost()
        {
                Console.Write("Zadejte požadovanou průměrnou rychlost vlaku: ");
                Rychlost = double.Parse(Console.ReadLine());
        }

        public void VypocitejCasSouradnice()
        {
            CasSouradnice = new DateTime[PocetSouradnic];
            CasSouradnice[0] = CasOdjezdu;
            DelkaTrasy = 0;
           
            for (int i = 1; i < PocetSouradnic; i++)
            {
                CasSouradnice[i] = CasOdjezdu.AddHours((DelkaTrasy + Math.Sqrt(Math.Pow(SouradniceX[i] - SouradniceX[i - 1], 2) + Math.Pow(SouradniceY[i] - SouradniceY[i - 1], 2))) / Rychlost);
                DelkaTrasy = DelkaTrasy + Math.Sqrt(Math.Pow(SouradniceX[i] - SouradniceX[i - 1], 2) + Math.Pow(SouradniceY[i] - SouradniceY[i - 1], 2));
            }
        }

        public void VypisCasSouradnice()
        {
            for (int i = 0; i < PocetSouradnic; i++)
            {
                Console.WriteLine("Souřadnice " + (i + 1) + ", příjezd v: " + CasSouradnice[i]);
            }
        }

        public string VratRychlost()
        {
            return "Rychlost vlaku " + NazevVlaku + ": " + Rychlost + " km/h";
        }

        public string VratCasOdjezdu()
        {
            return "Odjezd vlaku " + NazevVlaku + ": " + CasOdjezdu.ToShortTimeString();
        }

        public string VratDelkuTrasy()
        {
            return "Délka trasy vlaku " + NazevVlaku + ": " + Math.Round(DelkaTrasy, 3) + " km";
        }


    }
}
