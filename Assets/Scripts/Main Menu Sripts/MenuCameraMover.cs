using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private float speed = 0.3f;
    private float moveTime = 45.0f; // Time in seconds before changing direction

    private Vector3 direction = Vector3.right; // Initial movement direction (to the right)
    private float timer = 0.0f;

    void Update()
    {
        // Move the camera in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);

        timer += Time.deltaTime;

        // Check if the time to change direction has elapsed
        if (timer >= moveTime)
        {
            direction = -direction;
            timer = 0.0f;
        }
    }
}
