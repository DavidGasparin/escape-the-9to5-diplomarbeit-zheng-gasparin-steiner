using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class InteractWithBookshelf : MonoBehaviour, Interactable
{

    public static bool hasReadNotes = false;
    [SerializeField] private NoteUI noteUI;
    private float zielX;

    bool bewegtSich = false;

    public bool CanInteract()
    {
        return hasReadNotes;
    }

        void Start()
    {   
        zielX = transform.position.x + 5; 
    }

    public void Interact()
    {
        if (hasReadNotes)
        {
            Debug.Log(" Interact wurde aufgerufen auf: " + gameObject.name);
            if (transform.position.x < zielX)
                bewegtSich = true;
        }
    }

    public void setCanInteract(bool value)
    {
        hasReadNotes = value;   
    }

     void Update()
    {
        if (!bewegtSich)
            return;
            
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
        if (transform.position.x >= zielX)
        {
            transform.position = new Vector3(zielX, transform.position.y, transform.position.z);
            enabled = false; 
            bewegtSich = false;
            hasReadNotes = false;
        }
    }
}