using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
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

}
