using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public float maxHealth;

    public float damage;

    public bool hitByKatana;

    



    void Start()
    {
        health = maxHealth;
    }

    void TakeHit()
    {


        if (health > 0)
        {
            health = health - damage;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Katana"))
        {
            hitByKatana = true;
            
        }
    }



    

    void Update()
    {

        if (hitByKatana == true && health > 0)
        {
            TakeHit();

            hitByKatana = false;
            ;
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.layer = 0;
        }
    }
}
