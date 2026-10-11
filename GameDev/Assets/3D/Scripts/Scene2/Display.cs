using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Display : MonoBehaviour{

    InputAction select;
    PlayerInput playerInput;
    public static Display Instance;

    [SerializeField] private GameObject notePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
    }



    void Start()
    {
        playerInput = this.GetComponent<PlayerInput>();
        select = this.playerInput.actions.FindAction("Select");
    }

    // Update is called once per frame
    void Update()
    {
        if (select.IsPressed() && notePanel.activeSelf )
        {
            ButtonPressed();
        }
    }


    public void ButtonPressed()
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene("2DPlatformer");
    }
    public bool IsNoteActive()
    {
        return notePanel.activeSelf;
    }

}
