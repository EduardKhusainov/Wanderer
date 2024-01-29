using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Wanderer
{
    namespace NSUI.Overlay
    {
        public class LevelChangeOverlay : BaseOverlay
        {
            [SerializeField] private Image _playerIcon;
            [SerializeField] private Transform[] _levels;

            private int _levelIndex = 0;

            public async Task PlayAnimationAsync()
            {
                var animationTime = 1.5f;

                await Task.Delay(1000); 
                _playerIcon.transform.DOMove(_levels[_levelIndex + 1].position, animationTime).SetEase(Ease.Linear);
                _levelIndex++;

                await Task.Delay(1000);
            }
        }
    }
}