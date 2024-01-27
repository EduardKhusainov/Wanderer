using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Wanderer;

public class EnemyAnimator : MonoBehaviour
{
   public Animator animator;
   public AnimatorController animIdle;
   public AnimatorController animWalk;
   public AnimatorController animAttack;
   public AnimatorController animDeath;
   public EnemyHealth enemyHealth;
   private IEnumerator coroutine;

   private void Start() 
   {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animWalk;
        enemyHealth = GetComponent<EnemyHealth>();
   }

   private void Update() 
   {
        if(enemyHealth._enemyCurrentHealth <=0)
        {
            StopAllCoroutines();
            animator.runtimeAnimatorController = animDeath;
        } 
   }

   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject.CompareTag("Player"))
        {
            animator.runtimeAnimatorController = animAttack;
            StartCoroutine(Attack(other));
        }  
   }

   private void OnTriggerExit(Collider other) 
   {
        if(other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            animator.runtimeAnimatorController = animWalk;
        }  
   }

    IEnumerator Attack(Collider other)
    {
        yield return new WaitForSeconds(1.7f);
        animator.runtimeAnimatorController = animIdle;
        animator.runtimeAnimatorController = animAttack;
        transform.LookAt(other.transform.position, Vector3.up);
        StartCoroutine(Attack(other));
    }
}
