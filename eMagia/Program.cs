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
            Console.WriteLine("Hello eMagia!");
            var orderus = new Hero();
            var beast1 = new Beast();
            Console.WriteLine(orderus);
            Console.WriteLine(beast1);
            
            Attack(orderus, beast1);
            
            orderus.DisplayHealth();
            beast1.DisplayHealth();
            
        }
    }
}