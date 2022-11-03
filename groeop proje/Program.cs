using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace groeop_proje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int j = 0;
            int l = 0;
            int controleTitileJalle = 0;
            int controleTitileLotte = 0;
            bool jelle = true;
            bool lotte = true;
            bool titleJelle = false;
            bool titleLotte = false;
            DateTime runTime = new DateTime();
            int minute = runTime.Minute;
            int seconden = runTime.Second;
            Random random = new Random();
            int speedPUJ = 0;
            int speedPUL = 0;
            int afstandPUJ = 0;
            int afstandPUL = 0;
            int rndJ = random.Next(9, 14);
            int rndL = random.Next(7, 12);
            string[] obstakels = {"The Wall", "Fallen Mikado","Muddylicious", "Waterfest", "Terrilifying", "Tobogaaaaaan",
                "Tyre Mania", "Foooorza", "Itsy bitsy Spider", "De Put", "Fear of The Yeti","Finish"};
            int[] afstandInMeter = { 100, 1100, 1500, 1900, 2100, 2400, 2700, 3600, 4000, 4200, 6800, 7000 };
            Console.WriteLine("Druk <enter> om Jelle en Lotte te laten lopen");
            Console.ReadLine();
            Console.Clear();
            while (afstandPUJ <= 7000 || afstandPUL <= 7000)
            {
                seconden++;
                if (seconden == 60)
                {
                    seconden = 0;
                    minute++;
                    rndJ = random.Next(9, 14);
                    rndL = random.Next(7, 12);
                }
                int minute2 = minute;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"****{minute} minuten, {seconden} seconden het gaat loopen****");


                speedPUJ = RunPersonOne(rndJ);
                if (jelle == true)//controle afstand
                {
                    afstandPUJ += speedPUJ;
                }
                if (afstandPUJ > afstandPUL)//controle coller
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (j < 12)
                {
                    if (afstandPUJ >= afstandInMeter[j])//controle obstakel
                    {
                        jelle = false;
                        titleJelle = true;

                    }
                    if (titleJelle == true)//controle obstakel title
                    {
                        Console.WriteLine($"Jele zit momenteel vast aan obstakel {obstakels[controleTitileJalle]}");
                    }
                    if (jelle == false)//controle kans
                    {
                        int kansJelle = random.Next(1, 11);
                        if (kansJelle == 1)
                        {
                            jelle = true;
                            titleJelle = false;
                            controleTitileJalle++;
                            j++;
                        }
                    }
                }
               


                Console.WriteLine($"Jelle:  snelheid:{rndJ}km/uur");
                Console.WriteLine($"        afstand: {afstandPUJ}m");
                speedPUL = RunPersonTwo(rndL);
                if (lotte == true)
                {
                    afstandPUL += speedPUL;
                }
                if (afstandPUL > afstandPUJ)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($"Lotte:  snelheid:{rndL}km/uur");
                Console.WriteLine($"        afstand: {afstandPUL}m");
                if (l < 12)
                {
                    if (afstandPUL >= afstandInMeter[l])//controle obstakel
                    {
                        lotte = false;
                        titleLotte = true;

                    }
                    if (titleLotte == true)//controle obstakel title
                    {
                        Console.WriteLine($"Lotte zit momenteel vast aan obstakel {obstakels[controleTitileLotte]}");
                    }
                    if (lotte == false)//controle kans
                    {

                        int kansLotte = random.Next(1, 6);
                        if (kansLotte == 2 || kansLotte == 3)
                        {
                            lotte = true;
                            titleLotte = false;
                            controleTitileLotte++;
                            l++;
                        }
                    }
                }
                
                Thread.Sleep(10);
                Console.Clear();


            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"****{minute} minuten, {seconden} seconden het gaat****");
            if (afstandPUJ > afstandPUL)
            {
                Console.WriteLine("The Winner Is Jelle");
            }
            else
            {
                Console.WriteLine("The Winner Is Lotte");
            }
            Console.WriteLine(DateTime.Now.AddMinutes(-minute) + " Start Time");
            Console.WriteLine(DateTime.Now+" End time");
            Console.ReadLine();

        }
        private static int RunPersonOne(int rndJelle)
        {

            int distance = rndJelle * 1000 / 3600;

            return distance;

        }



        private static int RunPersonTwo(int rndLotte)
        {
            int distance = rndLotte * 1000 / 3600;

            return distance;

        }
    }
}
