using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationAngle = 90f; // Angle to rotate
    public float rotationSpeed = 2f;  // Speed of rotation
    private bool isOpen = false;      // Door state
    public int Items;
    public int Items2;
    public int quantitylock;
    public bool Near = false;
    public bool Near2 = false;
    private bool opendoor = false;
    private bool opendoor2 = false;
    public bool LD;
    public bool RD;

    void Update()
    {
        
    }



    private void OnTriggerStay(Collider collision)
    {
        if (opendoor == false && LD == true)
        {
            if (collision.tag == "Player")
            {
                Near = true;
            }
        }
        if (opendoor2 == false && RD == true)
        {
            if (collision.tag == "Player")
            {
                Near2 = true;
            }
        }
        if (Input.GetKey(KeyCode.E) && Near == true) // Change this to your desired input
        {
            if (Items >= quantitylock)
            {
                isOpen = !isOpen;
                float targetAngle = isOpen ? rotationAngle : 0f;
                Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
                opendoor = true;
            }
        }

        if (Input.GetKey(KeyCode.E) && Near2 == true) // Change this to your desired input
        {
            if (Items2 >= quantitylock)
            {
                isOpen = !isOpen;
                float targetAngle = isOpen ? rotationAngle : 0f;
                Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
                opendoor2 = true;
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    { 
        if (collision.tag == "Player")
        {
            Near = false;
            Near2 = false;
        }
    }
}
