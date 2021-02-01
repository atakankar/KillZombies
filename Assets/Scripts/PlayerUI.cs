using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text playerHP;
    public Text playerAmmo;
    public Text zombieCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHP.text = PlayerHealth.currentHealth.ToString() + " HP";
        playerAmmo.text = Shoot.currentMagAmmo.ToString() + "/" + Shoot.currentAmmo.ToString();
        zombieCount.text = WaveSpawner.EnemiesAlive.ToString() + " ZOMBIES LEFT";
    }
}
