using System;

namespace eMagia
{
    public sealed class BattleMethods
    {
        private const int MaxRounds = 20;

        public static void StartBattle(EmagiaEntity hero, EmagiaEntity beast)
        {
            int countRounds = 0;
            var switchTurn = BattleMethods.CheckWhoStarts(hero, beast);
            while (hero.IsAlive() && beast.IsAlive() && countRounds < MaxRounds)
            {
                Console.WriteLine("");
                if (switchTurn)
                {
                    BattleMethods.Attack(hero, beast);
                }
                else
                {
                    BattleMethods.Attack(beast, hero);
                }
                hero.DisplayHealth();
                beast.DisplayHealth();

                switchTurn = !switchTurn;
                countRounds++;
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

        // Returns false if beast attacks first and true otherwise
        private static bool CheckWhoStarts(EmagiaEntity hero, EmagiaEntity beast)
        {
            return hero.Speed == beast.Speed ? hero.Luck > beast.Luck : hero.Speed > beast.Speed;
        }
        
    }
}