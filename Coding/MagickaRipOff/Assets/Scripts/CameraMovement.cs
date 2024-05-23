using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerObject;     //Reference the player object
    public float copiedPositionX;   //Create a variable to store the player's X position
    public float copiedPositionZ;   //Create a variable to store the player's Z position
    public Vector3 positionForTheCamera;    //Create a Vector that will store the new camera position

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        copiedPositionX = playerObject.transform.position.x;
        copiedPositionZ = playerObject.transform.position.z;
        positionForTheCamera.Set(copiedPositionX, 9.45f, copiedPositionZ - 6.25f);
        transform.position = positionForTheCamera;
    }
}
