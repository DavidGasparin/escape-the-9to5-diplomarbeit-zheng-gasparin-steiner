using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static String currentScene = "Riddle1";
    public static bool hasSolvedRiddle1 = false;
    public static bool hasSolvedRiddle2 = false;
    public static bool hasSolvePlatformer = false;
    public static bool hasSolvedRiddle3 = false;

    public static bool getFromName(string name)
    {
        switch (name)
        {
            case "Riddle1":
                return hasSolvedRiddle1;

            case "Riddle2":
                return hasSolvedRiddle2;
            case "2DPlatformer":
                return hasSolvePlatformer;
            case "Riddle3":
                return hasSolvedRiddle3;

            default:
                Debug.Log("Unbekannte Scene");
                return false;
        }
    }

    public static void setCurrentScene(String scene) { 
        currentScene = scene;
        }

    public static String getCurrentScene() { return currentScene; }



    public static void saveeverything()
    {
        PlayerPrefs.SetString("currentScene", currentScene);
        PlayerPrefs.SetInt("hasSolvedRiddle1", hasSolvedRiddle1 ? 1 : 0);
        PlayerPrefs.SetInt("hasSolvedRiddle2", hasSolvedRiddle2 ? 1 : 0);
        PlayerPrefs.SetInt("hasSolvePlatformer", hasSolvePlatformer ? 1 : 0);
        PlayerPrefs.SetInt("hasSolvedRiddle3", hasSolvedRiddle3 ? 1 : 0);
        PlayerPrefs.Save();
    }


    public static void loadeverything()
    {
        currentScene = PlayerPrefs.GetString("currentScene", "Riddle1");
        hasSolvedRiddle1 = PlayerPrefs.GetInt("hasSolvedRiddle1", 0) == 1;
        hasSolvedRiddle2 = PlayerPrefs.GetInt("hasSolvedRiddle2", 0) == 1;
        hasSolvePlatformer = PlayerPrefs.GetInt("hasSolvePlatformer", 0) == 1;
        hasSolvedRiddle3 = PlayerPrefs.GetInt("hasSolvedRiddle3", 0) == 1;
    }
}
