using UnityEngine;

public interface Interactable
{
    bool CanInteract();

    void setCanInteract(bool value);
    void Interact();
}
