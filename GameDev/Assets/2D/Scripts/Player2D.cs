using UnityEngine;
using UnityEngine.InputSystem;

public class Player2D : MonoBehaviour
{

    [SerializeField] float speed = 3f; 
    [SerializeField] float sprintSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    

    private Rigidbody2D rb; 
    PlayerInput playerInput;

    InputAction move;
    InputAction sprint;
    InputAction interact;
    InputAction reset;

    InputAction jump;

    [SerializeField] LayerMask groundLayer;

    [SerializeField] Collider2D playerCollider;
    [SerializeField] PhysicsMaterial2D noFriction;
    [SerializeField] PhysicsMaterial2D wallSlideMaterial;


    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        playerInput = this.GetComponent<PlayerInput>();
        move = this.playerInput.actions.FindAction("Move");
        sprint = this.playerInput.actions.FindAction("Sprint");
        interact = this.playerInput.actions.FindAction("Interact");
        reset = this.playerInput.actions.FindAction("Reset");
        jump = this.playerInput.actions.FindAction("Jump");
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (jump.WasPressedThisFrame() && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        if (rb.linearVelocity.y > 0)
        {
            playerCollider.sharedMaterial = noFriction;
        }
           else
        {
            playerCollider.sharedMaterial = wallSlideMaterial;
        }
        if (reset.IsPressed() || rb.transform.position.y < 0)
        {
            Reset();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Damage")
    {
        Reset();
    }
}

    void Reset()
    {
        rb.transform.position = new Vector3(-40f, 12.1f, 0f);
    }

    void FixedUpdate()
    {
          if (sprint.IsPressed())
        {
            MovePlayer(sprintSpeed);
            return;
        }
        MovePlayer(speed);  
    }


    bool IsGrounded()
    {
        return rb.linearVelocityY==0;
    }


     void MovePlayer(float speed)
    {
        float horizontal = move.ReadValue<Vector2>().x;

        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
}
