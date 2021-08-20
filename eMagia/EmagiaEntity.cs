using System;
using eMagia.abilities;

namespace eMagia
{
    public abstract class EmagiaEntity
    {
        private int Health { get; set; }

        public int Strength { get; }

        public int Defence { get; }

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
            return "Our "+ this.GetType().Name +"'s stats are:\n" + "Hp: " + Health + " Strength: " + Strength + " Def: " + Defence 
                   + " Speed: " + Speed + " Luck: " + Luck;
        }

        public void DisplayHealth()
        {
            Console.WriteLine("Our " + this.GetType().Name + "'s health is at: " + this.Health);
        }

        public void TakeDamage(int enemyStrength)
        {
            this.Health -= this.GetTotalDamage(enemyStrength);
        }

        private int GetTotalDamage(int enemyStrength)
        {
            switch (this.GetType().Name)
            {
                case "Hero":
                    if (ComputeChance(MagicShield.OccuringChance))
                    {
                        Console.WriteLine("Our hero used the magic shield!");
                        return MagicShield.GetFinalDamage(enemyStrength, this.Defence);
                    }

                    break;
                case "Beast":
                    if (ComputeChance(RapidStrike.OccuringChance))
                    {
                        return RapidStrike.GetFinalDamage(enemyStrength, this.Defence);
                    }

                    break;
            }

            return enemyStrength - this.Defence;
        }

        private static bool ComputeChance(int percentage)
        {
            var rnd = new Random();
            var currentChance = rnd.Next(1, 100);
            
            return currentChance <= percentage;
        }


    }
}
