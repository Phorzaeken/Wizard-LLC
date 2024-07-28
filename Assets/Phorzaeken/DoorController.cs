using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationAngle = 90f; // Angle to rotate
    public float rotationSpeed = 2f;  // Speed of rotation
    private bool isOpen = false;      // Door state
    public int Items;
    public int quantitylock;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Change this to your desired input
        {
            if (Items == quantitylock)
            isOpen = !isOpen;
        }

        float targetAngle = isOpen ? rotationAngle : 0f;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
