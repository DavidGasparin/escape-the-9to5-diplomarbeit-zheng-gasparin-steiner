using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InteractWithSave : MonoBehaviour, Interactable
{

    private bool canInteract = true;
    public Save save;

    public bool CanInteract()
    {
        return canInteract;
    }

    public void Interact()
    {
        Debug.Log(" Interact wurde aufgerufen auf: " + gameObject.name);
        save.Oeffnen();
    }

    public void setCanInteract(bool value)
    {
        canInteract = value;
    }

}
