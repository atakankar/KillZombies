using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    public new Camera camera;


    public int range;
    public int damage;

    public int startMag = 30;
    public int startAmmo =90;
    public int magSize = 30;
    public int defualtAmmo = 120;
    public static int currentAmmo;
    public static int currentMagAmmo;
    public float ShootCoolDown = 0.1f;
    float lastFireTime = 0;

    int minAngle = -1;
    int maxAngle = 1;

    public GameObject bloodPrefab;
    public ParticleSystem muzzle;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = startAmmo;
        currentMagAmmo = startMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }
        if (Input.GetMouseButton(0))
        {
            if (CanFire())
            {
                Fire();
            }
        }
    }

    private void Reload()
    {
        if (currentAmmo == 0 || currentMagAmmo == magSize)
        {
            return;
        }

        else if ((currentAmmo + currentMagAmmo) < magSize) 
        {
            currentMagAmmo = currentMagAmmo +currentAmmo;
            currentAmmo = 0;
        }

        else
        {
            currentAmmo -= magSize - currentMagAmmo;
            currentMagAmmo = magSize;
        }
    }

    private bool CanFire()
    {
        if (currentMagAmmo > 0 && lastFireTime + ShootCoolDown < Time.time)
        {
            lastFireTime = Time.time + ShootCoolDown;
            return true;
        }
        return false;
    }

    private void Fire()
    {
        muzzle.Play(true);
        currentMagAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            if (hit.transform.tag =="Zombie")
            {
                hit.transform.GetComponent<ZombieHealt>().Hit(damage);
                GenerateBloodEffect(hit);
            }
            else
            {
                
            }
        }
        transform.localEulerAngles = new Vector3(Random.Range(minAngle,maxAngle), Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle));
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
        Destroy(bloodObject, 2f);
    }


    public void AddAmmo(int value)
    {
        currentAmmo += value;
        if (currentAmmo > defualtAmmo-30)
        {
            currentAmmo = defualtAmmo - 30;
        }
    }
}
