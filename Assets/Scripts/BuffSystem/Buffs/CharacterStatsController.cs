using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

namespace Wanderer
{
    public class CharacterStatsController : MonoBehaviour
    {
        [SerializeField] private int _baseHP;
        public int _baseDamage;
         public CharacterBuffCore _characterBuffCore;

        private void Start()
        {
            var baseStats = new PlayerStats
            {
                health = _baseHP,
                damage = _baseDamage,
                isImmortal = false,
            };
            Init(new CharacterBuffCore(baseStats));
            _characterBuffCore = FindObjectOfType<CharacterBuffCore>();

            Debug.Log($"Character initialized. Health : {_characterBuffCore.currentStats.health}, Damage : {_characterBuffCore.currentStats.damage}, Is immortal : {_characterBuffCore.currentStats.isImmortal}");
        }

        public void Init(CharacterBuffCore characterBuffCore)
        {
            _characterBuffCore = characterBuffCore;
        }
    }
}