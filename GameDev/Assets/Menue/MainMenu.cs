using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;

    public void NewGame()
    {
        Debug.Log("Neues Spiel gestartet");

        SceneManager.LoadScene("Riddle1");
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        Debug.Log("Spielstand laden");
    }

    public void QuitGame()
    {
        Debug.Log("Spiel wird beendet");

        Application.Quit();
    }

    public void TestButton()
    {
        Debug.Log("Button funktioniert!");
    }
}