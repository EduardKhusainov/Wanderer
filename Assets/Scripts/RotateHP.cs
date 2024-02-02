using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotateHP : MonoBehaviour
{

    void Update()
    {
        TextMeshPro textMeshPro;
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.rectTransform.rotation = Quaternion.Euler(0 , 0, 0);
    }
}
