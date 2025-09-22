using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [Header("Pitch Variation Settings")]
    public float minPitch = 0.95f; //Minimum pitch variation
    public float maxPitch = 1.05f; //Maximum pitch variation
    public float volume = 1.0f; //Volume for sound effects

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // Implementing Singleton pattern -> only one instance of SoundManager should exist
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    // Method to play a sound effect at a specific position with random pitch variation
    public void PlaySound(AudioClip clip, Vector3 position)
    {
        if (clip == null) return; // Safety check

        // Create a temporary GameObject to play the sound
        GameObject tempGO = new GameObject("TempAudio"); // Create the temporary object
        tempGO.transform.position = position; // Set its position


        AudioSource audioSource = tempGO.AddComponent<AudioSource>(); // Add an AudioSource component
        audioSource.clip = clip; // Assign the clip to the AudioSource

        audioSource.volume = volume; // Set the volume
        audioSource.pitch = Random.Range(minPitch, maxPitch); // Apply random pitch variation

        // ---Configure the AudioSource for 3D sound + play the sound---
        audioSource.spatialBlend = 1.0f; // Make the sound 3D
        audioSource.Play(); // Play the sound


        Destroy(tempGO, clip.length / audioSource.pitch); // Destroy the temporary object after the clip finishes playing
    }

    // Overloaded method to play a sound effect at the SoundManager's position (useful for UI sounds) -- not 3D
    public void PlaySound2D(AudioClip clip)
    {
        if (clip == null) return;

        // Create a temporary GameObject to play the sound
        GameObject tempGO = new GameObject("TempAudio2D"); // Create the temporary object
        AudioSource audioSource = tempGO.AddComponent<AudioSource>(); // Add an AudioSource component
        audioSource.clip = clip; // Assign the clip to the AudioSource
        audioSource.volume = volume; // Set the volume
        audioSource.spatialBlend = 0.0f; // Make the sound 2D

        // ---Apply random pitch variation---
        audioSource.pitch = Random.Range(minPitch, maxPitch); 

        // ---Play the sound--- 2DSound
        audioSource.Play(); 

        Destroy(tempGO, clip.length / audioSource.pitch); // Destroy the temporary object after the clip finishes playing
    }

}
