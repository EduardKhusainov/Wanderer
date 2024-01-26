using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Wanderer
{
    namespace NSScenes
    {
        public class SceneChanger : MonoBehaviour
        {
            [SerializeField] private int _sceneId;
            [SerializeField] private float _delay;

            private void Start()
            {
                StartCoroutine(DelayAndLoadScene());
            }

            private IEnumerator DelayAndLoadScene()
            {
                float elapsedTime = 0f;

                while (elapsedTime < _delay)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                GameManager.Instance.SetCursorState(CursorLockMode.None);
                SceneManager.LoadScene(_sceneId);
            }
        }
    }
}