using Sirenix.OdinInspector;
using UnityEngine;
using Wanderer.NSUtilities;

namespace Wanderer
{
    namespace NSUI.Screen
    {
        public class CanvasManager : PersistentSingleton<CanvasManager>
        {
            [field: SerializeField] public Canvas[] SetCanvases { get; private set; }

            [Button]
            private void FillCanvases()
            {
                SetCanvases = GetComponentsInChildren<Canvas>();
            }
        }
    }
}