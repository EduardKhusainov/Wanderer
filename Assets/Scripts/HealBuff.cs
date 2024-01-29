using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

public class HealBuff : MonoBehaviour
{
    public void HealB()
    {
        ArenaBootstrapper.Instance.player.GetComponent<PlayerHealth>().Heal(100);
        Debug.Log("IHealed");
    }
}
