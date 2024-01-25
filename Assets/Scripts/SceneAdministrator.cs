using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wanderer
{
    public class SceneAdministrator : MonoBehaviour
    {
        public static SceneAdministrator Instance
        { get; private set; }
        [SerializeField] bool isMainMenu;
        [SerializeField] GameObject pauseMenu;
        public GameObject player;
        public GameObject mainCamera;
        bool isPaused = false;
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
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false && !isMainMenu)
            {
                Pause();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true && !isMainMenu)
            {
                Unpause();
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

        public void Pause()
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }

        public void Unpause()
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
        }

        public static void Exit()
        {
            Application.Quit();
        }
    }
}
