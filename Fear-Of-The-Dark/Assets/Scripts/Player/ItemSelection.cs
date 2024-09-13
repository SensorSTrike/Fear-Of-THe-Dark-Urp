using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{

    public GameObject Axe;
    public GameObject Gun;
    public GameObject Hammer;
    [SerializeField] Transform playerHands;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Instantiate(Gun, playerHands);
        }
        if (Input.GetKeyDown("2"))
        {
            Instantiate(Hammer, playerHands);
        }
        if(Input.GetKeyDown("3"))
        {
            Instantiate(Axe, playerHands);
        }
    }
}
