using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float boostedSpeed = 8f;

    // How quickly the speed changes
    public float speedSmoothness = 5f;

    public FixedJoystick joystick;

    private Rigidbody rb;

    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = moveSpeed;
    }

    void FixedUpdate()
    {
        // Read the accelerometer
        Vector3 acceleration = Input.acceleration;

        // Check if the phone is tilted forward
        float targetSpeed = moveSpeed;

        if (acceleration.y < -0.3f)
        {
            targetSpeed = boostedSpeed;
        }

        // Smoothly change the movement speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, speedSmoothness * Time.fixedDeltaTime);

        float moveX = joystick.Horizontal;
        float moveZ = joystick.Vertical;

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        // Prevent faster diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1f);

        // Small dead zone
        if (movement.magnitude < 0.15f)
        {
            movement = Vector3.zero;
        }

        rb.linearVelocity = movement * currentSpeed;
    }
}