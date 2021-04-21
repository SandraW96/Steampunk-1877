using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{


    public enum KeyColor
    {
        Red,
        Crystal,
        Gold
    }

    public KeyColor color;

    public override void Picked()
    {
        GameMenager.gameMenager.AddKey(color);
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
