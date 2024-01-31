using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Wanderer;

public class BuffSystem : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] Button[] buttons;
    public Dictionary<int, int> keyValuePairs;
    [SerializeField] GameObject canvas;
    int spriteIndex;
    public bool isOn;
    public PlayerStats playerStats;
    Magnet magnet;
    ResetBuffBool resetBuffBool;
    private void Start() 
    {
        RundomizeBuff();   
        playerStats = FindObjectOfType<PlayerStats>();
        magnet = FindObjectOfType<Magnet>();
        resetBuffBool = FindObjectOfType<ResetBuffBool>();
        canvas = FindObjectOfType<BuffScreenCanvas>().gameObject;
    }

    private void Update() 
    {
        if(canvas == null)
        {
            //canvas = GameObject.Find("Buff_Screen_Canvas");
        }
        if(magnet.isArenaCleaned && !isOn && !resetBuffBool.isTrader)
        {
            isOn = true;
            canvas.SetActive(true);
            RundomizeBuff();
        }
        if(canvas.activeSelf && isOn)
        {
            Time.timeScale = 0f;
        }
         
    }
    public void RundomizeBuff()
    {
        Dictionary<int, int> keyValue = new Dictionary<int, int>();
        keyValuePairs = new Dictionary<int, int>();
        for(int i = 0; i < buttons.Length; i++)
        {
            int maxValue = sprites.Count;
            spriteIndex = Random.Range(0, maxValue);
            while(keyValue.ContainsKey(spriteIndex))
            {
                spriteIndex = Random.Range(0, maxValue);
            }
            keyValue.Add(spriteIndex, i);
            foreach(int key in keyValuePairs.Keys)
            {
                Debug.Log(key);
            }
            foreach(int key in keyValue.Keys)
            {
                Debug.Log("key" + " " + key);
            }
            Debug.Log(spriteIndex);
            buttons[i].image.sprite = sprites[spriteIndex];
        }
        keyValuePairs = keyValue;
    }
}
