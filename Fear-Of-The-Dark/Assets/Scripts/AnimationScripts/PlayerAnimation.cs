using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator anim;
    private PlayerController playerController;
    private Vector3 moveDirection;
    
    
    void Start()
    {
        // Used to get access to PlayerController script
        playerController = GetComponent<PlayerController>();
        
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
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    // SetFloat x and y if isMoving = true and animate accordingly in blendtree
    public void Animate()
    {
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetBool("isMoving", playerController.isMoving);
    }

    
}
