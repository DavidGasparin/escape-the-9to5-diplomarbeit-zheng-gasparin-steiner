using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    private Vector2 lookInput;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Kamera hoch/runter
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Player links/rechts drehen
        playerBody.Rotate(Vector3.up * mouseX);
    }
}