using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Transform Camera;
    public float CameraOffsetY = -11;
    public bool CameraRightLock = true;

    Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Player.transform.position;
        if (CameraRightLock )
        {
            if (playerPos.x > Camera.transform.position.x)
            {
                Camera.transform.position = new Vector3(playerPos.x, CameraOffsetY, playerPos.z - 10);
            }
        }
        else
        {
            Camera.transform.position = new Vector3(playerPos.x, CameraOffsetY, playerPos.z - 10);
        }



    }
}
