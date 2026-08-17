using JetBrains.Annotations;
using System.Linq;
using TMPro;
using Unity.Profiling.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WhiteBoard : MonoBehaviour
{
    private InputAction select;
    [SerializeField] private GameObject notePanel;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI riddleText;
    bool leftPlusWasLast = false;
    bool leftMinusWasLast = false;
    bool rightPlusWasLast = false;
    bool rightMinusWasLast = false;
    private Player player;

    private char[] encryptedText =
    {
        'M','6','7','8','T',' ',
        '7','8','T',' ',
        '6','8',' ',
        'B','6','8','8','6','1',' ',
        'D','7','6',' ',
        'G','9','5','Z','6',' ',
        'W','9','3','1','3','6','7','T',' ',
        'Z','4',' ',
        'W','7','8','8','6','5',' ',
        '6','G','9','L',',',' ',
        '0','B',' ',
        'D','4',' ',
        'D','7','1',' ',
        '2','0','5',' ',
        '2','7','6','L','6','5',' ',
        'D','6','T','9','7','L','8',' ',
        'D','7','6',' ',
        'W','9','3','1','3','6','7','T',' ',
        'D','6','5','K','6','5',' ',
        'K','9','5','5','8','T','!'

    };

    private char[] left = {
            '0','1','2','3','4','5','6','7','8','9'
        };

    private char[] right =
    {
        'A', 'E', 'I', 'O', 'U', 'N', 'S', 'R', 'V', 'H'
    };

    private int selectedLeft; // index of 7
    private int selectedRight; // index of C

    private void Awake()
    {
        if (player == null)
            player = FindFirstObjectByType<Player>();

        select = playerInput.actions.FindAction("Select");
    }


    void Start()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }

        if (playerInput != null)
        {
            select = playerInput.actions.FindAction("Select");
        }

        selectedLeft = 0;
        selectedRight = 0;
        updateUI();
    }

    private void swapLeftRight()
    {
        char leftBuffer = left[selectedLeft];

        left[selectedLeft] = right[selectedRight];
        right[selectedRight] = leftBuffer;

        updateUI();
    }

    private void swap(int oldChar, int newChar)
    {
        for (int i = 0; i < encryptedText.Length; i++)
        {
            if (encryptedText[i] == left[oldChar])
            {
                encryptedText[i] = right[newChar];
            }
        }
        updateUI();
    }

    private int getNextChar(char[] arr, int current)
    {
        if (current == arr.Length - 1)
        {
            return 0;
        }
        return current + 1;
    }

    private int getPreviousChar(char[] arr, int current)
    {
        if (current == 0)
        {
            return arr.Length - 1;
        }
        return current - 1;
    }

    private void updateUI()
    {
        riddleText.text = new string(encryptedText);
        leftText.text = left[selectedLeft].ToString();
        rightText.text = right[selectedRight].ToString();
    }
    public void swapChar()
    {
        Debug.Log($"🔄 swapChar: selectedLeft='{selectedLeft}', selectedRight='{selectedRight}'");

        if (leftPlusWasLast)
        {
            // gehe einen Schritt zurück, aber mit Wrap-Around
            selectedLeft = (selectedLeft - 1 + left.Length) % left.Length;
            swap(selectedLeft, selectedRight);
            swapLeftRight();
        }
        else if (leftMinusWasLast)
        {
            selectedLeft = (selectedLeft + 1) % left.Length;
            swap(selectedLeft, selectedRight);
            swapLeftRight();
        }
        else if (rightPlusWasLast)
        {
            selectedRight = (selectedRight - 1 + right.Length) % right.Length;
            swap(selectedLeft, selectedRight);
            swapLeftRight();
        }
        else if (rightMinusWasLast)
        {
            selectedRight = (selectedRight + 1) % right.Length;
            swap(selectedLeft, selectedRight);
            swapLeftRight();
        }
    }

    public void nextLeft()
    {
        leftPlusWasLast = true;
        leftMinusWasLast = false;
        rightPlusWasLast = false;
        rightMinusWasLast = false;
        selectedLeft = getNextChar(left, selectedLeft);
        updateUI();
    }

   

    public void previousLeft()
    {
        leftPlusWasLast = false;
        leftMinusWasLast = true;
        rightPlusWasLast = false;
        rightMinusWasLast = false;
        selectedLeft = getPreviousChar(left, selectedLeft);
        updateUI();
        

    }

    public void nextRight()
    {
        leftPlusWasLast = false;
        leftMinusWasLast = false;
        rightPlusWasLast = true;
        rightMinusWasLast = false;
        selectedRight = getNextChar(right, selectedRight);
        updateUI();
    }

    public void previousRight()
    {
        leftPlusWasLast = false;
        leftMinusWasLast = false;
        rightPlusWasLast = false;
        rightMinusWasLast = true;
        selectedRight = getPreviousChar(right, selectedRight);
        updateUI();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (select == null || notePanel == null)
            return;

        if (select.WasPressedThisFrame() &&
            notePanel.activeSelf)
        {
            swapChar();
        }

    }
}