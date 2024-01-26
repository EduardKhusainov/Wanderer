using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Wanderer.NSUI.Overlay;
using Wanderer.NSUI.Screen;

namespace Wanderer
{
    public class ArenaBootstrapper : MonoBehaviour
    {
        public static ArenaBootstrapper Instance { get; private set; }
        public GameObject player;
        public GameObject mainCamera;
        public bool isArenaCleaned = false;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                var screen = CanvasManager.Instance.SetCanvases
                    .Select(canvas => canvas.GetComponent<PauseOverlay>())
                    .FirstOrDefault();

                if (screen.IsActive)
                    return;

                var fadeDelay = 0.6f;
                screen.Show(true, fadeDelay);
            }
        }

        public void LoadGameScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1.0f;
        }

        public void LoadGameScene(int id)
        {
            SceneManager.LoadScene(id);
            Time.timeScale = 1.0f;
        }
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1.0f;
            Debug.Log("This shit restarted!");
        }

        public static void Exit()
        {
            Application.Quit();
        }
    }
}