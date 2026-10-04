using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Dropdown fpsDropdown;



    private readonly int[] fpsValues = { 30, 60, 90, 120, -1 };



    void Awake()
    {
        BuildDropdown();
    }

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

    }

    private void BuildDropdown()
    {
        fpsDropdown.ClearOptions();
        var options = new List<string>();
        foreach (int fps in fpsValues)
            options.Add(fps == -1 ? "Unlimited" : fps.ToString());
        fpsDropdown.AddOptions(options);
    }

    public void OnFPSDropdownChanged(int indexFromEvent)

    {
      

        int fps;
        switch (indexFromEvent)
        {
            case 0: fps = 30; break;
            case 1: fps = 60; break;
            case 2: fps = 90; break;
            case 3: fps = 120; break;
            case 4: fps = -1; break;
            default: fps = 60; break;
        }

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;

        PlayerPrefs.SetInt("FPSLimit", fps);
        PlayerPrefs.Save();

        Debug.Log($"Index: {indexFromEvent} | FPS: {(fps == -1 ? "Unlimited" : fps.ToString())}");
    }

}