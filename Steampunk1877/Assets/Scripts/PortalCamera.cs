using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    float myAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDiffrenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        if (myAngle == 90 || myAngle == 270)
        {
            angularDiffrenceBetweenPortalRotations -= 90;
        }
        Quaternion portalRotationalDiffrence = Quaternion.AngleAxis(angularDiffrenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDiffrence * playerCamera.forward;

        if (myAngle == 90 || myAngle == 270)
        {
            newCameraDirection = new Vector3(newCameraDirection.z * -1, newCameraDirection.y, newCameraDirection.x);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        else
        {
            newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y, newCameraDirection.z * -1);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }

       
    }

    public void SetMyAngle(float angle)
        {
            myAngle = angle;
        }
}
