using System;
using Serilog;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //config file 
            var configuation = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //set up DB connection
            string connectionString = configuation.GetConnectionString("StoreDB");
            DbContextOptions<StoreDBContext>options = new DbContextOptionsBuilder<StoreDBContext>()
            .UseSqlServer(connectionString)
            .Options;

            using var context = new StoreDBContext(options);


            var log = new LoggerConfiguration()
                //.WriteTo.Console()
                .WriteTo.File("../logs/Main.txt",rollingInterval: RollingInterval.Day)
                .CreateLogger();
            // Log.Logger = new LoggerConfiguration
            IMenu menuLogIn = new LogIn(new PartsBL(new StoreRepoDB(context,new StoreMapper())));
            menuLogIn.Start();

            
        }
    }
}
