using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;

    public void quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        fader.FadeTo("LevelSelect");
    }

}
