using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int attackDamage = 70;
    
    // Update is called once per frame
    void Update()
    {

            if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }


  

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        
    }
}
