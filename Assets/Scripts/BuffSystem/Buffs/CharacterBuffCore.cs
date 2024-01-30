using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
    public class CharacterBuffCore : MonoBehaviour, IBuffable
    {
        public PlayerStats baseStats {  get; }
        public PlayerStats currentStats;

        private readonly List<IBuff> _buffs = new();

        public CharacterBuffCore(PlayerStats BaseStats)
        {
            baseStats = BaseStats;
            currentStats = BaseStats;
        }

        public void AddBuff(IBuff buff)
        {
            _buffs.Add(buff);
            ApplyBuffs();

            Debug.Log($"Buff added : {buff}");
        }

        private void ApplyBuffs()
        {
            currentStats = baseStats;
            foreach (IBuff buff in _buffs)
            {
                currentStats = buff.ApplyBuff(currentStats);
            }
        }
    }
}