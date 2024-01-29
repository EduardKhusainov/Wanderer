using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
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
    [SerializeField] Material hpBarMaterial;
    [SerializeField] GameObject go;
    bool isClaped;
    public float fresnel;
    public float attackSpeed;
    [SerializeField] ParticleSystem arsPart;
   private void Start() 
   {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animWalk;
        enemyHealth = GetComponent<EnemyHealth>();
        if(go != null)
        {
            hpBarMaterial = go.GetComponent<Renderer>().material;
            fresnel = 0f;
            hpBarMaterial.SetFloat("_Subtract_Float", fresnel);
        }
   }

   private void Update() 
   {
        if(enemyHealth._enemyCurrentHealth <=0)
        {
            StopAllCoroutines();
            animator.runtimeAnimatorController = animDeath;
            enemyHealth.GetComponent<NavMeshAgent>().speed = 0;
        } 
        if(fresnel > 0.1f && go != null)
        {
            hpBarMaterial.SetFloat("_Subtract_Float", fresnel);
            fresnel -= 0.5f * Time.deltaTime;
        }
   }

   private void OnTriggerEnter(Collider other) 
   {
        if (other.gameObject.CompareTag("Player"))
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
        yield return new WaitForSeconds(attackSpeed);
        animator.runtimeAnimatorController = animIdle;
        animator.runtimeAnimatorController = animAttack;
        other.gameObject.GetComponent<IDamagable>().TakeDamage(10);
        isClaped = true;
        fresnel = 2f;
        if(arsPart != null)
        {
            arsPart.Play();
        }
        if (other == null)
        {
            StopAllCoroutines();
            yield break;
        }

        transform.LookAt(other.transform.position, Vector3.up);
        StartCoroutine(Attack(other));
    }
}
