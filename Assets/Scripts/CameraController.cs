using UnityEngine;
using UnityEngine.InputSystem;


// CameraController manages the main camera's position and rotation to follow player. Handles mouse input for rotating around player, zooming in and out, and shift lock mode to lock camera.
public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Distance / Zoom")]
    public float distance = 5f;
    public float zoomSpeed = 5f;
    public float minDistance = 4f;
    public float maxDistance = 8f;

    [Header("Mouse Rotation")]
    public float mouseSensitivity = 200f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    [Header("Offsets")]
    public float screenOffset = 1.5f;

    [Header("Shiftlock")]
    public KeyCode shiftLockKey = KeyCode.LeftShift;
    public bool shiftLockEnabled = false;
    public float playerTurnSpeed = 12f;

    float yaw;
    float pitch = 20f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        ApplyCursorState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftLockEnabled = !shiftLockEnabled;
            ApplyCursorState();
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Right Click drag rotation
        if (shiftLockEnabled)
            {
                yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 shiftedTarget = player.position + rotation * Vector3.right * screenOffset;
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        transform.position = shiftedTarget + offset;
        transform.rotation = rotation;

        if (shiftLockEnabled)
        {
            Quaternion targetPlayerRot = Quaternion.Euler(0f, yaw, 0f);
            player.rotation = Quaternion.Slerp(
                player.rotation,
                targetPlayerRot,
                playerTurnSpeed * Time.deltaTime
            );
        }
    }

    // Ensure cursor state is applied correctly when toggling shift lock
    void ApplyCursorState()
    {
          if (shiftLockEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}