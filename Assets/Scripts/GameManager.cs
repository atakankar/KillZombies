using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject gameWinUI;

    void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        //Oyun bitti mi kontrolü
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {            
            EndGame();
        }


        //kalan canların kontrolü
        if (PlayerHealth.currentHealth <= 0)
        {
            EndGame();
        }
    }

    //Oyunu bitirme
    void EndGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Cursor.lockState = CursorLockMode.None;      
        GameIsOver = true;
        gameWinUI.SetActive(true);
    }
}
