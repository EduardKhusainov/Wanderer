using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject meduzaPref;
    [SerializeField] GameObject[] positions;
    
    private void Start() 
    {
        InvokeRepeating("MinionSpawn", 10f, 17f);
    }

    public void MinionSpawn()
    {
        foreach(GameObject pos in positions)
        {
            Instantiate(meduzaPref, pos.transform.position, meduzaPref.transform.rotation);
        }
    }
}
