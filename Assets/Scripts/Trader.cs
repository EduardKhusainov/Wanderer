using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
   public GameObject portal;
   public GameObject canvas;
   public Animator animator;
   public RuntimeAnimatorController animIdle;
   public RuntimeAnimatorController animTrade;

   private void Start() 
   {
        animator.runtimeAnimatorController = animIdle;
   }
   private void OnTriggerEnter(Collider other) 
   {
        portal.SetActive(true);
        animator.runtimeAnimatorController = animTrade;
        StartCoroutine(HidSelf());
        canvas.SetActive(true);
        Time.timeScale = 0f;
   }

   IEnumerator HidSelf()
   {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        
   }
}
