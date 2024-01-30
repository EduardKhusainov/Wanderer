using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

public class DoBuff : MonoBehaviour
{
    [SerializeField] BuffSystem buffSystem;
    [SerializeField] float damage;
    [SerializeField] float heal;
    [SerializeField] float plusToMaxHp;
    [SerializeField] GameObject canvas;
    public int index;
    public int value;
    public PlayerStats playerStats; 
    public PlayerHealth playerHealth;

    private void Start() 
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void Index()
    {
       foreach (var pair in buffSystem.keyValuePairs) 
        {
            if (pair.Value == index) 
            {
                value = pair.Key;
                break;
            }
        }

        Buff(value);
        Debug.Log(value);
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
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
            DamageBuff();
            break;
        case 1:
            playerStats.playerMaxHealth += plusToMaxHp;
            playerHealth.ResetHPBar();
            break;
        case 0:
            playerHealth.Heal(heal); 
            break;
        default:
            print ("Incorrect buff");
            break;
        }

    }

    public void DamageBuff()
    {
        playerStats.playerDamage += damage;
    }


    public void MaxiMizeHealth(float plusToMaxHp)
    {
        playerStats.playerMaxHealth += plusToMaxHp;
    }


}


