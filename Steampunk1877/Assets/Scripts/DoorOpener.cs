using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Animator anim;
    public GameObject Player;
    private bool openDoor;
    // Start is called before the first frame update
    void Start()
    {
        openDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 doorPosition = transform.position;
        Vector3 playerPosition = Player.transform.position;
        float dist = Vector3.Distance(playerPosition, doorPosition);
        if (dist<=4f)
        {
            openDoor = true;
            Debug.Log(dist);
        }
        if (dist >= 4f)
        {
            openDoor = false;
        }
        anim.SetBool("openDoor", openDoor);

    }

}
