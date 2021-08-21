using System;

namespace eMagia
{
    class Program
    {
        private static void Attack(EmagiaEntity attacker, EmagiaEntity defender)
        {
            defender.TakeDamage(attacker.Strength);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to eMagia!");
            var orderus = new Hero();
            var beast1 = new Beast();
            Console.WriteLine(orderus);
            Console.WriteLine(beast1);

            while (orderus.IsAlive() && beast1.IsAlive())
            {
                Console.WriteLine("");
                Attack(beast1, orderus);
                orderus.DisplayHealth();
                beast1.DisplayHealth();
            }
            
            
        }
    }
}