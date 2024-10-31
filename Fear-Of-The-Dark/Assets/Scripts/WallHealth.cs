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

    public SpriteRenderer sR;

    public Sprite[] sprites;

    public int currentSprite;

    
   
    void Start()
    {
     health = maxHealth;
    }

    void destroyWall()
    {
       

        if (health > 0)
        {
            health = health - damage;
            
            sR.sprite = sprites[currentSprite];
            currentSprite++;
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
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.layer = 0;
       }
    }
}
