using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wanderer
{
    public class LoadScene : MonoBehaviour
    {
        public void LoadSceneMM(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1.0f;
        }

        public void LoadSceneMM(int id)
        {
            SceneManager.LoadScene(id);
            Time.timeScale = 1.0f;
        }
    }
}
