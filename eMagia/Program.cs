using System;

namespace eMagia
{
    class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to eMagia!");
            var orderus = new Hero();
            var beast1 = new Beast();
            Console.WriteLine(orderus);
            Console.WriteLine(beast1);

            BattleMethods.StartBattle(orderus, beast1);
            
            
        }
    }
}