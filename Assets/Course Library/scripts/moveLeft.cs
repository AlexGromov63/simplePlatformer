﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 10;
    public float speedModifier = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed);
        speed *= speedModifier;
    }
}
