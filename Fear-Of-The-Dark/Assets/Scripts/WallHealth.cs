using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float health;

    public float maxHealth;

    public float destroy;

    public float fixing;

    private bool onRange;

    public float hitSpeed;
   
    void Start()
    {
     health = maxHealth;
    }

    void destroyWall()
    {
        if (health > 0)
        {
            health = health - destroy;
        }
    }

    void fixWall()
    {
        if (health < maxHealth)
        {
            health = health + fixing;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            onRange = true;
        }
    }

    IEnumerator HitSpeedCoroutine()
    {
        yield return new WaitForSeconds(hitSpeed); 
    }

    void Update()
    {
       if (onRange == true || health > 0)
       {
            StartCoroutine(HitSpeedCoroutine());
            destroyWall();
       }

       if (onRange == true || health <= 0)
       {
            gameObject.tag = "DestroyedWall";
       }
    }
}
