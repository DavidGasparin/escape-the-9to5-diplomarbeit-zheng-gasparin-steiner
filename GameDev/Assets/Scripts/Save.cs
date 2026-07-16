using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Save : MonoBehaviour
{
    public string richtigerPin = "32";
    public GameObject uiPanel;
    public TextMeshProUGUI screenPin;
    public TextMeshProUGUI feedbackText;
    [SerializeField] private PlayerInput playerInput;
    private Player player;
    private PlayerLook camera;

    public static Save Instance;



    InputAction close;


    private int firstNumber = 0;
    private int secoundNumber = 0;


    private void Awake()
    {
         if (player == null)
            player = FindFirstObjectByType<Player>();

        if (camera == null)
            camera = FindFirstObjectByType<PlayerLook>();
        
        Instance = this;
        Debug.Log("PlayerInput: " + playerInput);
        close = playerInput.actions.FindAction("Close");
    }

    public void OpenSave()
    {
        uiPanel.SetActive(true);
        feedbackText.text = "";
        player.freezePLayer();
        camera.freezeCamera();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Plus(int stelle)
    {
        if (stelle == 0) firstNumber = (firstNumber + 1) % 10;
        else secoundNumber = (secoundNumber + 1) % 10;
        UpdateSave();
    }

    public void Minus(int stelle)
    {
        if (stelle == 0) firstNumber = (firstNumber - 1 + 10) % 10;
        else secoundNumber = (secoundNumber - 1 + 10) % 10;
        UpdateSave();
    }

    public void Accept()
    {
        if ($"{firstNumber}{secoundNumber}" == richtigerPin)
        {
            feedbackText.text = "Geöffnet!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Falsch!";
            feedbackText.color = Color.red;
        }
        UpdateSave();
    } 
    void UpdateSave()
    {
        screenPin.text = $"{firstNumber}{secoundNumber}";
    }

    void Update()
    {
        if (uiPanel.activeSelf && close.IsPressed())
        {
            HideSave();
        }
    }

    public void HideSave()
    {
        uiPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.unfreezePlayer(); 
        camera.unfreezeCamera();
    }
       public bool IsNoteActive()
    {
        return uiPanel.activeSelf;
    }

}