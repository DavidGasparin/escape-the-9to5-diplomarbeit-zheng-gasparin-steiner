using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    //@Todo: Spieler soll langsamer werden wen gehen aufhört und nicht dierekt stoppen -> speed immer halbieren oder so
    [SerializeField] private float initialMovespeed = 5.0f;
    [SerializeField] private float sprintMulitiplyer = 1.5f;

    private float sprintSpeed;

    private float movespeed;
    public Rigidbody rb;
    PlayerInput playerInput;
    InputAction move;
    InputAction sprint;

    // Start is called once before the first execution of Update after the MonoBehaviour is createdd
    void Start()
    {
        caculatSpeeds();
        rb = this.GetComponent<Rigidbody>();
        playerInput = this.GetComponent<PlayerInput>();
        move= this.playerInput.actions.FindAction("Move");
        sprint = this.playerInput.actions.FindAction("Sprint");
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (sprint.IsPressed())
        {
            MovePlayer(sprintSpeed);
        }
        MovePlayer(initialMovespeed);
    }

    void MovePlayer(float speed)
    {
        Vector2 input = move.ReadValue<Vector2>();
        Vector3 moveDir = (transform.forward * input.y + transform.right * input.x).normalized;
        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    }
    public void setInitialSpeed(float newSpeed)
    {
        this.initialMovespeed = newSpeed;
        caculatSpeeds();
    }

    public void setSprintMultiplyer(float newMultiplyer)
    {
        this.sprintMulitiplyer = newMultiplyer;
        caculatSpeeds();
    }
     private void caculatSpeeds()
    {
        this.movespeed = initialMovespeed;
        this.sprintSpeed = initialMovespeed * sprintMulitiplyer;
    }
}
