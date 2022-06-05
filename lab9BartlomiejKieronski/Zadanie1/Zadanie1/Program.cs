using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public abstract class MenuComponent{
        public string url;
        public string name;

        public string getUrl()
        {
            return this.url;
        }
        public string getName()
        {
            return this.name;
        }
        public MenuComponent(string url, string name)
        {
            this.url = url;
            this.name = name;
        }
        public abstract void add(MenuComponent component);
        public abstract void displayMenu();
    }
    public class MenuItem : MenuComponent
    {
        public MenuItem(string url, string name) : base(name, url)
        {

        }
        public override void add(MenuComponent component)
        {    
            Console.WriteLine("Brak możliwości dołączenia elementu do liścia");
            
        }
        public override void displayMenu()
        {
            Console.WriteLine(string.Format("Imie:{0}; Url:{1}",this.getName(),this.getUrl()));
        }

    }
    public class Menu : MenuComponent
    {
        List<MenuComponent> subsMenus = new List<MenuComponent>();
        public Menu(string url,string name ) : base(url, name)
        {

        }
        public override void add(MenuComponent menuComponent)
        {
            subsMenus.Add(menuComponent);
        }
        public override void displayMenu()
        {
            Console.WriteLine(string.Format("Imie:{0}; Url:{1}", this.getName(), this.getUrl()));
            foreach(MenuComponent menuComponent in subsMenus)
            {
                menuComponent.displayMenu();
            }
        }
    }
    internal class CompositeTest
    {
        
        static void Main(string[] args)
        {
            Menu menu = new("main","main.com" );
            menu.add(new MenuItem("leaf1","main.com/leaf1"));
            menu.add(new MenuItem("leaf2", "main.com/leaf2"));

            Menu subMenu = new("submenu", "main.com/submenu");
            menu.add(subMenu);
            subMenu.add(new MenuItem("leaf3", "main.com/leaf3"));
            menu.displayMenu();
        }
    }
}
