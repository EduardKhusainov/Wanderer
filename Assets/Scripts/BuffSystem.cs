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
    public Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
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
    }

    private void Update() 
    {
        if(magnet.isArenaCleaned && !isOn && !resetBuffBool.isTrader)
        {
            isOn = true;
            canvas.SetActive(true);
        }
        if(canvas.activeSelf && isOn)
        {
            Time.timeScale = 0f;
        }
         
    }
    public void RundomizeBuff()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            int maxValue = sprites.Count;
            spriteIndex = Random.Range(0, maxValue);
            while(keyValuePairs.ContainsKey(spriteIndex))
            {
                spriteIndex = Random.Range(0, maxValue);
            }
            keyValuePairs.Add(spriteIndex, i);
            Debug.Log(spriteIndex);
            buttons[i].image.sprite = sprites[spriteIndex];
        }
    }

    public void Buff(int index)
    {
        switch(index)
        {
        case 5:
           
            break;
        case 4:
            print ("Hello and good day!");
            break;
        case 3:
            print ("Whadya want?");
            break;
        case 2:
            playerStats.playerDamage -= 20;
            break;
        case 1:
            playerStats.playerDamage += 20;
            break;
        case 0:
            Instantiate(buttons[0], buttons[0].transform.position, buttons[0].transform.rotation);
            break;
        default:
            print ("Incorrect intelligence level.");
            break;
        }

    }
    public void DamageBuff()
    {
        playerStats.playerDamage += 20;
    }
}
