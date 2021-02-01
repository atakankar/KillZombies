using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public Button[] levelButtons;


    public void Start()
    {
        UnlockLevel();
    }

    public void UnlockLevel()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }

        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void Home()
    {
        fader.FadeTo("MainMenu");
    }
}
