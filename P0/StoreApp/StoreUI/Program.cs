using System;
using Serilog;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {

             var log = new LoggerConfiguration()
                //.WriteTo.Console()
                .WriteTo.File("../logs/Main.txt",rollingInterval: RollingInterval.Day)
                .CreateLogger();
            IMenu menuLogIn = new LogIn();
            menuLogIn.Start();

            log.Information("entering the login menu");
            IMenu menuMain = new MainMenu();
            menuMain.Start();
        }
    }
}
