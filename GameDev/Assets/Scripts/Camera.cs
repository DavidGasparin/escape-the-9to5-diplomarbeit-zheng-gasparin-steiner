using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 500f;
    public Transform playerBody;

    float xRotation = 0f;

    private Vector2 lookInput;
    public bool cameraFrozen = false;

    private InputAction lookAction;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookAction = GetComponent<PlayerInput>().actions.FindAction("Look");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
       
        if (cameraFrozen) 
            return;
        
        float lookX = lookInput.x * sensitivity * Time.deltaTime;
        float lookY = lookInput.y * sensitivity * Time.deltaTime;

        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * lookX);
    }

    public void freezeCamera()
    {
        cameraFrozen = true;
        lookInput = Vector2.zero;
        if (lookAction != null) lookAction.Disable();
    }

    public void unfreezeCamera()
    {
        cameraFrozen = false;
        lookInput = Vector2.zero;
        if (lookAction != null) lookAction.Enable();
    }
}