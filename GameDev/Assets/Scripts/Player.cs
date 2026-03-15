using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float initialMovespeed = 5.0f;
    [SerializeField] private float sprintMulitiplyer = 1.5f;

    private float movespeed;
    public Rigidbody rb;
    PlayerInput playerInput;
    InputAction move;
    InputAction sprint;
    // Start is called once before the first execution of Update after the MonoBehaviour is createdd
    void Start()
    {
        this.movespeed = initialMovespeed;
        rb = this.GetComponent<Rigidbody>();
        playerInput = this.GetComponent<PlayerInput>();
        move= this.playerInput.actions.FindAction("Move");
        sprint = this.playerInput.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        CheckSprint();
        MovePlayer();
        this.movespeed = initialMovespeed;

    }
    void MovePlayer()
    {
        Vector2 direction= move.ReadValue<Vector2>();
        Debug.Log(direction);
        rb.transform.position+= new Vector3(direction.x, 0, direction.y) * movespeed * Time.deltaTime;
    }

    void CheckSprint()
    {
        if (sprint.IsPressed())
        {
            this.movespeed *= sprintMulitiplyer;
        }
        else
        {
            movespeed  = initialMovespeed;
        }
    }
}
