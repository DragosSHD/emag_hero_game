using System;

namespace eMagia
{
    public sealed class BattleMethods
    {
        private const int MaxRounds = 20;

        public static void StartBattle(EmagiaEntity hero, EmagiaEntity beast)
        {
            int countRounds = 0;
            var whoStarts = BattleMethods.CheckWhoStarts(hero, beast);
            EmagiaEntity firstFighter, secondFighter;
            
            if (whoStarts)
            {
                firstFighter = hero;
                secondFighter = beast;
            }
            else
            {
                firstFighter = beast;
                secondFighter = hero;
            }
            while (hero.IsAlive() && beast.IsAlive() && countRounds++ < MaxRounds)
            {
                Console.WriteLine("");

                Attack(firstFighter, secondFighter);
                if (!secondFighter.IsAlive())
                {
                    break;
                }
                Attack(secondFighter, firstFighter);
                
                hero.DisplayHealth();
                beast.DisplayHealth();

            }

            if (!hero.IsAlive())
            {
                Console.WriteLine($"The Beast won the battle in { countRounds } rounds.");
            } 
            else if (!beast.IsAlive())
            {
                Console.WriteLine($"The Hero won the battle in { countRounds } rounds.");
            }
            else
            {
                Console.WriteLine($"The battle exceeded the maximum amount of rounds which is { MaxRounds }");
            }
        }
        private static void Attack(EmagiaEntity attacker, EmagiaEntity defender)
        {
            defender.TakeDamage(attacker.Strength);
        }

        // Returns true if the first input gets to start and false otherwise.
        private static bool CheckWhoStarts(EmagiaEntity hero, EmagiaEntity beast)
        {
            return hero.Speed == beast.Speed ? hero.Luck > beast.Luck : hero.Speed > beast.Speed;
        }
        
    }
}