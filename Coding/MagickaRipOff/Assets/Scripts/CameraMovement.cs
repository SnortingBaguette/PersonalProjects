using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerObject;     //Reference the player object
    public float copiedPositionX;   //Create a variable to store the player's X position
    public float copiedPositionZ;   //Create a variable to store the player's Z position
    public Vector3 positionForTheCamera;    //Create a Vector that will store the new camera position
    public Vector3 cursorCoordinates;   //A vector to store the mouse coordinates on a 1080p screen
    int screenHeight;
    int screenHeightHalf;
    int screenWidth;
    int screenWidthHalf;


    // Start is called before the first frame update
    void Start()
    {

        screenHeight = Screen.height / 2;

        screenWidth = Screen.width / 2;

    }

    // Update is called once per frame
    void Update()
    {
        cursorCoordinates.x = (Input.mousePosition.x - screenWidth) / screenWidth;  //Clamp the cursor coordinates to 1
        cursorCoordinates.y = (Input.mousePosition.y - screenHeight) / screenHeight;  //Clamp the cursor coordinates to 1
        copiedPositionX = playerObject.transform.position.x;    //Copy the position of the player in order to reference it
        copiedPositionZ = playerObject.transform.position.z;    //Copy the position of the player in order to reference it
        positionForTheCamera.Set(copiedPositionX + cursorCoordinates.x, 9.45f, copiedPositionZ - 6.25f + cursorCoordinates.y);  //Math for making the camera follow the player only on x and z axis
        transform.position = positionForTheCamera;  //Setting the math result as the camera position
        Debug.Log(cursorCoordinates.y);
    }
}
