using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WhiteboardRiddle : MonoBehaviour
{

    InputAction select;
    [SerializeField] private GameObject notePanel;
    [SerializeField] private PlayerInput playerInput;

    //Lösung des Satzes:Meist ist es besser die ganze Warheit zu wissen egal, ob du dir von vielen Details die Warheit denken kannst!
    // Letters and Enchryped Letters(Numners)
    char[] chars =
 {
    'M', '6', '7', '8', '5', ' ',
    '7', '8', '5', ' ',
    '6', '8', ' ',
    'V', '6', '8', '8', '6', '1', ' ',
    '4', '7', '6', ' ',
    '3', '9', '5', 'z', '6', ' ',
    'W', '9', '1', '3', '6', '7', '5', ' ',
    'z', '4', ' ',
    'w', '7', '8', '8', '6', '5', ' ',
    '6', '3', '9', 'l', ',', ' ',
    '0', 'V', ' ',
    'd', '4', ' ',
    'd', '7', '1', ' ',
    'v', '0', '5', ' ',
    'v', '7', '6', 'l', '6', '5', ' ',
    'D', '6', 't', '9', '7', 'l', '8', ' ',
    'd', '7', '6', ' ',
    'W', '9', '1', '3', '6', '7', '5', ' ',
    'd', '6', '5', 'k', '6', '5', ' ',
    'k', '9', '5', '5', '8', 't', '!'
};
    private char currentSelectedChar;
    private char currentAvailableChar;

    private HashSet<char> available;


   


    // Only Letters that don't appear in chars
    private char[] letters = {
    'A', 'B', 'C', 'E', 'F', 'G', 'H', 'I', 'J',
    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'X', 'Y', 'Z'
};
    private HashSet<char> selection;

    [SerializeField] private TextMeshProUGUI availableText;
    [SerializeField] private TextMeshProUGUI selectedText;
    [SerializeField] private TextMeshProUGUI riddleText;

    private void writeIntoText()
    {
        String text = getText();
        InteractWithNotes note = this.GetComponent<InteractWithNotes>();
        if (note != null)
        {
            note.setNoteText(text);
        }
    }

    void Start()
    {

       

        selection = new HashSet<char>(letters);
        
        available = new HashSet<char>(chars);
        currentSelectedChar = selection.First();
        currentAvailableChar = available.First();

        availableText.text = currentAvailableChar.ToString();
        selectedText.text = currentSelectedChar.ToString();
        writeIntoText();
        playerInput = this.GetComponent<PlayerInput>();
        select = playerInput.actions.FindAction("Select");
    }

  private char NextChar(HashSet<char> set, ref char currentChar)
    {
        List<char> list = set.ToList();

        int index = list.IndexOf(currentChar);

        index++;

        if (index >= list.Count)
        {
            index = 0;
        }

        currentChar = list[index];

        return currentChar;
    }

    private char PreviousChar(HashSet<char> set, ref char currentChar)
    {
        List<char> list = set.ToList();

        int index = list.IndexOf(currentChar);

        index--;

        if (index < 0)
        {
            index = list.Count - 1;
        }

        currentChar = list[index];

        return currentChar;
    }

    private void ReplaceChar(char oldChar, char newChar)
    {
        if (!available.Contains(oldChar))
        {
            Debug.LogWarning(oldChar + " ist nicht im aktuellen Text.");
            return;
        }

        if (!selection.Contains(newChar))
        {
            Debug.LogWarning(newChar + " ist nicht in der Selection.");
            return;
        }

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == oldChar)
            {
                chars[i] = newChar;
            }
        }

        selection.Remove(newChar);
        selection.Add(oldChar);

        available = new HashSet<char>(chars);
    }

    String getText()
    {
        String text = "";
        foreach(char c in chars)
        {
            text += c;
        }
        return text;
    }


    public void ReplaceCurrent()
    {
        char oldChar = currentAvailableChar;
        char newChar = currentSelectedChar;

        ReplaceChar(oldChar, newChar);

        currentAvailableChar = newChar;
        currentSelectedChar = oldChar;
    }
    // Accept Button
    public void UpdateUI()
    {
        availableText.text = currentAvailableChar.ToString();
        selectedText.text = currentSelectedChar.ToString();
        writeIntoText();
    }


    public void NextAvailable()
    {
        availableText.text = NextChar(available, ref currentAvailableChar).ToString();
        
    }

    public void PreviousAvailable()
    {
        availableText.text = PreviousChar(available, ref currentAvailableChar).ToString();

    }

    public void NextSelected()
    {
        selectedText.text = NextChar(selection, ref currentSelectedChar).ToString();
       
    }

    public void PreviousSelected()
    {
        selectedText.text = PreviousChar(selection, ref currentSelectedChar).ToString();
    }

    void Update()
    {
        if (select.IsPressed() && notePanel.activeSelf)
        {
            ReplaceCurrent();
            UpdateUI();
        }
    }
}
