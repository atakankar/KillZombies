using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int maxHealth = 100;
    public static int currentHealth;

    public static int Rounds;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth; 
    }

    public void DedectHealth(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }

    public void KillPlayer()
    {
        
    }

    public void AddHealth(int value)
    {
        currentHealth += value;
        if(currentHealth> maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
