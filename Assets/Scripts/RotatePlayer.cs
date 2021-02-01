using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float sensivity = 3;
    private float rotateY = 0;
    private float rotateX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayerBody();
    }

    private void RotatePlayerBody()
    {
        rotateX += sensivity * Input.GetAxis("Mouse X");
        rotateY += sensivity * Input.GetAxis("Mouse Y")*-1;
        rotateY = Mathf.Clamp(rotateY, -60, 60);
        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
    }
}
