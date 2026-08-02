using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithButton : MonoBehaviour, Interactable
{

    public static InteractWithButton Instance;
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
        {
            int layer = LayerMask.NameToLayer("GroundNormal");

            foreach (GameObject obj in FindObjectsOfType<GameObject>())
            {
                if (obj.layer == layer)
                {
                    obj.SetActive(false);
                }
            }
        }

    }

    public void setCanInteract(bool value)
    {
        canInteract = value;
    }

}
