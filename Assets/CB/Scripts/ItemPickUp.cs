using UnityEngine;
using TMPro; // Ensure you include this for TextMeshPro
using UnityEngine.UI;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType { Lattekasam, Viagraccino, OiliveGarden, Oilohomora }
    public ItemType itemType;
    public float effectDuration = 2f; // Duration of the effect
    public float lightIntensityChange = 1f;
    public float speedBoostAmount = 1.5f; // Speed boost amount

    private PlayerController playerController;
    private LightController lightController;
    private bool playerInRange = false;
    private bool itemPickedUp = false;
    private TextMeshProUGUI pickupMessage; // TextMeshPro reference
    private Transform playerTransform;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        lightController = FindObjectOfType<LightController>();
        playerTransform = playerController.transform;

        // Find the PickupMessage object in the Canvas
        pickupMessage = GameObject.Find("PickupMessage")?.GetComponent<TextMeshProUGUI>();

        // Check if the pickup message was found
        if (pickupMessage != null)
        {
            pickupMessage.gameObject.SetActive(false); // Start with the message hidden
        }
       
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= 3f && !itemPickedUp)
        {
            ShowMessage("Press F to consume");
            playerInRange = true;
        }
        else
        {
            HideMessage();
            playerInRange = false;
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !itemPickedUp)
        {
            itemPickedUp = true;
            HideMessage();
            ApplyEffect();
            Destroy(gameObject); // Remove the item from the scene immediately
        }
    }

    void ApplyEffect()
    {
        switch (itemType)
        {
            case ItemType.Lattekasam:
                playerController.ApplySpeedBoost(effectDuration, speedBoostAmount);
                break;
            case ItemType.Viagraccino:
                playerController.ApplySpeedBoost(effectDuration, speedBoostAmount);
                break;
            case ItemType.OiliveGarden:
                lightController.IncreaseLightIntensity(effectDuration, lightIntensityChange);
                break;
            case ItemType.Oilohomora:
                lightController.IncreaseLightIntensity(effectDuration, lightIntensityChange);
                break;
        }
    }

    void ShowMessage(string message)
    {
        if (pickupMessage != null)
        {
            pickupMessage.text = message;
            pickupMessage.gameObject.SetActive(true); // Show the message
        }
    }

    void HideMessage()
    {
        if (pickupMessage != null)
        {
            pickupMessage.gameObject.SetActive(false); // Hide the message
        }
    }
}
