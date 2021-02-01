using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItem : MonoBehaviour
{
    PlayerHealth playerHealth;

    public GameObject weapon;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthItem") && PlayerHealth.currentHealth < 100)
        {
            other.gameObject.SetActive(false);
            playerHealth.AddHealth(10);
        }

        else if (other.CompareTag("AmmoItem"))
        {
            weapon.GetComponent<Shoot>().AddAmmo(10);
            other.gameObject.SetActive(false);
        }
    }




}
