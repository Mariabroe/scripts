using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    // Set the range for the random pitch adjustment
    public float lowPitchRange = 0.0001f;
    public float highPitchRange = 3.0f;

    public void PlaySound(AudioClip clip)
    {
        // Randomize the pitch
        audioSource.pitch = Random.Range(lowPitchRange, highPitchRange);

        // Play the clip
        audioSource.PlayOneShot(clip);
    }
}