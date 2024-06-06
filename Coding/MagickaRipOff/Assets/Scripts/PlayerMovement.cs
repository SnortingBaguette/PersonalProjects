using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float characterSpeed = 4.25f;
    Vector3 moveDirection;



    public Transform lookAtTarget;      //Setting a target to look at in the inspector
    private Vector3 lookDirection;      //A variable to store the position of the target
    private Quaternion rotation;
    public float rotationSpeed = 12f;

    public Transform feetObject;        //Attach an Empty object that will represent player's feet
    private Vector3 feetPos;

    public Transform movementTarget;   //Reference the position to where the player needs to move
    private Vector3 movementTargetPos;

    public bool isCastingBeamSpell;
    private bool isStoppableByCastingABeamSpell;
    private bool isActivelyMoving;

    int amountOfActiveElements;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerCastingState();
        UpdatePlayerRotation();
        UpdatePlayerMovement();
    }


    private void UpdatePlayerRotation()
    {
        lookDirection = lookAtTarget.position - transform.position;     //Get the direction from player to the mouse position
        lookDirection.y = 0;        //Reset the vertical aim
        rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);     //Interpolate between the starting player rotation and mouse cursor direction
    }

    private void UpdatePlayerMovement()
    {
        
        movementTargetPos = movementTarget.transform.position;          //Create a variable to store the target's position
        moveDirection = movementTargetPos - transform.position;         //Get the direction from the player to the target
        moveDirection.y = 0;
        feetPos = feetObject.position;                                  //Create a variable to store player feet position

        moveDirection = Vector3.Normalize(moveDirection);               //Normalize the vector from player to the target

        if (Vector3.Distance(feetPos, movementTargetPos) >= .081f)       //Distance check to avoid the player jittering over the target
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);                      //Character moving when not in close range of the target
            isActivelyMoving = true;
        }
        else
        {
            isActivelyMoving = false;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))                           //This check will make sure that the character will pause movement when casting a beam spell
        {
            isStoppableByCastingABeamSpell = false;
        }

        if (Input.GetKeyDown(KeyCode.S) && amountOfActiveElements < 5)                           //This check will make sure that the character will pause movement when casting a beam spell
        {
            amountOfActiveElements++;
            switch (amountOfActiveElements)
            {
                case 0:
                    characterSpeed = 4.25f;
                    break;
                case 1:
                    characterSpeed = 4;
                    break;
                case 2:
                    characterSpeed = 3.75f;
                    break;
                case 3:
                    characterSpeed = 3.5f;
                    break;
                case 4:
                    characterSpeed = 3.25f;
                    break;
                case 5:
                    characterSpeed = 3f;
                    break;
            }
        }

 

        
    }

    private void CheckPlayerCastingState()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            switch (amountOfActiveElements)
            {
                case 0:
                    characterSpeed = 4.25f;
                    break;
                case 1:
                    characterSpeed = 4;
                    rotationSpeed = 1f;
                    isCastingBeamSpell = true;
                    break;
                case 2:
                    characterSpeed = 3.5f;
                    rotationSpeed = 1f;
                    isCastingBeamSpell = true;
                    break;
                case 3:
                    characterSpeed = 3f;
                    rotationSpeed = 1f;
                    isCastingBeamSpell = true;
                    break;
                case 4:
                    characterSpeed = 2.5f;
                    rotationSpeed = 1f;
                    isCastingBeamSpell = true;
                    break;
                case 5:
                    characterSpeed = 2f;
                    rotationSpeed = 1f;
                    isCastingBeamSpell = true;
                    break;
            }
        }




        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isCastingBeamSpell = false;
            characterSpeed = 4.25f;
            rotationSpeed = 12f;
            amountOfActiveElements = 0;
        }
        
    }
}
