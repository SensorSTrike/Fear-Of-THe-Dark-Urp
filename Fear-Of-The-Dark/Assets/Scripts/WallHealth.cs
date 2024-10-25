using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float health;

    public float maxHealth;

    public float damage;

    public float fixing;

    public bool onRange;

    public float hitSpeed;

    
   
    void Start()
    {
     health = maxHealth;
    }

    void destroyWall()
    {
       

        if (health > 0)
        {
            health = health - damage;
            
            
        }
    }

    //void fixWall()
    //{
    //    if (health < maxHealth)
    //    {
    //        health = health + fixing;
    //    } 
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            StartCoroutine(HitSpeedCoroutine());
        }
    }

    

    IEnumerator HitSpeedCoroutine()
    {
        
        yield return new WaitForSeconds(hitSpeed);
        onRange = true;
    }

    void Update()
    {
        
        if (onRange == true && health > 0)
        {
            destroyWall();

            onRange = false;
            StartCoroutine(HitSpeedCoroutine());
        }

       if (onRange == true && health <= 0)
       {
            gameObject.tag = "DestroyedWall";
       }
    }
}
