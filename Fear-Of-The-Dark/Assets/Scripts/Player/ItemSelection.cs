using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{

    public GameObject Axe;
    public GameObject Gun;
    public GameObject Hammer;
    public GameObject Katana;
    [SerializeField] Transform playerHands;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Instantiate(Hammer, playerHands);
        }
        if (Input.GetKeyDown("2"))
        {
            Instantiate(Axe, playerHands);
        }
        if(Input.GetKeyDown("3"))
        {
            Instantiate(Katana, playerHands);
        }
        if (Input.GetKeyDown("4"))
        {
            Instantiate(Gun, playerHands);
        }
    }
}
