using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace WindowsFormsApplication1
{
    public class Combination
    {
        private int[] Vector; //duży zbiór (tablica)
        private int[] SubVector; //podzbiór
        private int[] RemaindeVector; //pozostałe elementy (reminde - reszta)
        private int Count; //liczba elementów podzbiorów 
        private int SubCount; //liczba elementów podzbiorów 
        public int GetCount()
        {
            return Count;
        }

        public int GetSubCount()
        {
            return SubCount;
        }

        public int[] GetVector()
        {
            return Vector;
        }

        public int[] GetSubVector()
        {
            for (int i = 0; i < SubCount; i++)
            {
                SubVector[i] = Vector[i];// + 1;
            }
            return SubVector;
        }
        public int[] GetRemaindeVector()
        {
            for (int i = SubCount; i < Vector.Length; i++)
            {
                 RemaindeVector[i - SubCount] = Vector[i];
            }
            return RemaindeVector;
        }
        public override String ToString()
        {
            String Result = "";
            String sComma = "";
            for (int i = 0; i < SubCount; i++)
            {
                Result = Result + sComma + GetSubVector()[i];
                sComma = ", ";
            }
            return Result;
        }
        public String ToStringAll()
        {
            String Result = "";
            String sComma = "";
            for (int i = 0; i < Count; i++)
            {
                if (i == SubCount)
                    Result = Result + ";;";
                Result = Result + sComma + GetVector()[i];
                sComma = ";";
            }
            return Result;
        }
        public void Reset()// inicjalizowanie elementów tablicy (dużej)
        {
            for (int i = 0; i < GetCount(); i++)
            {
                Vector[i] = i;
            }
        }
       
        public Combination(int ACount, int ASubCount) //Konstruktor ACount - liczba elementów dużego zbioru, ASubCount - liczba elem. podzbioru
        {
            Vector = new int[ACount]; //tworzenie tablicy zawierqjącej wszystkie elementy
            SubVector = new int[ASubCount]; 
            RemaindeVector = new int[ACount - ASubCount];            
            Count = ACount;
            SubCount = ASubCount;
            Reset();
        }
        public bool Next()
        {
            int i = 0;
            bool KolejnKomb = false;
            while (Vector[i] < GetCount())
            {
                if (i < SubCount - 1)
                {
                    if (Vector[i] + 1 < Vector[i + 1])
                    {
                        Vector[i] = Vector[i] + 1;
                        for (int j = 0; j < i; j++)
                            Vector[j] = j;
                        KolejnKomb = true;
                        break;
                    }
                    else
                        i = i + 1;
                }
                else if (Vector[i] + 1 < GetCount())
                {
                    Vector[i] = Vector[i] + 1;
                    for (int j = 0; j < i; j++)
                        Vector[j] = j;
                    KolejnKomb = true;
                    break;
                }
                else
                    Vector[i] = Vector[i] + 1;
            }
            if (KolejnKomb)
            {
                int k = SubCount;
                for (int l = 0; l < GetCount(); l++)
                {
                    bool WPodzb = false;
                    for (int m = 0; m < SubCount; m++)
                        if (Vector[m] == l)
                            WPodzb = true;
                    if (!WPodzb)
                    {
                        Vector[k] = l;
                        k++;
                    }
                }
                return true;
            }
            return false;
        }
    }
    public class Permutation
    {
        private int[] Vector;
        public int GetCount()
        {
            return Vector.Length;
        }


        public int[] GetVector()
        {
            return Vector;
        }

        public override String ToString()
        {
            String Result = "";
            String sComma = "";
            for (int i = 0; i < GetCount(); i++)
            {
                Result = Result + sComma + GetVector()[i];
                sComma = ", ";
            }
            return Result;
        }
        public Permutation(int ACount)
        {
            Vector = new int[ACount];
            for (int i = 0; i < ACount; i++)
            {
                Vector[i] = i;
            }
        }
        public bool Next() //przestawia elementy dużej tablicy
        {
            int n = GetCount() - 1;
            bool dalej = true;
            int k = n - 1;
            while ((k >= 0) && dalej)
            {
                if (Vector[k + 1] > Vector[k])
                {
                    dalej = false;
                    int b = Vector[k + 1];
                    int l = k + 1;
                    for (int i = k + 1; i <= n; i++)
                    {
                        if ((Vector[i] > Vector[k]) && (Vector[i] < b))
                        {
                            b = Vector[i];
                            l
                                = i;
                        }
                    }
                    Vector[l] = Vector[k];
                    Vector[k] = b;
                    for (int i = 0; i < Math.Round((double)(n - k) / 2); i++)
                    {
                        b = Vector[n - i];
                        Vector[n - i] = Vector[k + i + 1];
                        Vector[k + i + 1] = b;
                    }
                    k = n - 1;
                }
                else
                    k = k - 1;
            }
            if (k >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return true;
        }
    }

    public class Engine: Object
    {   public DateTime Data;
        public int Id002;
        public ObsadaDyzurow obsadaDyzurow;
        Grafik grafikTmp;
        Grafik grafikBest;
        ListaPracownikow listaPracownikow;
        Combination combination7;
        Combination combination8;
        Combination combination9;
        int iStan;
        int iObsada7;
        int iObsada8;
        int iObsada9;
        int iObsada10;
        NpgsqlConnection connection;
        ListaPracownikow RemaindePracownicy7;
        ListaPracownikow RemaindePracownicy8;
        ListaPracownikow RemaindePracownicy9;
        public Engine(NpgsqlConnection AConnection)
        {
            connection = AConnection;
            obsadaDyzurow = new ObsadaDyzurow(AConnection);
            listaPracownikow = new ListaPracownikow(AConnection);
            
        }
        public void AssignGrafik(Grafik AGrafik) //zapisywanie do obiektu AGrafik aktualnego rozwiązania 
        {
            if (AGrafik.listaPracownikow7.Items.Count() == 0) //jeżeli listaPracownikow7 jest pusta dodajemy do niej odpowiedną liczbę pracowników (bez danych)
            {
                for (int ii = 0; ii < iObsada7; ii++)
                {
                    AGrafik.listaPracownikow7.Items.Add(new Pracownik(connection));
                }
            }
            if (AGrafik.listaPracownikow8.Items.Count() == 0)//jeżeli listaPracownikow8 jest pusta dodajemy do niej odpowiedną liczbę pracowników (bez danych)
            {
                for (int ii = 0; ii < iObsada8; ii++)
                {
                    AGrafik.listaPracownikow8.Items.Add(new Pracownik(connection));
                }
            }
            if (AGrafik.listaPracownikow9.Items.Count() == 0)//jeżeli listaPracownikow7 jest pusta dodajemy do niej odpowiedną liczbę pracowników (bez danych)
            {
                for (int ii = 0; ii < iObsada9; ii++)
                {
                    AGrafik.listaPracownikow9.Items.Add(new Pracownik(connection));
                }
            }
            if (AGrafik.listaPracownikow10.Items.Count() == 0)//jeżeli listaPracownikow10 jest pusta dodajemy do niej odpowiedną liczbę pracowników (bez danych)
            {
                for (int ii = 0; ii < iObsada10; ii++)
                {
                    AGrafik.listaPracownikow10.Items.Add(new Pracownik(connection));
                }
            }
            if (RemaindePracownicy7.Items.Count() == 0)//jeżeli RemaindePracownicy7 jest pusta dodajemy do niej odpowiedną liczbę pracowników (bez danych)
            {
                for (int ii = 0; ii < iStan - iObsada7; ii++)
                {
                    RemaindePracownicy7.Items.Add(new Pracownik(connection));
                }
            }
            if (RemaindePracownicy8.Items.Count() == 0)//jeżeli RemaindePracownicy8 jest pusta dodajemy do niej odpowiedną liczbę pracowników (bez danych)
            {
                for (int ii = 0; ii < iStan - iObsada7 - iObsada8; ii++)
                {
                    RemaindePracownicy8.Items.Add(new Pracownik(connection));
                }
            }
            if (RemaindePracownicy9.Items.Count() == 0)//jeżeli RemaindePracownicy9 jest pusta dodajemy do niej odpowiedną liczbę pracowników (bez danych)
            {
                for (int ii = 0; ii < iStan - iObsada7 - iObsada8 - iObsada9; ii++)
                {
                    RemaindePracownicy9.Items.Add(new Pracownik(connection));
                }
            }
            for (int ii = 0; ii < iObsada7; ii++)// przepisywanie do listaPracownikow7 danych pracowników z głównej listy pracowników listaPracownikow 
            {                                    // na postawie aktualnej kombinacji w combination7   
                AGrafik.listaPracownikow7.Items[ii].Assign(listaPracownikow.Item(combination7.GetSubVector()[ii]));
            }
            for (int ii = 0; ii < iStan - iObsada7; ii++)
            {
              
                RemaindePracownicy7.Items[ii].Assign(listaPracownikow.Item(combination7.GetRemaindeVector()[ii]));
            }
            for (int ii = 0; ii < iObsada8; ii++)
            {
                AGrafik.listaPracownikow8.Items[ii].Assign(RemaindePracownicy7.Item(combination8.GetSubVector()[ii]));
            }
            for (int ii = 0; ii < iStan - iObsada7 - iObsada8; ii++)
            {
                RemaindePracownicy8.Items[ii].Assign(RemaindePracownicy7.Item(combination8.GetRemaindeVector()[ii]));
            }
            for (int ii = 0; ii < iObsada9; ii++)
            {
                AGrafik.listaPracownikow9.Items[ii].Assign(RemaindePracownicy8.Item(combination9.GetSubVector()[ii]));
            }
            for (int ii = 0; ii < iStan - iObsada7 - iObsada8 - iObsada9; ii++)
            {
                RemaindePracownicy9.Items[ii].Assign(RemaindePracownicy8.Item(combination9.GetRemaindeVector()[ii]));
            }
            for (int ii = 0; ii < iObsada10; ii++)
            {
                AGrafik.listaPracownikow10.Items[ii].Assign(RemaindePracownicy9.Items[ii]);
            }
        }
        public void Start()
        {
            obsadaDyzurow.Load();
            listaPracownikow.fnLoadAvailabledByDate(Data);
            iObsada7 = (int)obsadaDyzurow.dyzury[0].Obsada;
            iObsada9 = (int)obsadaDyzurow.dyzury[2].Obsada;
            iObsada10 = (int)obsadaDyzurow.dyzury[3].Obsada;             
            iObsada8 = listaPracownikow.Count() - iObsada7 - iObsada9 - iObsada10;
            RemaindePracownicy7 = new ListaPracownikow(connection);
            RemaindePracownicy8 = new ListaPracownikow(connection);
            RemaindePracownicy9 = new ListaPracownikow(connection);
            iStan = listaPracownikow.Count();
            combination7 = new Combination(iStan, iObsada7);
            combination8 = new Combination(iStan - iObsada7, iObsada8);
            combination9 = new Combination(iStan - iObsada7 - iObsada8, iObsada9);
            grafikBest = new Grafik(connection);
            grafikBest.Data = Data;
            grafikBest.Id002 = Id002;
            grafikTmp = new Grafik(connection);           
            obsadaDyzurow.dyzury[1].Obsada = iObsada8;
            AssignGrafik(grafikBest);
            grafikBest.BuildAscendingLists();
            while (fnNext())
            {
                AssignGrafik(grafikTmp);
                if (grafikTmp.IsBeterThan(grafikBest))
                {
                    grafikBest.Assign(grafikTmp);
                }
            }
            grafikBest.Save();
        }
        public bool fnNext()
        {
            if (!combination9.Next())
            {
                if (!combination8.Next())
                {
                    if (!combination7.Next())
                    {
                        return false;
                    }
                    else
                    {
                        combination8.Reset();
                        combination9.Reset();
                    }
                }
                else
                {
                    combination9.Reset();
                } 
            }                       
            return true;
        }
    }
}

    