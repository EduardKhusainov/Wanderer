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
            Vector3 startPos;
            public int _levelIndex;
            LoadNext loadNext;
            public bool isScroll;

            private void Start() 
            {
                startPos = _backgroundTransform.position;    
            }
            public async Task PlayAnimationAsync()
            {
                loadNext = FindObjectOfType<LoadNext>();
                _levelIndex = loadNext.currentIndex;
                if(_levelIndex == 0)
                {
                    _backgroundTransform.position = startPos;
                }
                if (_levels[_levelIndex] == null)
                    return;

                var animationTime = 1f;
                var delayTimeMillis = 1200;

                await Task.Delay(delayTimeMillis);

                var distanceToMove = 282f;

                _backgroundTransform.DOMoveY(_backgroundTransform.position.y + distanceToMove, animationTime)
                    .SetEase(Ease.Linear);

                await Task.Delay(delayTimeMillis);
            }
        }
    }
}