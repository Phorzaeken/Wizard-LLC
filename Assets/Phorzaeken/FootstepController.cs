using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip[] woodFootstepSounds; // Array to hold wooden footstep sound clips
    public AudioClip[] stoneFootstepSounds; // Array to hold stone footstep sound clips
    // public AudioClip[] footstepSounds; // Array to hold footstep sound clips
    public float minTimeBetweenFootsteps = 0.3f; // Minimum time between footstep sounds
    public float maxTimeBetweenFootsteps = 0.6f; // Maximum time between footstep sounds

    public AudioSource audioSource; // Reference to the Audio Source component
    private bool isWalking = false; // Flag to track if the player is walking
    private float timeSinceLastFootstep; // Time since the last footstep sound
    private Vector3 lastPosition; // To track player's position

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        lastPosition = transform.position; // Initialize last position
    }

    private void Update()
    {
        /* if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
         {
             StartWalking();        
         }*/

        if (IsPlayerMoving())
        {
            StartWalking();
        }
        else
        {
            StopWalking();
        }

        // Check if the player is walking
        if (isWalking)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {

                /* var val1 = 0;
                 var val2 = 5;
                 var stepping = Random.Range(val1, val2);
                 if (stepping == 0 || stepping == 4 || stepping == 2)
                 {
                     AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
                     audioSource.PlayOneShot(footstepSound);
                     timeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
                     StopWalking();
                 }
                 else if (stepping == 3 || stepping == 1 || stepping == 5)
                 {
                     // Play a random footstep sound from the array
                     AudioClip footstepSound = footstepSounds[Random.Range(9, footstepSounds.Length)];
                     audioSource.PlayOneShot(footstepSound);
                     timeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
                     StopWalking();*/

                PlayFootstep();
                timeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
            
            }
        }

        // Update last position
        lastPosition = transform.position;
    }

    // Call this method when the player starts walking
    public void StartWalking()
    {
        isWalking = true;
    }

    // Call this method when the player stops walking
    public void StopWalking()
    {
        isWalking = false;
    }

    private void PlayFootstep()
    {
        AudioClip footstepSound = null;
        string surfaceTag = GetSurfaceTag();

        if (surfaceTag == "Wood")
        {
            footstepSound = woodFootstepSounds[Random.Range(0, woodFootstepSounds.Length)];
        }
        else if (surfaceTag == "Stone")
        {
            footstepSound = stoneFootstepSounds[Random.Range(0, stoneFootstepSounds.Length)];
        }

        if (footstepSound != null)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }

    private string GetSurfaceTag()
    {
        RaycastHit hit;
        // Raycast downwards from the player's position
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            return hit.collider.tag;
        }
        return "Unknown";
    }

    private bool IsPlayerMoving()
    {
        // Check if the player's position has changed since the last frame
        return Vector3.Distance(transform.position, lastPosition) > 0.001f;
    }

}
