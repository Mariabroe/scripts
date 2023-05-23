using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDespawnRed : MonoBehaviour
{
    private ComboManager comboManager;

    // Reference to SoundManager script
    private SoundManager soundManager;

    // Your audio clip
    public AudioClip crateDestroySound;

    private void Start()
    {
        // Find the ComboManager instance
        comboManager = FindObjectOfType<ComboManager>();
        // Find the SoundManager instance
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedKnuckles")
        {
            comboManager.IncrementCombo(); // increment the combo
            // Call SoundManager to play sound
            soundManager.PlaySound(crateDestroySound);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "ComboBreaker")
        {
            comboManager.ResetCombo(); // reset the combo if the crate was destroyed by the limit
            Destroy(gameObject);
        }
    }
}
