using System;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new PartsMenu();
            menu.Start();
        }
    }
}
