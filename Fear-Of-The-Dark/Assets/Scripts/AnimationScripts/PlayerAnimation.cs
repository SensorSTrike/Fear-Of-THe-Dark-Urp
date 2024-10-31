using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator anim;
    private PlayerController playerController;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;
    private bool weaponInHand;
    
    
    void Start()
    {
        // Used to get access to PlayerController script
        playerController = GetComponent<PlayerController>();
        playerController = GetComponent<PlayerController> ();
        
    }

    void Update()
    {
        ProcessMovement();
        Animate();
    }

    // Get info from PlayerController script for isMoving boolean and where player is moving (x,y)
    void ProcessMovement()
    {
        if (playerController.isMoving)
        {
            moveDirection = (playerController.targetPosition - transform.position).normalized;
            // When moving lastMoveDirection changes by moveDirection
            lastMoveDirection = moveDirection;
            
        }
        else
        {
            moveDirection = lastMoveDirection;           
        }
         if (playerController.currentValue > 0)
        {
            weaponInHand = true;
        }

        
    }

    // SetFloat x and y if isMoving = true and animate accordingly in blendtree
    // If isMoving = false set idle animation by lastMoveDirection in another blendtree
    void Animate()
    {
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetBool("isMoving", playerController.isMoving);        
        anim.SetFloat("HorizontalIdle", lastMoveDirection.x);       
        anim.SetFloat("VerticalIdle", lastMoveDirection.y);
        anim.SetBool("weaponInHand", weaponInHand);
       
    }

    


    
}
