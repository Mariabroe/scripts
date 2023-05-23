using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerMinecart : MonoBehaviour
{
    private Quaternion originalRotation; // Store the original rotation of the object

    public float shakeAmount = 1.0f; // Amount to shake the object by
    public float shakeSpeed = 10.0f; // Speed of the shaking motion

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation; // Store the original rotation
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new rotation of the object based on the original rotation and the shake amount
        Quaternion newRotation = originalRotation * Quaternion.Euler(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount));

        // Clamp the rotation to within 1 degree of the original rotation
        newRotation = Quaternion.RotateTowards(transform.rotation, newRotation, 1.0f);

        // Set the new rotation of the object
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * shakeSpeed);
    }
}
