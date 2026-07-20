using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.AI;
using System.Security.Cryptography.X509Certificates;

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

    private bool open = false;



    InputAction close;


    private int firstNumber = 0;
    private int secoundNumber = 0;


    private void Awake()
    {
         if (player == null)
            player = FindFirstObjectByType<Player>();

        if (camera == null)
            camera = FindFirstObjectByType<PlayerLook>();
        
        FreezeManager.Init(player, camera);
        Instance = this;
        Debug.Log("PlayerInput: " + playerInput);
        close = playerInput.actions.FindAction("Close");
    }

    public void OpenSave()
    {
        uiPanel.SetActive(true);
        feedbackText.text = "";
        FreezeManager.Freeze();
        FreezeManager.ShowCursor();
        Accept();
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
        Debug.Log("Accept auf Save ausgeführt");
        if ($"{firstNumber}{secoundNumber}" == richtigerPin || open)
        {
            screenPin.text = "";  
            feedbackText.text = "Geöffnet!";
            feedbackText.color = Color.green;
            open = true;
        }
        UpdateSave();
    } 
    void UpdateSave()
    {
        if(!feedbackText.text.Equals("Geöffnet!")){
        screenPin.text = $"{firstNumber}{secoundNumber}";
        }
        Debug.Log("current code: " + $"{firstNumber}{secoundNumber}");
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
        FreezeManager.Unfreeze();
        FreezeManager.HideCursor();
    }
       public bool IsNoteActive()
    {
        return uiPanel.activeSelf;
    }

}