using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player

    public Vector3 targetPosition;
    public bool isMoving = false;

    void Update()
    {
        // Start moving when the move button (e.g., left mouse button) is pressed
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        // Move the player towards the target position
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    // Method to set the target position when the move button is pressed
    void SetTargetPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        isMoving = true;
    }

    // Method to move the player towards the target position
    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Stop moving if the player reaches the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }
}
  