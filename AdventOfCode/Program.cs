using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //var A1P1 = new Program();
            //A1P1.Aufgabe1Part1();

            //var A1P2 = new Program();
            //A1P2.Aufgabe1Part2();

            //var A2P1 = new Program();
            //A2P1.Aufgabe2Part1();

            //var A2P2 = new Program();
            //A2P2.Aufgabe2Part2();

            //var A3P1 = new Program();
            //A3P1.Aufgabe3Part1();

            //var A3P2 = new Program();
            //A3P2.Aufgabe3Part2();

            var A4P1 = new Program();
            A4P1.Aufgabe4Part1();
        }

        public void Aufgabe1Part1()
        {
            int ZahlVorher;
            int Zaehler = 0;

            string[] Text = File.ReadAllLines("Day1.txt");
            int[] Zahlen = new int[Text.Length];

            for (int i = 0; i < Text.Length; i++)
            {
                Zahlen[i] = Int32.Parse(Text[i]);
            }

            ZahlVorher = Zahlen[0];

            for (int Durchgang = 1; Durchgang < Zahlen.Length; Durchgang++)
            {
                if (ZahlVorher < Zahlen[Durchgang])
                {
                    Zaehler++;
                }
                ZahlVorher = Zahlen[Durchgang];
            }
            Console.WriteLine(Zaehler);
            Console.ReadLine();
        }

        public void Aufgabe1Part2()
        {
            int SummeVorher;
            int SummeJetzt;
            int Zaehler = 0;

            string[] Text = File.ReadAllLines("Day1.txt");
            int[] Zahlen = new int[Text.Length];

            for (int i = 0; i < Text.Length; i++)
            {
                Zahlen[i] = Int32.Parse(Text[i]);
            }

            SummeVorher = Zahlen[0] + Zahlen[0 + 1] + Zahlen[0 + 2];

            for (int Durchgang = 1; Durchgang < Zahlen.Length-2; Durchgang++)
            {
                SummeJetzt = Zahlen[Durchgang] + Zahlen[Durchgang + 1] + Zahlen[Durchgang + 2];
                if (SummeJetzt > SummeVorher)
                {
                    Zaehler++;
                }
                SummeVorher = SummeJetzt;
            }
            Console.WriteLine(Zaehler);
            Console.ReadLine();
        }

        public void Aufgabe2Part1()
        {
            string[] Text = File.ReadAllLines("Day2.txt");

            int Horizontal = 0;
            int Tiefe = 0;

            foreach (var line in Text)
            {
                string[] Zahlen = line.Split(' ');
                if (Zahlen[0] == "forward")
                {
                    Horizontal = Int32.Parse(Zahlen[1]) + Horizontal;
                }
                if (Zahlen[0] == "down")
                {
                    Tiefe = Int32.Parse(Zahlen[1]) + Tiefe;
                }
                if (Zahlen[0] == "up")
                {
                    Tiefe = Tiefe - Int32.Parse(Zahlen[1]);
                }
            }
            Console.WriteLine(Tiefe*Horizontal);
            Console.ReadLine();
        }

        public void Aufgabe2Part2()
        {
            string[] Text = File.ReadAllLines("Day2.txt");

            int Horizontal = 0;
            int Tiefe = 0;
            int Aim = 0;

            foreach (var line in Text)
            {
                string[] Zahlen = line.Split(' ');
                if (Zahlen[0] == "forward")
                {
                    Horizontal = Int32.Parse(Zahlen[1]) + Horizontal;
                    Tiefe = Aim * Int32.Parse(Zahlen[1]) + Tiefe;
                }
                if (Zahlen[0] == "down")
                {
                    Aim = Int32.Parse(Zahlen[1]) + Aim;
                }
                if (Zahlen[0] == "up")
                {
                    Aim = Aim - Int32.Parse(Zahlen[1]);
                }
            }
            Console.WriteLine(Tiefe * Horizontal);
            Console.ReadLine();
        }

        public void Aufgabe3Part1()
        {
            string[] Text = File.ReadAllLines("Day3.txt");

            int Laenge = Text[0].Length;
            int value0;
            int value1;
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < Laenge; i++)
            {
                value0 = 0;
                value1 = 0;
                for (int x = 0; x < Text.Length; x++)
                {
                    if (Text[x][i] == '0')
                    {
                        value0++;
                    }
                    if (Text[x][i] == '1')
                    {
                        value1++;
                    }
                }
                if (value0 > value1)
                {
                    gamma = gamma + "0";
                    epsilon = epsilon + "1";
                } else
                {
                    gamma = gamma + "1";
                    epsilon = epsilon + "0";
                }
            }
            int ergebnis = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            Console.WriteLine(ergebnis);
            Console.ReadLine();
        }

        public void Aufgabe3Part2()
        {
            string[] Text = File.ReadAllLines("Day3.txt");

            int Laenge = Text[0].Length;
            int value0;
            int value1;
            long oxygen;
            long co2;

            for (int i = 0; i < Laenge; i++)
            {
                value0 = 0;
                value1 = 0;
                for (int x = 0; x < Text.Length; x++)
                {
                    if (Text[x][i] == '0')
                    {
                        value0++;
                    }
                    if (Text[x][i] == '1')
                    {
                        value1++;
                    }
                }
                if (value1 >= value0)
                {
                    for (int x = 0; x < Text.Length; x++)
                    {
                        if (Text[x][i] == '0' && Text.Length != 1)
                        {
                            Array.Clear(Text, x, 1);
                            for (int y = x + 1; y < Text.Length; y++)
                            {
                                Text[y-1] = Text[y];
                            }
                            Array.Resize(ref Text, Text.Length - 1);
                            x = x - 1;
                        }
                    }
                }
                if (value1 < value0)
                {
                    for (int x = 0; x < Text.Length; x++)
                    {
                        if (Text[x][i] == '1' && Text.Length != 1)
                        {
                            Array.Clear(Text, x, 1);
                            for (int y = x + 1; y < Text.Length; y++)
                            {
                                Text[y - 1] = Text[y];
                            }
                            Array.Resize(ref Text, Text.Length - 1);
                            x = x - 1;
                        }
                    }
                }
            }
            oxygen = Convert.ToInt64(Text[0], 2);
            Console.WriteLine(Text[0]);

            Text = File.ReadAllLines("Day3.txt");


            for (int i = 0; i < Laenge; i++)
            {
                value0 = 0;
                value1 = 0;
                for (int x = 0; x < Text.Length; x++)
                {
                    if (Text[x][i] == '0')
                    {
                        value0++;
                    }
                    if (Text[x][i] == '1')
                    {
                        value1++;
                    }
                }
                if (value1 >= value0)
                {
                    for (int x = 0; x < Text.Length; x++)
                    {
                        if (Text[x][i] == '1' && Text.Length != 1)
                        {
                            //var test = from line in Text
                            //           where line[i] == '1'
                            //           select line;
                            Array.Clear(Text, x, 1);
                            for (int y = x + 1; y < Text.Length; y++)
                            {
                                Text[y - 1] = Text[y];
                            }
                            Array.Resize(ref Text, Text.Length - 1);
                            x = x - 1;
                        }
                    }
                }
                if (value1 < value0)
                {
                    for (int x = 0; x < Text.Length; x++)
                    {
                        if (Text[x][i] == '0' && Text.Length != 1)
                        {
                            Array.Clear(Text, x, 1);
                            for (int y = x + 1; y < Text.Length; y++)
                            {
                                Text[y - 1] = Text[y];
                            }
                            Array.Resize(ref Text, Text.Length - 1);
                            x = x - 1;
                        }
                    }
                }
            }

            co2 = Convert.ToInt64(Text[0], 2);
            Console.WriteLine(Text[0]);

            Console.WriteLine(oxygen +"*"+ co2 +"="+ oxygen * co2);
            Console.ReadLine();
        }

        public void Aufgabe4Part1()
        {
            string[] Text = File.ReadAllLines("Day4.txt");

            string[] Ausgewaehlt = Text[0].Split(',');
            int[] Chosen = new int[Ausgewaehlt.Length];

            for (int i = 0; i < Ausgewaehlt.Length; i++)
            {
                Chosen[i] = Int32.Parse(Ausgewaehlt[i]);
            }



            Console.ReadLine();
        }
    }
}
