using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth;
   public HealthBar healthBar;
   public GameObject deathEffect;

   void Start()
   {
       currentHealth = maxHealth;
       healthBar.SetMaxHealth(maxHealth);
   }


   void Update()
   {
       
   }

   public void  TakeDamage(int damage)
   {
       currentHealth -= damage;
       healthBar.SetHealth(currentHealth);

       if (currentHealth <= 0)
        {
            Die();
        }
   }
   void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        
    }
}
