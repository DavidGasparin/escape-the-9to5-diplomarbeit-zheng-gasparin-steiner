using UnityEngine;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour



{

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonPressed()
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene("2DPlatformer");
    }
}
