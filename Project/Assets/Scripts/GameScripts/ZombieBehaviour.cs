using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float maxZombieSize;

    public Transform zombieBody;
    public HealthBar healthBar;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();

        animator.speed = maxZombieSize - zombieBody.transform.localScale.y;
    }

    void Update()
    {
        animator.SetBool("isDead", currentHealth < 1); 
    }

    private void DestroyZombie()
    {
        //ZombieManager.instance.zombiePositions.Remove(transform);
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
}
