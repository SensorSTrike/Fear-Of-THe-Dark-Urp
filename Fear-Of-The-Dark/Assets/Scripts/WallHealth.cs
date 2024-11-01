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

    public Transform instPos;

    public GameObject WallParticleHP4;
    public GameObject WallParticleHP2;
    public GameObject WallParticleHP0;

    
   
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

    void wallParticles()
    {
        if (health == 4)
        {
            Instantiate(WallParticleHP4, instPos);
            Debug.Log(instPos);
        }

        if (health == 2) 
        {
            Instantiate(WallParticleHP2, instPos);
        }
        if (health == 0)
        {
            Instantiate(WallParticleHP0, instPos);
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

            wallParticles();

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
