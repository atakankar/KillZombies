using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealt : MonoBehaviour
{
    public int startHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = startHealth;
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {

        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
