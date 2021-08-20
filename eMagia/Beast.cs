using System;

namespace eMagia
{
    public class Beast : EmagiaEntity
    {

        private const int MinHp = 60, MaxHp = 90, MinStr = 60, MaxStr = 90, MinDef = 40, MaxDef = 60, MinSpd = 40, 
            MaxSpd = 60, MinLck = 25, MaxLck = 40;
        
        public Beast() : base(GetRand(MinHp, MaxHp), 
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