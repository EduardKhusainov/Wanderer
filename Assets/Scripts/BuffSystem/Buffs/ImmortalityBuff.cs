namespace Wanderer
{
    public class ImmortalityBuff : IBuff
    {
        public PlayerStats ApplyBuff(PlayerStats baseStats)
        {
            var newStats = baseStats;

            newStats.isImmortal = true;

            return newStats;
        }
    }
}