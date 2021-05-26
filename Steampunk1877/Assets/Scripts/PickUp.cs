﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    AudioClip pickedClip;
    public virtual void Picked()
        {
        Debug.Log("Podniesione!");
        GameMenager.gameMenager.PlayClip(pickedClip);
        Destroy(this.gameObject);
        
    }
    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 5f, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
