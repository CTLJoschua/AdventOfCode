using System;
using System.Collections.Generic;
using System.Drawing;
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

            //var A5P1 = new Program();
            //A5P1.Aufgabe5Part1();

            //var A5P2 = new Program();
            //A5P2.Aufgabe5Part2(); -------------------------------

            //var A6P1 = new Program();
            //A6P1.Aufgabe6Part1();

            //var A6P2 = new Program();
            //A6P2.Aufgabe6Part2();

            //var A7P1 = new Program();
            //A7P1.Aufgabe7Part1();

            //var A7P2 = new Program();
            //A7P2.Aufgabe7Part2();

            var A8P1 = new Program();
            A8P1.Aufgabe8Part2();

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

            for (int Durchgang = 1; Durchgang < Zahlen.Length - 2; Durchgang++)
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
            Console.WriteLine(Tiefe * Horizontal);
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
                }
                else
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

            Console.WriteLine(oxygen + "*" + co2 + "=" + oxygen * co2);
            Console.ReadLine();
        }

        public void Aufgabe5Part1()
        {
            string[] Text = File.ReadAllLines("Day5.txt");

            string[][] test = new string[Text.Length][];

            int[][] Koordinaten = new int[test.Length][];

            int Differenz = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                test[i] = Text[i].Split(new[] { " -> ", "," }, StringSplitOptions.None);
            }

            for (int i = 0; i < test.Length; i++)
            {
                Koordinaten[i] = new int[4];
                for (int x = 0; x < 4; x++)
                {
                    Koordinaten[i][x] = Int32.Parse(test[i][x]);
                }
            }

            int Netzgröße = 1000;
            int original = 0;

            int[][] Netz = new int[Netzgröße][];

            for (int i = 0; i < Netzgröße; i++)
            {
                Netz[i] = new int[Netzgröße];
                for (int x = 0; x < Netzgröße; x++)
                {
                    Netz[i][x] = 0;
                }
            }

            for (int i = 0; i < Koordinaten.Length; i++)
            {
                if (Koordinaten[i][0] == Koordinaten[i][2] && Koordinaten[i][1] != Koordinaten[i][3])
                {
                    if (Koordinaten[i][1] < Koordinaten[i][3])
                    {
                        original = Koordinaten[i][1];
                        Differenz = Koordinaten[i][3] - Koordinaten[i][1] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][1]++;
                        }
                        Koordinaten[i][1] = original;
                    }
                    if (Koordinaten[i][1] > Koordinaten[i][3])
                    {
                        original = Koordinaten[i][3];
                        Differenz = Koordinaten[i][1] - Koordinaten[i][3] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][3]][Koordinaten[i][0]]++;
                            Koordinaten[i][3]++;
                        }
                        Koordinaten[i][3] = original;
                    }
                    if (Koordinaten[i][1] == Koordinaten[i][3])
                    {
                        Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                    }
                }
                if (Koordinaten[i][1] == Koordinaten[i][3] && Koordinaten[i][0] != Koordinaten[i][2])
                {
                    if (Koordinaten[i][0] < Koordinaten[i][2])
                    {
                        original = Koordinaten[i][0];
                        Differenz = Koordinaten[i][2] - Koordinaten[i][0] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][0]++;
                        }
                        Koordinaten[i][0] = original;
                    }
                    if (Koordinaten[i][0] > Koordinaten[i][2])
                    {
                        original = Koordinaten[i][2];
                        Differenz = Koordinaten[i][0] - Koordinaten[i][2] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][3]][Koordinaten[i][2]]++;
                            Koordinaten[i][2]++;
                        }
                        Koordinaten[i][2] = original;
                    }
                    if (Koordinaten[i][0] == Koordinaten[i][2])
                    {
                        Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                    }
                }
            }

            int Zaehler = 0;

            for (int i = 0; i < Netzgröße; i++)
            {
                for (int x = 0; x < Netzgröße; x++)
                {
                    if (Netz[i][x] >= 2)
                    {
                        Zaehler++;
                    }
                }
            }

            Console.WriteLine(Zaehler);
            Console.ReadLine();
        }

        public void Aufgabe5Part2()
        {
            string[] Text = File.ReadAllLines("Day5.txt");

            string[][] test = new string[Text.Length][];

            int[][] Koordinaten = new int[test.Length][];

            int Differenz = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                test[i] = Text[i].Split(new[] { " -> ", "," }, StringSplitOptions.None);
            }

            for (int i = 0; i < test.Length; i++)
            {
                Koordinaten[i] = new int[4];
                for (int x = 0; x < 4; x++)
                {
                    Koordinaten[i][x] = Int32.Parse(test[i][x]);
                }
            }

            int Netzgröße = 10;
            int original, original2 = 0;
            int diagonalx, diagonaly = 0;
            int gleichdiagonal = 0;

            int[][] Netz = new int[Netzgröße][];

            for (int i = 0; i < Netzgröße; i++)
            {
                Netz[i] = new int[Netzgröße];
                for (int x = 0; x < Netzgröße; x++)
                {
                    Netz[i][x] = 0;
                }
            }

            for (int i = 0; i < Koordinaten.Length; i++)
            {
                diagonalx = Koordinaten[i][0] - Koordinaten[i][2];
                diagonaly = Koordinaten[i][1] - Koordinaten[i][3];
                if (diagonalx == diagonaly)
                {
                    gleichdiagonal = 1;
                }
                else if (diagonalx == diagonaly * (-1))
                {
                    gleichdiagonal = 0;
                }
                else
                {
                    gleichdiagonal = 3;
                }
                if (Koordinaten[i][0] == Koordinaten[i][2] && Koordinaten[i][1] != Koordinaten[i][3] && gleichdiagonal == 3)
                {
                    if (Koordinaten[i][1] < Koordinaten[i][3])
                    {
                        original = Koordinaten[i][1];
                        Differenz = Koordinaten[i][3] - Koordinaten[i][1] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][1]++;
                        }
                        Koordinaten[i][1] = original;
                    }
                    else if (Koordinaten[i][1] > Koordinaten[i][3])
                    {
                        original = Koordinaten[i][3];
                        Differenz = Koordinaten[i][1] - Koordinaten[i][3] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][3]][Koordinaten[i][0]]++;
                            Koordinaten[i][3]++;
                        }
                        Koordinaten[i][3] = original;
                    }
                }
                else if (Koordinaten[i][1] == Koordinaten[i][3] && Koordinaten[i][0] != Koordinaten[i][2] && gleichdiagonal == 3)
                {
                    if (Koordinaten[i][0] < Koordinaten[i][2])
                    {
                        original = Koordinaten[i][0];
                        Differenz = Koordinaten[i][2] - Koordinaten[i][0] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][0]++;
                        }
                        Koordinaten[i][0] = original;
                    }
                    else if (Koordinaten[i][0] > Koordinaten[i][2])
                    {
                        original = Koordinaten[i][2];
                        Differenz = Koordinaten[i][0] - Koordinaten[i][2] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][3]][Koordinaten[i][2]]++;
                            Koordinaten[i][2]++;
                        }
                        Koordinaten[i][2] = original;
                    }
                }
                else if (gleichdiagonal == 1)
                {
                    if (Koordinaten[i][0] < Koordinaten[i][2])
                    {
                        original = Koordinaten[i][0];
                        original2 = Koordinaten[i][1];
                        Differenz = Koordinaten[i][2] - Koordinaten[i][0] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][0]++;
                            Koordinaten[i][1]++;
                        }
                        Koordinaten[i][0] = original;
                        Koordinaten[i][1] = original2;
                    }
                    else if (Koordinaten[i][0] > Koordinaten[i][2])
                    {
                        original = Koordinaten[i][2];
                        original2 = Koordinaten[i][3];
                        Differenz = Koordinaten[i][0] - Koordinaten[i][2] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][3]][Koordinaten[i][2]]++;
                            Koordinaten[i][2]++;
                            Koordinaten[i][3]++;
                        }
                        Koordinaten[i][2] = original;
                        Koordinaten[i][3] = original2;
                    }
                }
                else if (gleichdiagonal == 0)
                {
                    if (Koordinaten[i][0] < Koordinaten[i][1])
                    {
                        original = Koordinaten[i][0];
                        original2 = Koordinaten[i][1];
                        Differenz = Koordinaten[i][1] - Koordinaten[i][0] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][0]++;
                            Koordinaten[i][1]--;
                        }
                        Koordinaten[i][0] = original;
                        Koordinaten[i][1] = original2;
                    }
                    else if (Koordinaten[i][0] > Koordinaten[i][1])
                    {
                        original = Koordinaten[i][0];
                        original2 = Koordinaten[i][1];
                        Differenz = Koordinaten[i][0] - Koordinaten[i][1] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][1]++;
                            Koordinaten[i][0]--;
                        }
                        Koordinaten[i][0] = original;
                        Koordinaten[i][1] = original2;
                    }
                    else if (Koordinaten[i][0] == Koordinaten[i][1] && Koordinaten[i][0] > Koordinaten[i][2])
                    {
                        original = Koordinaten[i][0];
                        original2 = Koordinaten[i][1];
                        Differenz = Koordinaten[i][0] - Koordinaten[i][2] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][1]++;
                            Koordinaten[i][0]--;
                        }
                        Koordinaten[i][0] = original;
                        Koordinaten[i][1] = original2;
                    }
                    else if (Koordinaten[i][0] == Koordinaten[i][1] && Koordinaten[i][0] < Koordinaten[i][2])
                    {
                        original = Koordinaten[i][0];
                        original2 = Koordinaten[i][1];
                        Differenz = Koordinaten[i][0] - Koordinaten[i][3] + 1;
                        for (int x = 0; x < Differenz; x++)
                        {
                            Netz[Koordinaten[i][1]][Koordinaten[i][0]]++;
                            Koordinaten[i][1]--;
                            Koordinaten[i][0]++;
                        }
                        Koordinaten[i][0] = original;
                        Koordinaten[i][1] = original2;
                    }
                }
            }

            int Zaehler = 0;

            for (int i = 0; i < Netzgröße; i++)
            {
                for (int x = 0; x < Netzgröße; x++)
                {
                    if (Netz[i][x] >= 2)
                    {
                        Zaehler++;
                    }
                    Console.Write(Netz[i][x]);
                }
                Console.WriteLine();
            }

            Console.WriteLine(Zaehler);
            Console.ReadLine();
        }

        public void Aufgabe6Part1()
        {
            string[] Text = File.ReadAllLines("Day6.txt");

            string[] Zahlen = Text[0].Split(',');

            int[] FischiAlters = new int[Zahlen.Length];

            for (int i = 0; i < Zahlen.Length; i++)
            {
                FischiAlters[i] = Int32.Parse(Zahlen[i]);
            }

            int FischeAmTag = 0;

            List<int> FischiListe = FischiAlters.ToList();

            FischeAmTag = FischiListe.Count;
            for (int Tag = 1; Tag <= 80; Tag++)
            {
                for (int Fischo = 0; Fischo < FischeAmTag; Fischo++)
                {
                    if (FischiListe[Fischo] > 0)
                    {
                        FischiListe[Fischo]--;
                    }
                    else
                    {
                        FischiListe[Fischo] = 6;
                        FischiListe.Add(9);
                        FischeAmTag++;
                    }
                }
            }
            Console.WriteLine(FischiListe.Count + " Fischos");
            Console.ReadLine();
        }

        public void Aufgabe6Part2()
        {
            string[] Text = File.ReadAllLines("Day6.txt");

            string[] Zahlen = Text[0].Split(',');

            int[] FischiAlters = new int[Zahlen.Length];

            for (int i = 0; i < Zahlen.Length; i++)
            {
                FischiAlters[i] = Int32.Parse(Zahlen[i]);
            }

            long[] TabelleFisch = new long[9];

            for (int i = 0; i < TabelleFisch.Length; i++)
            {
                TabelleFisch[i] = 0;
            }

            for (int i = 0; i < FischiAlters.Length; i++)
            {
                for (int x = 0; x < FischiAlters.Length; x++)
                {
                    if (FischiAlters[x] == i)
                    {
                        TabelleFisch[i]++;
                    }
                }
            }

            long ZwischenVariable = 0;
            long Ergebnis = 0;

            for (int Tag = 1; Tag <= 256; Tag++)
            {
                ZwischenVariable = TabelleFisch[0];
                for (int i = 0; i < TabelleFisch.Length - 1; i++)
                {
                    TabelleFisch[i] = TabelleFisch[i + 1];
                }
                TabelleFisch[8] = ZwischenVariable;
                TabelleFisch[6] = TabelleFisch[6] + ZwischenVariable;
            }

            for (int i = 0; i < TabelleFisch.Length; i++)
            {
                Ergebnis = TabelleFisch[i] + Ergebnis;
            }
            Console.WriteLine(Ergebnis);
            Console.ReadLine();
        }
        public void Aufgabe7Part1()
        {
            string[] Text = File.ReadAllLines("Day7.txt");

            string[] Zahlen = Text[0].Split(',');

            int[] Krebspositionen = new int[Zahlen.Length];

            for (int i = 0; i < Zahlen.Length; i++)
            {
                Krebspositionen[i] = Int32.Parse(Zahlen[i]);
            }

            List<int> Fuels = new List<int>();

            int zwischenfuel = 0;
            int fuel = 0;

            Array.Sort(Krebspositionen);

            for (int i = Krebspositionen[0]; i < Krebspositionen[Krebspositionen.Length - 1]; i++)
            {
                for (int x = 0; x < Krebspositionen.Length; x++)
                {
                    if (i <= Krebspositionen[x])
                    {
                        zwischenfuel = Krebspositionen[x] - i;
                        fuel = fuel + zwischenfuel;
                    }
                    if (i > Krebspositionen[x])
                    {
                        zwischenfuel = i - Krebspositionen[x];
                        fuel = fuel + zwischenfuel;
                    }
                }
                Fuels.Add(fuel);
                fuel = 0;
            }

            int ergebnis = Fuels[0];

            for (int i = 1; i < Fuels.Count; i++)
            {
                if (Fuels[i] < ergebnis)
                {
                    ergebnis = Fuels[i];
                }
            }

            Console.WriteLine(ergebnis);
            Console.ReadLine();
        }

        public void Aufgabe7Part2()
        {
            string[] Text = File.ReadAllLines("Day7.txt");

            string[] Zahlen = Text[0].Split(',');

            int[] Krebspositionen = new int[Zahlen.Length];

            for (int i = 0; i < Zahlen.Length; i++)
            {
                Krebspositionen[i] = Int32.Parse(Zahlen[i]);
            }

            List<long> Fuels = new List<long>();

            long zwischenfuel, zwischenzwischenfuel = 0;
            long fuel = 0;

            Array.Sort(Krebspositionen);

            for (int i = Krebspositionen[0]; i < Krebspositionen[Krebspositionen.Length - 1]; i++)
            {
                for (int x = 0; x < Krebspositionen.Length; x++)
                {
                    if (i <= Krebspositionen[x])
                    {
                        zwischenfuel = Krebspositionen[x] - i;
                        for (int o = 0; o <= zwischenfuel; o++)
                        {
                            zwischenzwischenfuel = o + zwischenzwischenfuel;
                        }
                        fuel = fuel + zwischenzwischenfuel;
                        zwischenzwischenfuel = 0;
                    }
                    if (i > Krebspositionen[x])
                    {
                        zwischenfuel = i - Krebspositionen[x];
                        for (int o = 0; o <= zwischenfuel; o++)
                        {
                            zwischenzwischenfuel = o + zwischenzwischenfuel;
                        }
                        fuel = fuel + zwischenzwischenfuel;
                        zwischenzwischenfuel = 0;
                    }
                }
                Fuels.Add(fuel);
                fuel = 0;
            }

            long ergebnis = Fuels[0];

            for (int i = 1; i < Fuels.Count; i++)
            {
                if (Fuels[i] < ergebnis)
                {
                    ergebnis = Fuels[i];
                }
            }

            Console.WriteLine(ergebnis);
            Console.ReadLine();
        }

        public void Aufgabe8Part1()
        {
            string[] Text = File.ReadAllLines("Day8.txt");

            int Zaehler = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                string[] EineZeile = Text[i].Split(' ');

                if (EineZeile[11].Length == 2 || EineZeile[11].Length == 4 || EineZeile[11].Length == 3 || EineZeile[11].Length == 7)
                {
                    Zaehler++;
                }
                if (EineZeile[12].Length == 2 || EineZeile[12].Length == 4 || EineZeile[12].Length == 3 || EineZeile[12].Length == 7)
                {
                    Zaehler++;
                }
                if (EineZeile[13].Length == 2 || EineZeile[13].Length == 4 || EineZeile[13].Length == 3 || EineZeile[13].Length == 7)
                {
                    Zaehler++;
                }
                if (EineZeile[14].Length == 2 || EineZeile[14].Length == 4 || EineZeile[14].Length == 3 || EineZeile[14].Length == 7)
                {
                    Zaehler++;
                }
            }

            Console.WriteLine(Zaehler);
            Console.ReadKey();
        }

        public void Aufgabe8Part2()
        {
            // EIN ZWEIFELLOS PERFEKTER KOT
            string[] Text = File.ReadAllLines("Day8.txt");

            int Zaehler = 0;
            string Hat6Nicht = "z";
            string ergebnisstring = "";
            string oInString;
            long ergebnis = 0;
            long einergebnis = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                string[] EineZeile = Text[i].Split(' ');
                string[] Zuordnung = new string[10];
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x] != "|")
                    {
                        EineZeile[x] = SortString(EineZeile[x]);
                    }
                }
                //1
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 2)
                    {
                        Zuordnung[1] = EineZeile[x];                        
                    }
                }
                //4
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 4)
                    {
                        Zuordnung[4] = EineZeile[x];
                        
                    }
                }
                //7
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 3)
                    {
                        Zuordnung[7] = EineZeile[x];
                        
                    }
                }
                //8
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 7)
                    {
                        Zuordnung[8] = EineZeile[x];
                        
                    }
                }
                //9
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 6 && (EineZeile[x].Contains(Zuordnung[4][0]) && EineZeile[x].Contains(Zuordnung[4][1]) && EineZeile[x].Contains(Zuordnung[4][2]) && EineZeile[x].Contains(Zuordnung[4][3])) == true)
                    {
                        Zuordnung[9] = EineZeile[x];                       
                    }
                }
                //3
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 5 && (EineZeile[x].Contains(Zuordnung[1][0]) && EineZeile[x].Contains(Zuordnung[1][1])) == true)
                    {
                        Zuordnung[3] = EineZeile[x];
                        
                    }
                }
                //6
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 6 && (EineZeile[x].Contains(Zuordnung[1][0]) && EineZeile[x].Contains(Zuordnung[1][1])) == false)
                    {
                        Zuordnung[6] = EineZeile[x];
                        
                    }
                }
                //0
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 6 && (EineZeile[x].Contains(Zuordnung[6][0]) && EineZeile[x].Contains(Zuordnung[6][1]) && EineZeile[x].Contains(Zuordnung[6][2]) && EineZeile[x].Contains(Zuordnung[6][3]) && EineZeile[x].Contains(Zuordnung[6][4]) && EineZeile[x].Contains(Zuordnung[6][5])) == false && (EineZeile[x].Contains(Zuordnung[9][0]) && EineZeile[x].Contains(Zuordnung[9][1]) && EineZeile[x].Contains(Zuordnung[9][2]) && EineZeile[x].Contains(Zuordnung[9][3]) && EineZeile[x].Contains(Zuordnung[9][4]) && EineZeile[x].Contains(Zuordnung[9][5])) == false)
                    {
                        Zuordnung[0] = EineZeile[x];
                        
                    }
                }
                //5
                if (Zuordnung[6].Contains("a") == false)
                {
                    Hat6Nicht = "a";
                } else if (Zuordnung[6].Contains("b") == false)
                {
                    Hat6Nicht = "b";
                } else if (Zuordnung[6].Contains("c") == false)
                {
                    Hat6Nicht = "c";
                } else if (Zuordnung[6].Contains("d") == false)
                {
                    Hat6Nicht = "d";
                } else if (Zuordnung[6].Contains("e") == false)
                {
                    Hat6Nicht = "e";
                } else if (Zuordnung[6].Contains("f") == false)
                {
                    Hat6Nicht = "f";
                } else if (Zuordnung[6].Contains("g") == false)
                {
                    Hat6Nicht = "g";
                }
                for (int x = 0; x < EineZeile.Length; x++)
                {

                    if (EineZeile[x].Length == 5 && EineZeile[x].Contains(Hat6Nicht) == false)
                    {
                        Zuordnung[5] = EineZeile[x];                        
                    }
                }
                //2
                for (int x = 0; x < EineZeile.Length; x++)
                {
                    if (EineZeile[x].Length == 5 && EineZeile[x] != Zuordnung[5] && EineZeile[x] != Zuordnung[3])
                    {
                        Zuordnung[2] = EineZeile[x];
                    }
                }
                
                for (int x = 11; x < 15; x++)
                {
                    for (int o = 0; o < Zuordnung.Length; o++)
                    {
                        if (EineZeile[x] == Zuordnung[o])
                        {
                            oInString = Convert.ToString(o);
                            ergebnisstring = ergebnisstring + oInString;
                        }
                    }
                }

                einergebnis = Convert.ToInt64(ergebnisstring);
                ergebnis = ergebnis + einergebnis;
                ergebnisstring = "";
            }     

            Console.WriteLine(ergebnis);
            Console.ReadKey();
        }

        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
