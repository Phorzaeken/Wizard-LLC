using UnityEngine;

public class RaycastDebugger : MonoBehaviour
{
    // Distance for the raycast
    public float raycastDistance = 5f;

    void Update()
    {
        // Perform the raycast forward from the player's position and orientation
        RaycastHit hit;
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forwardDirection, out hit, raycastDistance))
        {
            // Log the name of the object the ray hits
            Debug.Log("Collided with: " + hit.collider.gameObject.name);
        }

        // Draw the ray in the Scene view for debugging purposes
        Debug.DrawRay(transform.position, forwardDirection * raycastDistance, Color.red);
    }
}