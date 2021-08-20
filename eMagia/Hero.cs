using System;

namespace eMagia
{
    public class Hero : EmagiaEntity
    {

        private const int MinHp = 70, MaxHp = 100, MinStr = 70, MaxStr = 80, MinDef = 45, MaxDef = 55, MinSpd = 40, 
            MaxSpd = 50, MinLck = 10, MaxLck = 30;
        
        public Hero() : base(GetRand(MinHp, MaxHp), 
            GetRand(MinStr, MaxStr), GetRand(MinDef, MaxDef),
            GetRand(MinSpd, MaxSpd), GetRand(MinLck, MaxLck))
        {
        }

        private static int GetRand(int lowerBound, int upperBound)
        {
            var rnd = new Random();
            return rnd.Next(lowerBound, upperBound);
        }

    }
}