﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDafet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<BossHealthManager>())
        {
            return;
        }
        Destroy(gameObject);
    }
}
