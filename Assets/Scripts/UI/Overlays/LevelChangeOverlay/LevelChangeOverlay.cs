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
            [SerializeField] private Transform _backgroundTransform;
            [SerializeField] private Transform[] _levels;

            private int _levelIndex = 0;

            public async Task PlayAnimationAsync()
            {
                if (_levels[_levelIndex] == null)
                    return;

                var animationTime = 1f;
                var delayTimeMillis = 1200;

                await Task.Delay(delayTimeMillis);

                var distanceToMove = 394f;

                _backgroundTransform.DOMoveY(_backgroundTransform.position.y + distanceToMove, animationTime)
                    .SetEase(Ease.Linear);
                _levelIndex++;

                await Task.Delay(delayTimeMillis);
            }
        }
    }
}