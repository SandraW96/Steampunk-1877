﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlace : MonoBehaviour
{
    float alfa = 0;

    public float Resizer()
    {
        float value = Mathf.Sin(alfa);
        alfa += (1.5f * Time.deltaTime);
        return value + 2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameMenager.gameMenager.WinGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float scale = Resizer();
        transform.localScale = new Vector3(scale, 4.5f, scale);
    }
}
