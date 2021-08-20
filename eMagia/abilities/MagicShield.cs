namespace eMagia.abilities
{
    public class MagicShield
    {
        public static int OccuringChance { get; } = 20;
        
        public static int GetFinalDamage(int enemyStrength, int receiverDefense)
        {
            var totalDamage = (enemyStrength - receiverDefense) / 2;
            return totalDamage;
        }
    }
}