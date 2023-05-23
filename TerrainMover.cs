using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMover : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.z <= -150)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = 150;
            transform.position = newPosition;
        }
    }
}
