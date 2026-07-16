using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;


public class Interact : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public TextMeshProUGUI InteractText;
    InputAction interact;
    PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = this.GetComponent<PlayerInput>();
        interact = this.playerInput.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        InteractText.gameObject.SetActive(false); 
        if (NoteUI.Instance != null && InteractableActive())
        {
            return; 
        }

        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, InteractRange))
        {
            if (hit.collider.CompareTag("InteractPrefab"))
            {
                if (hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    if (interactable.CanInteract())
                    {
                        InteractText.gameObject.SetActive(true);

                        if (interact.WasPressedThisFrame())
                        {
                            interactable.Interact();
                        }
                    }
                }
            }
        }
    }

  private bool InteractableActive()
    {
        if (NoteUI.Instance != null && NoteUI.Instance.IsNoteActive())
            return true;

        if (Save.Instance != null && Save.Instance.IsNoteActive())
            return true;

        return false;
    }

}