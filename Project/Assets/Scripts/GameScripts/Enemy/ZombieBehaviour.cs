using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class ZombieBehaviour : MonoBehaviour
{
    public float lookRadius = 10.0f;
    public int maxHealth = 100;
    public int currentHealth;
    public float maxZombieSize;

    public Transform zombieBody;
    public HealthBar healthBar;

    Animator animator;
    Transform target;
    NavMeshAgent agent;
   
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        animator = GetComponent<Animator>();
        animator.speed = maxZombieSize - zombieBody.transform.localScale.y;

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        animator.SetBool("isDead", currentHealth < 1);

        WalkControls();
    }




    private void DestroyZombie()
    {      
        //freeze movement  either before event or here

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            //FindObjectOfType<AudioManager>().Play("ZombieGrowl");

            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

    void WalkControls()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            animator.SetBool("isWalking", distance <= lookRadius && currentHealth > 1);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
