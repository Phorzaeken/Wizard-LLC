using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public Text interactionText;
    private bool hasPlunger = false;
    private bool plungerUsed = false;
    private GameObject currentPlunger;
    public GameObject plungerPrefab;
    public Transform toiletPosition;
    public AudioSource plungerSound;

    void Update()
    {
        if (!plungerUsed) // Only check for interactables if the plunger hasn't been used
        {
            CheckForInteractables();
        }
    }

    void CheckForInteractables()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Plunger") && !hasPlunger)
            {
                interactionText.text = "Press F to pick up plunger";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    PickUpPlunger(hit.collider.gameObject);
                }
            }
            else if (hit.collider.CompareTag("Toilet"))
            {
                if (hasPlunger)
                {
                    interactionText.text = "Press E to use plunger";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        UsePlunger(hit.collider.gameObject);
                    }
                }
                else
                {
                    interactionText.text = "Must use plunger to unclog";
                }
            }
        }
        else
        {
            interactionText.text = "";
        }
    }

    void PickUpPlunger(GameObject plunger)
    {
        hasPlunger = true;
        currentPlunger = plunger;
        plunger.SetActive(false);
        interactionText.text = "";
    }

    void UsePlunger(GameObject toilet)
    {
        GameObject spawnedPlunger = Instantiate(plungerPrefab, toiletPosition.position, toiletPosition.rotation);
        plungerSound.Play();
        hasPlunger = false;
        interactionText.text = "";
        Destroy(currentPlunger);
        StartCoroutine(BounceAndRemovePlunger(spawnedPlunger, 3f)); // 3 seconds delay
    }

    IEnumerator BounceAndRemovePlunger(GameObject plunger, float delay)
    {
        float elapsed = 0f;
        Vector3 originalPosition = plunger.transform.position;

        while (elapsed < delay)
        {
            plunger.transform.position = originalPosition + new Vector3(0, Mathf.Sin(elapsed * 10) * 0.1f, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(plunger);
        interactionText.text = ""; // Clear the text after delay
        interactionText.gameObject.SetActive(false); // Disable the text object
        plungerUsed = true; // Set the flag to indicate the plunger has been used
    }
}
