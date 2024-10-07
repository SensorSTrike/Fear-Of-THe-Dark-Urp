using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public float rotationOffset = 90f; // Adjust this if needed based on your object's initial rotation

    void Update()
    {
        // Create a plane at the object's position facing the camera
        Plane plane = new Plane(Vector3.forward, transform.position);
        
        // Get the ray from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Find the distance at which the ray intersects the plane
        if (plane.Raycast(ray, out float distance))
        {
            // Get the intersection point in world coordinates
            Vector3 mousePosition = ray.GetPoint(distance);

            // Calculate the direction from the object to the mouse
            Vector3 direction = mousePosition - transform.position;

            // Calculate the angle in degrees and apply the rotation offset
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            // Rotate the object using the local rotation to ensure proper behavior in the hierarchy
            transform.localRotation = Quaternion.Euler(0, 0, angle + rotationOffset);
        }
    }
}