using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStats : MonoBehaviour
{
    public float playerMaxHealth;
    public float playerDamage;
    public float bulletSpeed;
    public bool isVamp;
    public bool isVampfromHit;
    public float vampHealAmmount;
    public bool isCrit;
    private float startCritCoeff;
    public float currentCoeff;
    

    private void Start() 
    {
        playerMaxHealth = 100f;
        playerDamage = 15f;
        bulletSpeed = 5f;
        isVamp = false;
        isCrit = false;
        vampHealAmmount = 0;
        startCritCoeff = 0f;
        currentCoeff = startCritCoeff;
        isVampfromHit = false;
    }
    
}
