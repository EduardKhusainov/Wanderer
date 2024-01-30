using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBuffBool : MonoBehaviour
{
    BuffSystem buffSystem;
    public bool isTrader;
    void Start()
    {
        if(!isTrader)
        {
            buffSystem = FindAnyObjectByType<BuffSystem>();
            buffSystem.isOn = false;
        }
    }

   
}
