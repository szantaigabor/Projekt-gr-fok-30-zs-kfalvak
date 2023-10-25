using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _19f_Csucslistas_graf
{
    internal class Program
    {
        class Szomszedsagi_listas_graf
        {
            List<List<int>> szomszedsagi_lista;

            public Szomszedsagi_listas_graf()
            {
                szomszedsagi_lista = new List<List<int>>();


                string sor = Console.ReadLine();
                string[] sortomb = sor.Split(' ');
                int N = int.Parse(sortomb[0]); // csúcsok száma
                int M = int.Parse(sortomb[1]); // élek száma

                for (int i = 0; i < N+1; i++) // csúcsszám db üres listát létrehozunk
                {
                    szomszedsagi_lista.Add(new List<int>());
                }

                for (int i = 0; i < M; i++) // élek számaszor pakolunk bele szomszédokat
                {
                    sor = Console.ReadLine();
                    sortomb = sor.Split(' ');
                    int innen = int.Parse(sortomb[0]);
                    int ide = int.Parse(sortomb[1]);
                    szomszedsagi_lista[innen].Add(ide);
                    szomszedsagi_lista[ide].Add(innen);
                }
            }
            List<int> zsakfalvak;
            public List<int> zsakfalu()
            {
                List<int> zsakfalvak = new List<int>();

                for (int i = 1; i < szomszedsagi_lista.Count; i++)
                {
                    if (szomszedsagi_lista[i].Count==1)
                    {
                        zsakfalvak.Add(i);
                    }
                }
                /** /
                for (int i = 0; i < zsakfalvak.Count; i++)
                {
                    Console.WriteLine(zsakfalvak[i]);
                }
                /**/
                return zsakfalvak;
            }

            public int másik(List<int> szomszedok, int honnan)
            {
                if (szomszedok.Count==2)
                {
                    if (szomszedok[0]==honnan)
                    {
                        return szomszedok[1];
                    }
                    else
                    {
                        return szomszedok[0];
                    }
                }
                else
                {
                    return -1;
                }
            }

            public int leghosszabb_lánc_számláló(int zsakfalu)
            {
                int előző = zsakfalu;
                int aktuális_elem= szomszedsagi_lista[zsakfalu][0];
                /** /
                if (zsakfalvak.Count>0)
                {
                    aktuális_elem = szomszedsagi_lista[zsakfalu][0];
                }
                else
                {
                    aktuális_elem = -1;
                    return -1;
                }
                /**/
                int darab = 1;
                while (szomszedsagi_lista[aktuális_elem].Count==2)
                {
                    int temp = aktuális_elem;
                    aktuális_elem= másik(szomszedsagi_lista[aktuális_elem], előző);
                    előző = temp;
                    darab++;
                }
                return darab;
            }
            public List<int> leghosszabb(List<int> zsakfalvak)
            {
                List<int> leghosszabb_kezdetek= new List<int>();
                int leghosszabb_szám;
                if (zsakfalvak.Count>0)
                {
                    leghosszabb_szám = leghosszabb_lánc_számláló(zsakfalvak[0]);
                }
                else
                {
                    leghosszabb_kezdetek.Add(-1);
                    return leghosszabb_kezdetek;
                }
                for (int i = 1; i < zsakfalvak.Count; i++)
                {
                    if (leghosszabb_lánc_számláló(zsakfalvak[i])>leghosszabb_szám)
                    {
                        leghosszabb_szám = leghosszabb_lánc_számláló( zsakfalvak[i]);

                    }
                }
                for (int i = 0; i < zsakfalvak.Count; i++)
                {
                    if (leghosszabb_lánc_számláló(zsakfalvak[i])==leghosszabb_szám)
                    {
                        leghosszabb_kezdetek.Add(zsakfalvak[i]);
                    }

                }
                return leghosszabb_kezdetek;
            }
 

            public void Diagnosztika()
            {
                Console.WriteLine("-------------------------------------------------");
                for (int i = 1; i < szomszedsagi_lista.Count; i++)
                {
                    string tartalom = String.Join(", ", szomszedsagi_lista[i]);

                    Console.WriteLine($"[{i}]: [{tartalom}]");
                }
                Console.WriteLine("-------------------------------------------------");
            }

            //írj egy függvényt, ami egy zsákfaluból elindul addig, amíg lehet, és számolja, hogy hányat lépett


        }

        static void Main(string[] args)
        {
            Szomszedsagi_listas_graf graf = new Szomszedsagi_listas_graf();
            //graf.Diagnosztika();
            List<int> falvak = graf.zsakfalu();
            List<int> kezdetek = new List<int>();
            int számláló =-1;
            //--------------------------------------
            if (falvak.Count > 0)
            {
                kezdetek = graf.leghosszabb(falvak);
                számláló = graf.leghosszabb_lánc_számláló(kezdetek[0]);
            }
            //Console.WriteLine("-------------------");
            Console.WriteLine(számláló);
            for (int i = 0; i < kezdetek.Count; i++)
            {
                Console.Write(kezdetek[i]+" ");
            }
            //Console.WriteLine("_____________________");
            //---------------------------------------


            /** /
            Console.WriteLine(számláló);
            Console.WriteLine("_____________________");
            int result =graf.leghosszabb(falvak);
            Console.WriteLine(result);
            /**/
        }
    }
}
/** /
10 10
1 2
2 3
3 4
4 5
5 6
5 7
3 7
7 8
8 9
10 9

/**/