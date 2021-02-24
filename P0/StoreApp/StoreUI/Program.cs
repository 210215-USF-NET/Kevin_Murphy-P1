using System;
using Serilog;
using StoreBL;
using StoreDL;

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
            IMenu menuLogIn = new LogIn(new PartsBL(new StoreRepoFile()));
            menuLogIn.Start();

            
        }
    }
}
