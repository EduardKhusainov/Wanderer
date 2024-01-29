using UnityEngine;

namespace Wanderer
{
    public class DamagePill : MonoBehaviour
    {
        [SerializeField] private int _damageBonus;

        private DamageBuff buff = new DamageBuff(10);

        public void PlusDamage()
        {
            ArenaBootstrapper.Instance.player.GetComponent<CharacterStatsController>()._characterBuffCore.currentStats.damage += 10;
        }
    }
}