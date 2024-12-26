using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float fastSpeedMultiplier = 2f; 
    public float rotationSpeed = 100f; 

    public GameObject controlsUI; 

    private bool controlsVisible = true; 

    void Update()
    {
        HandleMovement();
        HandleControlsToggle();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (Input.GetKey(KeyCode.Space))
            direction.y += 1f;
        if (Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.LeftControl))
            direction.y -= 1f;

        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed *= fastSpeedMultiplier;

        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.Self);
    }

    void HandleControlsToggle()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            controlsVisible = !controlsVisible;
            if (controlsUI != null)
                controlsUI.SetActive(controlsVisible);
        }
    }
}