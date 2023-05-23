using UnityEngine;

public class speedOfForeground : MonoBehaviour
{
    public float speed = 3.0f;
    
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position + new Vector3(0, 0, -speed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }
}
