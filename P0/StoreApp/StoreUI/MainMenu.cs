using StoreModels;
using System;
namespace StoreUI
{
    public class MainMenu : IMenu
    {
        public void Start()
        {
            //get the user name 
            Console.WriteLine("How can we help you today?");
            Console.WriteLine("[0]View your orders?");
            Console.WriteLine("[1]Make a new purchas?");
            Console.WriteLine("[2]Exit?");
            Console.WriteLine("Enter a number");
            string userInput = Console.ReadLine();
           
           
    
        }
    }
}