using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cam;
    public CameraController CameraController;
    public Animator animator;

    private Rigidbody rb;
    private PlayerStats stats;

    private float movementY;
    private float movementX;
    private float movementZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        stats = GetComponent<PlayerStats>();
    }

    void FixedUpdate()
    {
        movementX = Input.GetAxis("Horizontal");
        movementZ = Input.GetAxis("Vertical");

        movementY = 0f;

        if (Input.GetKey(KeyCode.E))
            movementY = 1f;

        if (Input.GetKey(KeyCode.Q))
            movementY -= 1f;

        Vector2 input = Vector2.ClampMagnitude(new Vector2(movementX, movementZ), 1f);

        Vector3 moveDirection;

        if (CameraController != null && CameraController.shiftLockEnabled)
        {
            Vector3 forward = cam.forward;
            forward.y = 0f;
            forward.Normalize();

            Vector3 right = cam.right;
            right.y = 0f;
            right.Normalize();

            moveDirection = forward * input.y + right * input.x;
        }
        else
        {
            moveDirection = transform.forward * input.y + transform.right * input.x;
        }

        Vector3 velocity = moveDirection * stats.moveSpeed;
        velocity.y = movementY * stats.moveSpeed;

        rb.velocity = velocity;

        float speedValue = (input.magnitude > 0.01f || Mathf.Abs(movementY) > 0.01f) ? 1f : 0f;
        animator.SetFloat("Speed", speedValue, 0.1f, Time.fixedDeltaTime);
    }
}