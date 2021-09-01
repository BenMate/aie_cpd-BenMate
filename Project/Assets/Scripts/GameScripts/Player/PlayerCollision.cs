using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int maxHealth = 28;
    public int currentHealth;

    public HealthBar healthBar;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        animator.SetBool("isDead", currentHealth < 1);
        
    }


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Zombie")
        {        
            TakeDamage(4);   //change from being hardcoded as 4
        }

        
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }

}
