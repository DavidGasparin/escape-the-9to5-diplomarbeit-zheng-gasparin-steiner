using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private AudioMixer audioMixer;


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

    public void VsyncOn(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }

    public void SetVolume(float volume)
    {
        float dB = Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20f;

        bool success = audioMixer.SetFloat("MyExposedParam", dB);

        Debug.Log("Slider: " + volume);
        Debug.Log("dB: " + dB);
        Debug.Log("Erfolgreich: " + success);
    }

}