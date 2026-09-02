using UnityEngine;

public class InteractWithNotes : MonoBehaviour, Interactable
{
    public static bool canInteract = true;

    [SerializeField] public SoundManager soundManager;

    private int increment = 1;

    [TextArea]
    public string noteText;

    public bool CanInteract()
    {
        return canInteract;
    }
    public void Interact()
    {
        Debug.Log(" Interact wurde aufgerufen auf: " + gameObject.name);
        NoteUI.Instance.ShowNote(noteText);
        soundManager.Play();

        // counter um 1 erhöhen
        InteractionWithBookshelf.incrementCounter(increment);
        increment = 0;
    }

    public void setCanInteract(bool value)
    {
        canInteract = value;
    }

    public void setNoteText(string text)
    {
        noteText = text;
    }
}


