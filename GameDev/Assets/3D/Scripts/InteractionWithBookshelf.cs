using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class InteractionWithBookshelf : MonoBehaviour, Interactable
{

    public static bool hasReadNotes = false;
    [SerializeField] private NoteUI noteUI;
    private float zielX;
    private static int counter = 0;
    bool bewegtSich = false;

    public bool CanInteract()
    {
        if(counter >= 4)
            hasReadNotes = true;

        return hasReadNotes;
    }

        void Start()
    {   
        zielX = transform.position.x + 5; 
    }

    public static void incrementCounter(int value)
    {
        counter +=value;
    }

    public void Interact()
    {
        if (CanInteract())
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