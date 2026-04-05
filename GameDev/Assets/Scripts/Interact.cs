using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public interface IInteractable
{
    void Interact();
}

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

        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, InteractRange)) {
            // Anzeige
            if (hit.collider.CompareTag("InteractPrefab"))
            {
                InteractText.gameObject.SetActive(true);

                // CompareTag nimmt keinen out-Parameter — statt dessen TryGetComponent verwenden
                if (hit.collider != null && hit.collider.TryGetComponent<IInteractable>(out IInteractable interactObj) && interact.IsPressed())
                {
                    interactObj.Interact();
                }
            }
        }
        else
        {
            InteractText.gameObject.SetActive(false);
        }
    }

}