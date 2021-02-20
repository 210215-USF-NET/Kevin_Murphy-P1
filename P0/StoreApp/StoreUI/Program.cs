using System;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {

            
            IMenu menuLogIn = new LogIn();
            menuLogIn.Start();
            IMenu menuMain = new MainMenu();
            menuMain.Start();
        }
    }
}
