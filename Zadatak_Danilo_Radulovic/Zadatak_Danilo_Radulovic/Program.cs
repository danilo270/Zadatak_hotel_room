using System;
using System.Collections.Generic;

namespace Zadatak_Danilo_Radulovic
{
    class Program
    {
        public static void hotel_zadatak(Tuple<int, int>[] niz_parova, int hotel_rooms)
        {
            int i = 0, j = 0, t_r = 0, i_hotel = 0;
            bool flag = false, flag2 = false;
            char[,] hotel = new char[hotel_rooms, 365];

            while (true)
            {
                flag = false;
                if (t_r == niz_parova.Length)
                {
                    break;
                }
                Tuple<int, int> trenutna_rezervacija = niz_parova[t_r];
                if (trenutna_rezervacija.Item1 > 365 || trenutna_rezervacija.Item1 < 0 || trenutna_rezervacija.Item2 > 365 || trenutna_rezervacija.Item2 < 0)
                {
                    Console.WriteLine("Pogresan format bookinga rezervacija: " + trenutna_rezervacija.Item1 + "," + trenutna_rezervacija.Item2 + " se nece prihvatiti!");
                    t_r++;
                    flag2 = true;
                    continue;
                }
                List<int> lista_rezervacija = new List<int>();
                i = trenutna_rezervacija.Item1;
                j = trenutna_rezervacija.Item2;
                for (int n = i; n <= j; n++)
                {
                    lista_rezervacija.Add(n);
                    if (hotel[i_hotel, n].Equals('x'))
                    {
                        flag = true;
                        lista_rezervacija.Clear();
                        break;
                    }
                }
                if (flag && i_hotel == hotel_rooms - 1)
                {
                    i_hotel = 0;
                    flag = false;
                    Console.WriteLine("Rezervacija:" + t_r.ToString() + " Pocetni datum: " + i + " Krajnji datum: " + j + " nije prosla");
                    t_r++;
                    continue;
                }
                if (flag)
                {
                    i_hotel++;
                }
                else
                {
                    if (i == j)
                    {
                        for (int k = 0; k != hotel_rooms; k++)
                        {
                            if (hotel[k, i] != 'x' && k == hotel_rooms - 1)
                            {
                                hotel[k, i] = 'x';
                            }
                        }
                    }
                    else
                    {
                        foreach (int elem in lista_rezervacija)
                        {
                            hotel[i_hotel, elem] = 'x';
                        }
                    }
                    Console.WriteLine("Rezervacija:" + t_r.ToString() + " Pocetni datum: " + i + " Krajnji datum: " + j + " je prosla");
                    t_r++;
                    i_hotel = 0;
                }
            }
            if (!flag2)
            {
                int max = niz_parova[0].Item2;
                for (int j1 = 0; j1 != niz_parova.Length; ++j1)
                {
                    if (niz_parova[j1].Item2 > max)
                    {
                        max = niz_parova[j1].Item2;
                    }
                }
                Console.Write("     ");
                for (int k = 0; k < max; k++)
                {
                    Console.Write(" Day:" + k + "  ");
                }
                Console.WriteLine("");
                //Console.WriteLine("---------------------------------------------");
                for (int i1 = 0; i1 != hotel_rooms; ++i1)
                {
                    Console.Write("Room " + (i1 + 1) + " ");
                    for (int j1 = 0; j1 != max; ++j1)
                    {
                        Console.Write("" + hotel[i1, j1] + "       ");
                    }
                    Console.WriteLine("");
                    // Console.WriteLine("---------------------------------------------");
                }
            }
        }
        static void Main(string[] args)
        {
            Tuple<int, int>[] niz_parova_negative = { Tuple.Create(-4, 2) };
            int hotel_negative = 1;
            Program.hotel_zadatak(niz_parova_negative, hotel_negative);
            Tuple<int, int>[] niz_parova_range = { Tuple.Create(200, 400) };
            int hotel_roomrange = 1;
            Program.hotel_zadatak(niz_parova_range, hotel_roomrange);
            Tuple<int, int>[] niz_parova0 = { Tuple.Create(1, 3), Tuple.Create(0, 15), Tuple.Create(1, 9), Tuple.Create(2, 5), Tuple.Create(4, 9) };
            int hotel_room0 = 3;
            Program.hotel_zadatak(niz_parova0, hotel_room0);
            Console.WriteLine("");
            Tuple<int, int>[] niz_parova1 = { Tuple.Create(1, 3), Tuple.Create(2, 5), Tuple.Create(1, 9), Tuple.Create(0, 15) };
            int hotel_room1 = 3;
            Program.hotel_zadatak(niz_parova1, hotel_room1);
            Console.WriteLine("");
            Tuple<int, int>[] niz_parova2 = { Tuple.Create(0,5), Tuple.Create(7, 13), Tuple.Create(3, 9), Tuple.Create(5, 7), Tuple.Create(6, 6)
            , Tuple.Create(0, 4)};
            int hotel_room2 = 3;
            Program.hotel_zadatak(niz_parova2, hotel_room2);
            Console.WriteLine("");
            Tuple<int, int>[] niz_parova3 = { Tuple.Create(1,3), Tuple.Create(0, 4), Tuple.Create(2, 3), Tuple.Create(5, 5), Tuple.Create(4, 10)
            , Tuple.Create(10, 10), Tuple.Create(6, 7), Tuple.Create(8, 10), Tuple.Create(8, 9)};
            int hotel_room3 = 2;
            Program.hotel_zadatak(niz_parova3, hotel_room3);
        }
    }
}
