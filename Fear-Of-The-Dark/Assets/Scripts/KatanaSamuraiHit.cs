using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSamuraiHit : MonoBehaviour
{
    
    private bool katanaHit;
    public Animator anim;
    

    
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            anim.SetTrigger("Hit");
        }

    }
}
