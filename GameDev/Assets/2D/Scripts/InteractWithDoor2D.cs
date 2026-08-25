using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithDoor2D : MonoBehaviour, Interactable
{
     public static InteractWithDoor2D Instance;

    [SerializeField] String destination;
    public bool canInteract = false;

    private void Awake()
    {
        Instance = this;
    }

    public bool CanInteract()
    {
        if (GameState.hasSolvedRiddle2)
        {
            canInteract = true;

            int layer = LayerMask.NameToLayer("GroundNormal");

            foreach (GameObject obj in FindObjectsOfType<GameObject>())
            {
                if (obj.layer == layer)
                {
                    obj.SetActive(false);
                }
            }
        }
        if (GameState.getFromName(SceneManager.GetActiveScene().name))
        {
            setCanInteract(true);
        }
        return canInteract;
    }

    public void Interact()
    {
        if(destination != "Riddle2"){
            GameState.hasSolvedRiddle2 = true;
            GameState.hasSolvePlatformer = true;
            SceneManager.LoadScene(destination);
        }
        SceneManager.LoadScene(destination);
    } 

    public void setCanInteract(bool value)
    {
        canInteract = value;
        Debug.Log("Door opened");
    }

}