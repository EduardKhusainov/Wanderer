using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    public class DamageBuff : IBuff
    {
        private int _damageBonus;

        public DamageBuff(int damageBonus)
        {
            _damageBonus = damageBonus;
        }

        public PlayerStats ApplyBuff(PlayerStats baseStats)
        {
            var newStats = baseStats;
            newStats.damage = Mathf.Max(newStats.damage + _damageBonus, 0);

            return newStats;
        }
    }
}