using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject playerHand;

    bool canTake;

    GameObject item;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeItem()
    {
        if (canTake == true)
        {
            if (Input.GetKeyDown("f"))
            {
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Axe")
        {
            canTake = true;
            item = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canTake = false;
    }
}
