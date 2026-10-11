using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
    InputAction close;
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
        close = playerInput.actions.FindAction("Close");
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        sprintSpeed = initialMovespeed * sprintMulitiplyer;
        audioSprintSpeed = audioSpeedNormal * sprintMulitiplyer;
    }


    private bool blockMenuForOneFrame = false;

    void Update()
    {

        if (isFrozen)
            return;

        movespeed = initialMovespeed;

        bool uiActive = IsAnyUIActive();

    
        if (uiActive)
        {
            blockMenuForOneFrame = true;
            return;
        }

        
        if (blockMenuForOneFrame)
        {
            blockMenuForOneFrame = false;
            return;
        }

    
        if (close.WasPressedThisFrame())
        {
            menuScreen();
        
        }


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
    bool IsAnyUIActive()
    {
        return
            (NoteUI.Instance != null &&
             NoteUI.Instance.IsNoteActive()) ||

            (NoteUIDisplay.Instance != null &&
             NoteUIDisplay.Instance.IsNoteActive()) ||

            (Display.Instance != null &&
             Display.Instance.IsNoteActive()) ||

            (Save.Instance != null &&
             Save.Instance.IsNoteActive());
    }

    void menuScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameState.setCurrentScene(SceneManager.GetActiveScene().name);
        unfreezePlayer();
        // alles speichern in db
        GameState.saveeverything();
        SceneManager.LoadScene("MainMenue");
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
