using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitsWall : MonoBehaviour
{
    // Wall position
    [SerializeField] private Transform wallPosition;
    // When is enemy close enough to hit wall
    [SerializeField] private float enemyCloseWall;
    // How fast enemy hits wall
    [SerializeField] private float enemyHitsWallTime;
    private Vector2 wallPosition2D;

    private bool WallTakesHit;

    private void Start()
    {
        wallPosition2D = wallPosition.position;
        InvokeRepeating("EnemyHitsWall", 0.5f, 0.1f);
    }


}
