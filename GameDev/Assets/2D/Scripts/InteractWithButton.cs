using UnityEngine;

public class InteractWithButton : MonoBehaviour, Interactable
{

    public static InteractWithButton Instance;
    private bool canInteract = true;
    [SerializeField]  private InteractWithDoor2D interactWithDoor;


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
        interactWithDoor.setCanInteract(true);
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
