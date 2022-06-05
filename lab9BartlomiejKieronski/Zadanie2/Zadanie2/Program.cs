using System;
using System.Collections.Generic;

namespace Zadanie2
{
    public abstract class Produkt
    {
        private double cena;
        public double getCena()
        {
            return this.cena;
        }
        public Produkt(double cena)
        {
            this.cena = cena;
        }
        public abstract void add(Produkt produkt);
        public abstract double getSuma();
    }
    public class Item : Produkt
    {
        public Item(double cena) : base(cena)
        {

        }
        public override void add(Produkt produkt)
        {
            Console.WriteLine("Nie można dodać produktu do produktu");
        }
        public override double getSuma()
        {
            return getCena();
        }
        
    }
    public class Pudelko : Produkt
    {
        List<Produkt> Produkty = new List<Produkt>();

        public Pudelko(double cena) : base(cena)
        {

        }
        public override void add(Produkt produkt)
        {
            Produkty.Add(produkt);
        }
        public override double getSuma()
        {
            double Suma = getCena();
            foreach(Produkt p in Produkty)
            {
                Suma += p.getSuma();
            }
            return Suma;
        }
    }
    public class Sektor : Produkt
    {
        List<Produkt> Produkty = new List<Produkt>();
        public Sektor(double cena) : base(0)
        {

        }
        public override void add(Produkt produkt)
        {
            Produkty.Add(produkt);
        }
        public override double getSuma()
        {
            double Suma = 0;
            foreach (Produkt p in Produkty)
            {
                Suma += p.getSuma();
            }
            return Suma;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Sektor sektor = new Sektor(10);
            Console.WriteLine(sektor.getSuma());

            Pudelko karton = new Pudelko(5.29);
            Pudelko torba = new Pudelko(5.97);

            Item towar1 = new Item(50.29);
            Item towar2 = new Item(27.34);
            Item towar3 = new Item(43.23);

            sektor.add(karton);
            torba.add(towar2);
            karton.add(towar2);
            torba.add(towar3);
            torba.add(towar1);
            karton.add(torba);

            Console.WriteLine(sektor.getSuma());
        }
    }
}
