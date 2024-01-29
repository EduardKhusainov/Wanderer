using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

namespace Wanderer
{
    public class CharacterStatsController : MonoBehaviour
    {
        public CharacterBuffCore _characterBuffCore;
        [SerializeField] private int _baseHP;
        [SerializeField] private int _baseDamage;

        private void Start()
        {
            var baseStats = new PlayerStats
            {
                health = _baseHP,
                damage = _baseDamage,
                isImmortal = false,
            };
            Init(new CharacterBuffCore(baseStats));

            Debug.Log($"Character initialized. Health : {_characterBuffCore.currentStats.health}, Damage : {_characterBuffCore.currentStats.damage}, Is immortal : {_characterBuffCore.currentStats.isImmortal}");
        }
        private void Update()
        {
            Debug.Log($"Damage : {_characterBuffCore.currentStats.damage}");
        }

        public void Init(CharacterBuffCore characterBuffCore)
        {
            _characterBuffCore = characterBuffCore;
        }
    }
}