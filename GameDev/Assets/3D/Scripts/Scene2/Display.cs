using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Display : MonoBehaviour{

    InputAction select;
    PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = this.GetComponent<PlayerInput>();
        select = this.playerInput.actions.FindAction("Select");
    }

    // Update is called once per frame
    void Update()
    {
        if (select.IsPressed())
        {
            ButtonPressed();
        }
    }


    public void ButtonPressed()
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene("2DPlatformer");
    }
}
