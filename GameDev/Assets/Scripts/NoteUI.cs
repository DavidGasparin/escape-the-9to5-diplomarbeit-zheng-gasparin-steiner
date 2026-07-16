using System;
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


        Instance = this;
        close = playerInput.actions.FindAction("Close");
        notePanel.SetActive(false);
       
    }

    public void ShowNote(string text)
    {
        notePanel.SetActive(true);
        noteText.text = text;
        player.freezePLayer();
        camera.freezeCamera();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideNote()
    {
        notePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.unfreezePlayer(); 
        camera.unfreezeCamera();

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