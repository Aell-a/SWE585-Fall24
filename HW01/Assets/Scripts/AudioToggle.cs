using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMuted = false;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the "M" key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleAudio();
        }
    }

    void ToggleAudio()
    {
        // Toggle the muted state
        isMuted = !isMuted;

        // Set the mute state of the audio source
        audioSource.mute = isMuted;
    }
}