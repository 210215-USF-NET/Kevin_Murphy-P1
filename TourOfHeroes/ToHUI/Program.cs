using System;
using ToHModels;
namespace ToHUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // add hero method
            Hero newHero = new Hero();
           
            Console.WriteLine("Hello World!");
            Console.WriteLine("What is the heroes name?");
            newHero.HeroName = Console.ReadLine();
            Console.WriteLine("Enter a PH");
            newHero.HP = int.Parse(Console.ReadLine());
            SuperPower newSuperPower = new SuperPower();
            Console.WriteLine("Enter a SuperPower name");
            newSuperPower.Name = Console.ReadLine();
            Console.WriteLine("Enter a SuperPower description ");
            newSuperPower.Description = Console.ReadLine();
            Console.WriteLine("Enter a SuperPower damage ");
            newSuperPower.Damage = int.Parse(Console.ReadLine());
            Console.WriteLine("Set the super hero's element: ");
            newHero.SuperPower = newSuperPower;
            newHero.ElementType = Enum.Parse<Element>(Console.ReadLine());
            
            Console.WriteLine(newHero.SuperPower.Name);
            Console.WriteLine(newHero.HeroName);
            Console.WriteLine(newHero.HP);


        }
    }
}
