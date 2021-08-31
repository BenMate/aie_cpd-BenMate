using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   // public GameObject deathEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");        
        }
    }
}
