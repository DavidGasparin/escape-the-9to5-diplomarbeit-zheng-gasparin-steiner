using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractWithDoor : MonoBehaviour, Interactable
{

    public static InteractWithDoor Instance;

    private bool canInteract = false;

    private void Awake()
    { 
        Instance = this; 
    }

    public bool CanInteract()
    {
        return canInteract;
    }

    public void Interact()
    {
        SceneManager.LoadScene("Riddle2");

    }

    public void setCanInteract(bool value)
    {
        canInteract = value;
        Debug.Log("Door opened");
    }


}
