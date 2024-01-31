using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

public class DoBuff : MonoBehaviour
{
    [SerializeField] BuffSystem buffSystem;
    [SerializeField] float damage;
    [SerializeField] float heal;
    [SerializeField] float vampireHeal;
    [SerializeField] float plusToMaxHp;
    [SerializeField] float plusBulletSpeed;
    [SerializeField] GameObject canvas;
    public int index;
    public int value;
    public PlayerStats playerStats; 
    public PlayerHealth playerHealth;
    public MagicWand magicWand;

    private void Start() 
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerStats = FindObjectOfType<PlayerStats>();
        magicWand = FindObjectOfType<MagicWand>();
    }

    public void Update()
    {
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
            Vampirize(vampireHeal);
            break;
        case 4:
            RiseBulletSpeed();
            break;
        case 3:
            CriticalHit();
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
            playerHealth.ResetHPBar();
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

    public void RiseBulletSpeed()
    {
        playerStats.bulletSpeed += plusBulletSpeed;
        magicWand._reloadTime -= 0.1f; 
    }

    public void HealPlayer(float heal)
    {
        playerHealth.Heal(heal); 
    }

    public void Vampirize(float vampireHeal)
    {
        playerStats.isVamp = true;
        playerStats.vampHealAmmount += vampireHeal;
    }

    public void CriticalHit()
    {
       playerStats.isCrit = true;
       playerStats.currentCoeff += 0.2f;
    }
}


