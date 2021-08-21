using System;
using eMagia.abilities;

namespace eMagia
{
    public abstract class EmagiaEntity
    {
        private int Health { get; set; }

        public int Strength { get; }

        private int Defence { get; }

        public int Speed { get; }

        public int Luck { get; }

        protected EmagiaEntity(int health, int strength, int defence, int speed, int luck)
        {
            this.Health = health;
            this.Strength = strength;
            this.Defence = defence;
            this.Speed = speed;
            this.Luck = luck;

        }
        
        public override string ToString()
        {
            return $"Our { this.GetType().Name }'s stats are:\nHp: { this.Health } Strength: { this.Strength } " +
                   $"Def: { this.Defence } Speed: { this.Speed } Luck: { this.Luck }";
        }

        public void DisplayHealth()
        {
            Console.WriteLine($"Our { this.GetType().Name }'s health is at: { this.Health }");
        }

        public bool IsAlive()
        {
            return this.Health > 0;
        }

        public void TakeDamage(int enemyStrength)
        {
            this.Health -= this.GetTotalDamage(enemyStrength);
        }

        private int GetTotalDamage(int enemyStrength)
        {
            int crtDmg;

            if (ComputeChance(this.Luck))
            {
                Console.WriteLine($"The { this.GetType().Name } got lucky so it takes no damage.");
                return 0;
            }
            
            switch (this.GetType().Name)
            {
                case "Hero":
                    if (ComputeChance(MagicShield.OccuringChance))
                    {
                        crtDmg = MagicShield.GetFinalDamage(enemyStrength, this.Defence);
                        crtDmg = crtDmg > this.Health ? this.Health : crtDmg;
                        Console.WriteLine("Our hero used the magic shield! The beast inflicted " + crtDmg + " damage.");
                        return crtDmg;
                    }

                    break;
                case "Beast":
                    if (ComputeChance(RapidStrike.OccuringChance))
                    {
                        crtDmg = RapidStrike.GetFinalDamage(enemyStrength, this.Defence);
                        crtDmg = crtDmg > this.Health ? this.Health : crtDmg;
                        Console.WriteLine("Our hero used the rapid strike! He inflicted " + crtDmg + " damage.");
                        return crtDmg;
                    }

                    break;
            }

            crtDmg = enemyStrength - this.Defence;
            crtDmg = crtDmg > this.Health ? this.Health : crtDmg;
            Console.WriteLine("The " + this.GetType().Name + " was attacked for a total of " + crtDmg + " damage.");
            return crtDmg;
        }

        private static bool ComputeChance(int percentage)
        {
            var rnd = new Random();
            var currentChance = rnd.Next(1, 100);
            
            return currentChance <= percentage;
        }


    }
}
