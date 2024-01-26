using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

public class Flask : MonoBehaviour
{
    [SerializeField] float _healAmount;
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == ArenaBootstrapper.Instance.player)
        {
            coll.GetComponent<IHeal>()?.Heal(_healAmount);
        }
    }
}
