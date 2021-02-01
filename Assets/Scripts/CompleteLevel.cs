using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{

    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;


    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    private void Start()
    {

    }

    public void Continue()
    {
        if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo("LevelSelect");
    }

    public void Menu()
    {
        if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo(menuSceneName);
    }

}
    

