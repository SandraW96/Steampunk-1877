using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freez : PickUp
{
    public int freezTime = 10;

    public override void Picked()
    {
        GameMenager.gameMenager.FreezTime(freezTime);
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
