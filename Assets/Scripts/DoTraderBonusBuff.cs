using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

public class DoTraderBonusBuff : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerFinance playerFinance;
    public GameObject go;
    public int index;
    public float bulletBonusSpeed;
    public int buffPrice;
    private void Start() 
    {
        playerStats = FindObjectOfType<PlayerStats>();  
        playerFinance = FindObjectOfType<PlayerFinance>();  
    }

    public void DoBuff()
    {   
        if(index == 0)
        {
            if(playerFinance._money >= buffPrice)
            {
                playerStats.isVampfromHit = true;
                go.SetActive(false);
                Time.timeScale = 1f;
                playerFinance.AddMoney(-buffPrice);
            }
        }
        if(index == 1)
        {
            if(playerFinance._money >= buffPrice)
            {
                playerStats.bulletSpeed += bulletBonusSpeed;
                gameObject.SetActive(false);
                playerFinance.AddMoney(-buffPrice);
            }
        }
        else
        {
            if(playerFinance._money > buffPrice)
            {
                if(playerStats.currentCoeff > 0)
                {
                    playerStats.currentCoeff += playerStats.currentCoeff * 0.5f + playerStats.currentCoeff;
                    gameObject.SetActive(false);
                    playerFinance.AddMoney(-buffPrice);
                }
                else{
                    playerStats.currentCoeff += 0.5f;
                    gameObject.SetActive(false);
                    playerFinance.AddMoney(-buffPrice);
                }
            }
        }
    }

    public void CloseTab()
    {
        go.SetActive(false);
        Time.timeScale = 1f;
    }
}
