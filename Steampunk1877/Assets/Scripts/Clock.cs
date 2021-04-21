using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{

    public bool addTime;
    public uint time = 5;

    public override void Picked()
    {
        int sign;
        if (addTime)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }
        GameMenager.gameMenager.AddTime((int)time * sign);
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
