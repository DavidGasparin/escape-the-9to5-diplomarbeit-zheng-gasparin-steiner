using UnityEngine;

public class TestBlock : MonoBehaviour, IInteractable
{
   

    public void Interact()
    {
        Debug.Log(" Interact wurde aufgerufen auf: " + gameObject.name);
    }
}