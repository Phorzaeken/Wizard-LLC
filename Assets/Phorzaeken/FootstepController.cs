using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Array to hold footstep sound clips
    public float minTimeBetweenFootsteps = 0.3f; // Minimum time between footstep sounds
    public float maxTimeBetweenFootsteps = 0.6f; // Maximum time between footstep sounds

    public AudioSource audioSource; // Reference to the Audio Source component
    private bool isWalking = false; // Flag to track if the player is walking
    private float timeSinceLastFootstep; // Time since the last footstep sound

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            StartWalking();        
        }
        // Check if the player is walking
        if (isWalking)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {

                var val1 = 0;
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
                    StopWalking();
                }
            }
        }
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
}
