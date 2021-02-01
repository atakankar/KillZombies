using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public GameObject hintUI;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(hintUI, 15);
    }

    
}
