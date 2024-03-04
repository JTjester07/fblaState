using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UniqueAudioSource : MonoBehaviour
{
    private static UniqueAudioSource instance;

    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance of UniqueAudioSource exists
        if (instance == null)
        {
            instance = this;
            // Keep this GameObject alive when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another instance exists, destroy this one
            Destroy(gameObject);
            return;
        }

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if there's another GameObject with the same AudioSource clip and destroy it
        UniqueAudioSource[] audioSourcesInScene = FindObjectsOfType<UniqueAudioSource>();
        foreach (UniqueAudioSource audioSourceInstance in audioSourcesInScene)
        {
            if (audioSourceInstance != instance && audioSourceInstance.audioSource.clip == audioSource.clip)
            {
                Destroy(audioSourceInstance.gameObject);
                break;
            }
        }
    }
}
