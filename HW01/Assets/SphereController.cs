using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the sphere moves
    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from WASD keys or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Apply force to the Rigidbody in the movement direction
        rb.AddForce(movement * moveSpeed);
    }
}