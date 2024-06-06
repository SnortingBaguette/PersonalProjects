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

    private bool isCastingBeamSpell;
    private bool isMoving;
    private bool isStoppableByCastingABeamSpell;


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
        Debug.Log(isCastingBeamSpell);
    }


    private void UpdatePlayerRotation()
    {
        lookDirection = lookAtTarget.position - transform.position;     //Get the direction from player to the mouse position
        lookDirection.y = 0;        //Reset the vertical aim
        rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void UpdatePlayerMovement()
    {
        movementTargetPos = movementTarget.transform.position;
        moveDirection = movementTargetPos - transform.position;
        moveDirection.y = 0;
        feetPos = feetObject.position;

        moveDirection = Vector3.Normalize(moveDirection);

        if (Vector3.Distance(feetPos, movementTargetPos) >= .081f && !isStoppableByCastingABeamSpell)
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isStoppableByCastingABeamSpell = false;
        }
    }

    private void CheckPlayerCastingState()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isStoppableByCastingABeamSpell = true;
            isCastingBeamSpell = true;
            characterSpeed = 2f;
            rotationSpeed = .7f;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isCastingBeamSpell = false;
            characterSpeed = 4.25f;
            rotationSpeed = 12f;
        }
    }
}
