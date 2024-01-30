using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

public class BuffScreen : MonoBehaviour
{
    [SerializeField] Canvas buffScreen;
    public bool isBuffed;
<<<<<<< HEAD
    Magnet magnet;

    private void Start() 
    {
        magnet = FindObjectOfType<Magnet>();    
    }
=======
>>>>>>> eacd0ee52467736025cd3c23fb578e54af600a1e
    void Update()
    {
        if (ArenaBootstrapper.Instance.isArenaCleaned && !isBuffed)
        {
            BuffScreenOn();
        }       
    }

    public void BuffScreenOn()
    {
        buffScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isBuffed = true;
    }
    public void BuffScreenOff()
    {
        buffScreen.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
