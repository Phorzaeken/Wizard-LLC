using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float openAngle = 90f;
    public float openSpeed = 0.05f;
    public float interactionDistance = 3f;
    public Text interactionText;
    private bool isOpen = false;
    private Transform player;
    public AudioSource DoorOpeningSound;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false); // Hide text initially
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= interactionDistance && !isOpen)
        {
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Press E to open";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(OpenDoors());
                DoorOpeningSound.Play();
                if (interactionText != null)
                {
                    interactionText.gameObject.SetActive(false); // Hide text after opening
                }
            }
        }
        else
        {
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator OpenDoors()
    {
        isOpen = true;
        Quaternion leftDoorTargetRotation = leftDoor.rotation * Quaternion.Euler(0, openAngle, 0);
        Quaternion rightDoorTargetRotation = rightDoor.rotation * Quaternion.Euler(0, -openAngle, 0);

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * openSpeed;
            leftDoor.rotation = Quaternion.Slerp(leftDoor.rotation, leftDoorTargetRotation, t);
            rightDoor.rotation = Quaternion.Slerp(rightDoor.rotation, rightDoorTargetRotation, t);
            yield return null;
        }
    }
}
