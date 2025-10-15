using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // public GameObject MrBall;   // Reference to MrBall GameObject
    public GameObject player;

    private Vector3 offset;  // Distance offset camera to player

    void Start() // called before first frame
    {

        
        //offset = transform.position - MrBall.transform.position; // Calculate initial offset between cameraand player
        offset = transform.position - player.transform.position;
        
    }
    void LateUpdate()   // LateUpdate called once/frame after Update functions completed
    {
        transform.position = player.transform.position + offset;
        // transform.position = MrBall.transform.position + offset; //maintains offset
    }
}