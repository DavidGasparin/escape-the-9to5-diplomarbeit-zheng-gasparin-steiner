using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithDoor2D : MonoBehaviour
{
    public static InteractWithDoor2D Instance;

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
        SceneManager.LoadScene("Riddle2");

    }

    public void setCanInteract(bool value)
    {
        canInteract = value;
        Debug.Log("Door opened");
    }

}