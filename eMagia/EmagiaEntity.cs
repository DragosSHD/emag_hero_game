using System;
using eMagia.abilities;

namespace eMagia
{
    public abstract class EmagiaEntity
    {
        private int Health { get; set; }

        public int Strength { get; }

        private int Defence { get; }

        private int Speed { get; }

        private int Luck { get; }

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
            return "Our "+ this.GetType().Name +"'s stats are:\n" + "Hp: " + Health + " Strength: " + Strength + " Def: " + Defence 
                   + " Speed: " + Speed + " Luck: " + Luck;
        }

        public void DisplayHealth()
        {
            Console.WriteLine("Our " + this.GetType().Name + "'s health is at: " + this.Health);
        }

        public bool IsAlive()
        {
            return this.Health > 0;
        }

        public void TakeDamage(int enemyStrength)
        {
            var crtDmg = this.GetTotalDamage(enemyStrength);
            this.Health = this.Health < crtDmg ? 0 : this.Health - crtDmg;
        }

        private int GetTotalDamage(int enemyStrength)
        {
            int crtDmg;
            switch (this.GetType().Name)
            {
                case "Hero":
                    if (ComputeChance(MagicShield.OccuringChance))
                    {
                        crtDmg = MagicShield.GetFinalDamage(enemyStrength, this.Defence);
                        Console.WriteLine("Our hero used the magic shield! The beast inflicted " + crtDmg + " damage.");
                        return crtDmg;
                    }

                    break;
                case "Beast":
                    if (ComputeChance(RapidStrike.OccuringChance))
                    {
                        crtDmg = RapidStrike.GetFinalDamage(enemyStrength, this.Defence);
                        Console.WriteLine("Our hero used the rapid strike! He inflicted " + crtDmg + " damage.");
                        return crtDmg;
                    }

                    break;
            }

            crtDmg = enemyStrength - this.Defence;
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
