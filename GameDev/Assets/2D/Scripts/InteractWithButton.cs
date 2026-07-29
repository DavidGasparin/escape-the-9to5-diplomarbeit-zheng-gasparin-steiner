using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithButton : MonoBehaviour, Interactable
{



    public static InteractWithButton Instance;
    GameObject level;
    private bool canInteract = true;

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
        level.gameObject.SetActive(false);

    }

    public void setCanInteract(bool value)
    {
        canInteract = value;
        Debug.Log("Door opened");
    }

}
