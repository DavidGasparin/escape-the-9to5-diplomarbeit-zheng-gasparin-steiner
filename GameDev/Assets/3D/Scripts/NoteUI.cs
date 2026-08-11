using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class NoteUI : MonoBehaviour
{
    public static NoteUI Instance;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject notePanel;
    [SerializeField] private TextMeshProUGUI noteText;
    InputAction close;
    private Player player;
    private PlayerLook camera;
 

    private void Awake()
    {

       
        if (player == null)
            player = FindFirstObjectByType<Player>();

        if (camera == null)
            camera = FindFirstObjectByType<PlayerLook>();

        Debug.Log("PlayerInput: " + playerInput);

        FreezeManager.Init(player, camera);
        Instance = this;
        close = playerInput.actions.FindAction("Close");
        notePanel.SetActive(false);
       
    }

    public void ShowNote(string text)
    {
        noteText.text = text;
        notePanel.SetActive(true);
    
        FreezeManager.Freeze();
        FreezeManager.ShowCursor();       
    }

    public void HideNote()
    {
        notePanel.SetActive(false);
        FreezeManager.HideCursor();
        FreezeManager.Unfreeze();
    }

    void Update()
    {
        if (notePanel.activeSelf && close.IsPressed())
        {
            HideNote();
        }
    }

    public bool IsNoteActive()
    {
        return notePanel.activeSelf;
    }


}