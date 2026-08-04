using UnityEngine;

public class InteractionWithBookshelf : MonoBehaviour, Interactable
{
    public static bool hasReadNotes = false;

    [SerializeField] private float moveDistance = 2.5f;
    [SerializeField] private float moveSpeed = 3f;

    private static int counter = 0;

    private Vector3 targetPosition;
    private bool bewegtSich = false;

    private void Start()
    {
        // Nur den X-Wert im Inspector um 2,5 erhöhen.
        targetPosition = transform.localPosition;
        targetPosition.x += moveDistance;
    }

    public bool CanInteract()
    {
        if (counter >= 4)
            hasReadNotes = true;

        return hasReadNotes;
    }


    public void setCanInteract(bool value)
    {
        hasReadNotes = value;
    }
    public static void incrementCounter(int value)
    {
        counter += value;
    }

    public void Interact()
    {
        if (!CanInteract() || bewegtSich)
            return;

        Debug.Log("Bücherregal bewegt sich nach rechts.");
        bewegtSich = true;
    }

    public void SetCanInteract(bool value)
    {
        hasReadNotes = value;
    }

    private void Update()
    {
        if (!bewegtSich)
            return;

        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.localPosition, targetPosition) < 0.001f)
        {
            transform.localPosition = targetPosition;
            bewegtSich = false;

            Debug.Log("Bücherregal ist am Ziel.");
        }
    }
}