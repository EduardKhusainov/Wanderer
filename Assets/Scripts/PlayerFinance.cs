using TMPro;
using UnityEngine;

namespace Wanderer
{
    public class PlayerFinance : MonoBehaviour, ICoinable
    {
        public int Amount => _money;

        int _money = 0;
        [SerializeField] TextMeshProUGUI _textMeshPro;

        void Start() => _textMeshPro.text = _money.ToString();

        public void AddMoney(int value) =>
            _money += value;
    }
}