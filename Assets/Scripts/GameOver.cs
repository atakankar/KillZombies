using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    void OnEnable()
    {
        roundsText.text = PlayerHealth.Rounds.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        WaveSpawner.EnemiesAlive = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }
}
