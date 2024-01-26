using DG.Tweening;
using System;
using UnityEngine;

namespace Wanderer
{
    namespace NSUI.Overlay
    {
        public class BaseOverlay : MonoBehaviour
        {
            [SerializeField] protected Canvas _canvas;
            [SerializeField] protected CanvasGroup _canvasGroup;

            private void Reset()
            {
                _canvas = GetComponent<Canvas>();
                _canvas.sortingOrder++;
                _canvasGroup = GetComponent<CanvasGroup>();
            }

            public void Show(bool isVisible, float animationTime = 0f)
            {
                _canvasGroup.alpha = Convert.ToInt32(!isVisible);

                if (animationTime > 0)
                {
                    _canvasGroup.DOFade(Convert.ToInt32(isVisible), animationTime).SetUpdate(UpdateType.Normal, true);
                }
                else
                {
                    _canvasGroup.alpha = Convert.ToInt32(isVisible);
                }

                _canvasGroup.blocksRaycasts = isVisible;
            }
        }
    }
}