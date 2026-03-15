using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5.0f;
    public Rigidbody rb;
    PlayerInput playerInput;
    InputAction move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        playerInput = this.GetComponent<PlayerInput>();
        move= this.playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        Vector2 direction= move.ReadValue<Vector2>();
        Debug.Log(direction);
        rb.transform.position+= new Vector3(direction.x, 0, direction.y) * movespeed * Time.deltaTime;
    }
}
