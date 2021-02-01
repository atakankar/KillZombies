using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public wave[] waves;

    public Transform[] spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    public GameManager gameManager;

    void Update ()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {              
        PlayerHealth.Rounds++;

        wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        Debug.Log("Wave Is Coming!");
        for(int i = 0; i <wave.count;i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/ wave.rate);
        }
        waveIndex++;
       
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint[Random.Range(0, spawnPoint.Length)].position, spawnPoint[Random.Range(0, spawnPoint.Length)].rotation);
    }
}
