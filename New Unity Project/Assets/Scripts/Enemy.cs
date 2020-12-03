using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float speed;
    private Transform player;
    public static int enemiesLeft;
    public GameObject deathEffect;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    [SerializeField] Animator anim;
    public bool isShooting;
    public float lineOfSight;
    public float fireRate =1f;
    private float nextFireTime;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemiesLeft = 3;
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (isShooting == true)
        {
            Shoot();
        }
        else if (isShooting == false)
        {
            Move();
        }
        
        
    }






    void Move()
    {
        float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if(distanceFromPlayer < lineOfSight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed*Time.deltaTime);
        }
    }

    void Shoot()
    {
        float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if(distanceFromPlayer < lineOfSight && distanceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed*Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime <Time.time)
            {
                CheckIfTimeToFire();
            }
    }

    void CheckIfTimeToFire()
    {
        Instantiate (bullet, bulletParent.transform.position, Quaternion.identity);
        anim.SetTrigger("Fire");
        nextFireTime = Time.time + fireRate;
        
           
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        enemiesLeft --;  
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
