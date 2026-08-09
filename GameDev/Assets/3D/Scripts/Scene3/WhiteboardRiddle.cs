using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class WhiteboardRiddle : MonoBehaviour
{
  
    // Letters and Enchryped Letters(Numners)
    private char[] chars= {'H', '1', '2', 'A', '4', '5', 'H', '1', '2', 'A', '4', '5'};
    private char currentSelectedChar;
    private char currentAvailableChar;

    private HashSet<char> available;


    // Only Letters that don't appear in chars
    private char[] Letters = {'P', 'L', 'O' };
    private HashSet<char> selection;

    [SerializeField] private TextMeshProUGUI availableText;
    [SerializeField] private TextMeshProUGUI selectedText;
    [SerializeField] private TextMeshProUGUI riddleText;

    
    
    void Start()
    {
        selection = new HashSet<char>(Letters);
        
        available = new HashSet<char>(chars);
        currentSelectedChar = selection.First();
        currentAvailableChar = available.First();
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
        riddleText.text = getText();
    }


    public void NextAvailable()
    {
        NextChar(available, ref currentAvailableChar);
    }

    public void PreviousAvailable()
    {
        PreviousChar(available, ref currentAvailableChar);
    }

    public void NextSelected()
    {
        NextChar(selection, ref currentSelectedChar);
    }

    public void PreviousSelected()
    {
        PreviousChar(selection, ref currentSelectedChar);
    }

    void Update()
    {
        
    }
}
