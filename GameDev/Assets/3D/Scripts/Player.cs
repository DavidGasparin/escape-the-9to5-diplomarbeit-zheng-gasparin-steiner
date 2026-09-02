using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

//test
public class Player : MonoBehaviour
{
    //@Todo: Spieler soll langsamer werden wen gehen aufhört und nicht dierekt stoppen -> speed immer halbieren oder so
    [SerializeField] private float initialMovespeed = 5.0f;
    [SerializeField] private float sprintMulitiplyer = 1.5f;
    [SerializeField] public SoundManager soundManager;

    private float audioSpeedNormal = 1;
    private float audioSprintSpeed; 
    private float sprintSpeed;

    private float movespeed;
    public Rigidbody rb;
    PlayerInput playerInput;
    InputAction move;
    InputAction sprint;
    bool isFrozen = false;
    private Vector2 input;





    // Start is called once before the first execution of Update after the MonoBehaviour is createdd
    void Start()
    {
        caculatSpeeds();
        rb = this.GetComponent<Rigidbody>();
        playerInput = this.GetComponent<PlayerInput>();
        move= this.playerInput.actions.FindAction("Move");
        sprint = this.playerInput.actions.FindAction("Sprint");
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        sprintSpeed = initialMovespeed * sprintMulitiplyer;
        audioSprintSpeed = audioSpeedNormal * sprintMulitiplyer;
    }

    // Update is called once per frame
    void Update()
    {
        movespeed = initialMovespeed;

        if (isFrozen)  
            return;

        if (sprint.IsPressed())
        {
            movespeed = sprintSpeed;
        }

        MovePlayer(movespeed);

        if (input.magnitude > 0.1f)
        {
            if (!soundManager.IsPlaying())
            {
                soundManager.Play();
            }

            if (sprint.IsPressed())
            {
                soundManager.SetSpeed(audioSprintSpeed);
            }
            else
            {
                soundManager.SetSpeed(audioSpeedNormal);
            }
        }
        else
        {
            if (soundManager.IsPlaying())
            {
                soundManager.Stop();
            }
        }
    }

    void MovePlayer(float speed)
    {
        input = move.ReadValue<Vector2>();
        
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

    public void freezePLayer()
    {
        isFrozen = true;
    }

    public void unfreezePlayer()
    {
        isFrozen = false;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
