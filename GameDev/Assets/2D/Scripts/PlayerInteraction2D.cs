using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction2D : MonoBehaviour
{
    public Transform InteractorSource;
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



        Vector2 direction=Vector2.left;

       

        RaycastHit2D hit = Physics2D.Raycast(
            InteractorSource.position,
            direction,
            2f
        );



        if (hit.collider != null)
        {
            Debug.Log("Getroffen: " + hit.collider.name);

            if (hit.collider.CompareTag("InteractPrefab"))
            {
                if (hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    if (interactable.CanInteract())
                    
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