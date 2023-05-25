using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Adjust the speed of movement as desired

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Get input along the X-axis (left/right arrow keys or A/D keys)
        float moveZ = Input.GetAxis("Vertical"); // Get input along the Z-axis (up/down arrow keys or W/S keys)

        // Calculate the new position based on the input
        Vector3 newPosition = transform.position + new Vector3(moveX * moveSpeed * Time.deltaTime, 0f, moveZ * moveSpeed * Time.deltaTime);

        // Move the object along the X and Y axes
        transform.position = newPosition;
    }
}