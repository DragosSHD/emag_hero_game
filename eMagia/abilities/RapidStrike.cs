namespace eMagia.abilities
{
    public class RapidStrike
    {
        public static int OccuringChance { get; } = 10;


        public static int GetFinalDamage(int enemyStrength, int receiverDefense)
        {
            var totalDamage = (enemyStrength - receiverDefense) * 2;
            return totalDamage;
        }
    }
}