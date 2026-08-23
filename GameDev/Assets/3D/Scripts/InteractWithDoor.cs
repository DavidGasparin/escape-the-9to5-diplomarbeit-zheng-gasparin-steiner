using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithDoor : MonoBehaviour, Interactable
{
    public static InteractWithDoor Instance;

    public bool isForward = true;

    public bool canInteract = false;

    private void Awake()
    {
        Instance = this;
    }

    public bool CanInteract()
    {
        if (GameState.getFromName(SceneManager.GetActiveScene().name))
        {
            setCanInteract(true);
        }
        return canInteract;
    }

    public void Interact()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        int targetIndex;

        if (isForward)
        {
            targetIndex = currentIndex + 1;
        }
        else
        {
            targetIndex = currentIndex - 1;
        }

        if (targetIndex < 0 || targetIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning($"Keine Scene an Index {targetIndex}!");
            return;
        }

        Debug.Log($"Wechsle von Index {currentIndex} zu Index {targetIndex}");

        SceneManager.LoadScene(targetIndex);
    } 

    public void setCanInteract(bool value)
    {
        canInteract = value;
        Debug.Log("Door opened");
    }
}
