using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

public class MaxHP : MonoBehaviour
{
    public void MaxHPBuff()
    {
        ArenaBootstrapper.Instance.player.GetComponent<PlayerHealth>().playerMaxHealth += 50;
    }
}
