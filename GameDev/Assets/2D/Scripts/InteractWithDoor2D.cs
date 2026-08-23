using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithDoor2D : MonoBehaviour, Interactable
{
     public static InteractWithDoor2D Instance;

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

        int targetIndex = 0;

        if (isForward)
        {
            SceneManager.LoadScene("Riddle3");;
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

        GameState.hasSolvedRiddle2 = true;
        GameState.hasSolvePlatformer = true;
        SceneManager.LoadScene(targetIndex);
    } 

    public void setCanInteract(bool value)
    {
        canInteract = value;
        Debug.Log("Door opened");
    }

}