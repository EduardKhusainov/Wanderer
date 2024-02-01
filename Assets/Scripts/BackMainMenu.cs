using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class BackMainMenu : MonoBehaviour
{

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BackInMainMenu();
        }    
    }
    public void BackInMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("P");
    }
}
