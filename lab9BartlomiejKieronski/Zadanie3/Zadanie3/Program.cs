using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadanie3
{
    public interface IPracownik
    {
        public string getName();
        public int Count();
        public void pokazDane(int dane);
    }
    public class Pracownik : IPracownik
    {
        string nazwa;

        public Pracownik(string name)
        {
            this.nazwa = name;
        }
        public int Count()
        {
            return 1;
        }
        public string getName()
        {
            return nazwa;
        }
        public void pokazDane(int dane)
        {
            Console.WriteLine(new string(' ', dane) + getName());
        }
    }
    public class Kierownik : IPracownik, IEnumerable<IPracownik>
    {
        string nazwa;
        List<IPracownik> podwladni = new List<IPracownik>();
        public Kierownik(string name)
        {
            this.nazwa = name;
        }
        public void add(IPracownik pracownik)
        {
            podwladni.Add(pracownik);
        }
        public int Count()
        {
            int elementy = 1;
            foreach (IPracownik pracownik in podwladni)
            {
                elementy += pracownik.Count();
            }
            return elementy;
        }
        public string getName()
        {
            return nazwa;
        }
        public void pokazDane(int dane)
        {
            Console.WriteLine(new string(' ', dane) + getName());
            foreach (IPracownik pracownik in podwladni)
            {
                pracownik.pokazDane(dane + 2);
            }
        }
        public IEnumerator<IPracownik> GetEnumerator()
        {
            return podwladni.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Kierownik k= new("Kierownik");
            Kierownik p = new("prezes");
            Kierownik m = new("menager");

            p.add(k);
            k.add(new Pracownik("pracownik1"));
            k.add(m);
            m.add(new Pracownik("pracownik2"));
            p.add(new Pracownik("pracownik3"));

            Console.WriteLine("\nEnumerator:");
            foreach( IPracownik pracownik in p)
            {
                pracownik.pokazDane(2);
            }
        }
    }
}
