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

    public Transform movementTarget;   //Reference the position to where the player needs to move
    private Vector3 movementTargetPos;

    public bool isCastingBeamSpell;
    public bool isCastingElectricitySpell;

    bool isCoroutineStarted;

    private AddCastingElements amountOfActiveElements;



    private IEnumerator LimitBeamSpellTime()
    {

        switch (amountOfActiveElements.amountOfActiveElements)
        {
            case 1:
                yield return new WaitForSeconds(6f);
                EndSpellCasting();
                yield break;
            case 2:
                yield return new WaitForSeconds(7f);
                EndSpellCasting();
                yield break;
            case 3:
                yield return new WaitForSeconds(8f);
                EndSpellCasting();
                yield break;
        }
        
    }



    public enum State
    {
        Walking,
        CastingBeam,
        CastingRockProjectile,
        CastingElectricity
    }
    private State currentState;
    //State Machine Implementation

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentState = State.Walking;
        amountOfActiveElements = GetComponent<AddCastingElements>();
        Debug.Log(amountOfActiveElements.amountOfActiveElements);
    }

    // Update is called once per frame
    void Update()
    {
        
        //State Machine Implementation
        switch (currentState)                                   //Call necessary functions depending on what state is in
        {
            case State.Walking:
                UpdatePlayerMovementWalking();
                UpdatePlayerRotation();
                if (isCoroutineStarted)
                {
                    StopAllCoroutines();                                                    //Stop a coroutine that limits the spell time
                    isCoroutineStarted = false;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1) && amountOfActiveElements.amountOfActiveElements > 0)         //Condition to change the state
                {
                    switch (amountOfActiveElements.elementQue)
                    {
                        case "s":
                            currentState = State.CastingBeam;
                            break;

                        case "ss":
                            currentState = State.CastingBeam;
                            break;

                        case "sss":
                            currentState = State.CastingBeam;
                            break;

                        case "a":
                            currentState = State.CastingElectricity;
                            break;

                        case "aa":
                            currentState = State.CastingElectricity;
                            break;

                        case "aaa":
                            currentState = State.CastingElectricity;
                            break;
                    }
                    
                }
                break;

            case State.CastingBeam:
                UpdatePlayerMovementCastingBeam();
                UpdatePlayerRotation();
                if (!isCoroutineStarted)
                {
                    StartCoroutine(LimitBeamSpellTime());                                   //Start a coroutine that limits the spell time
                    isCoroutineStarted = true;
                }

                if (Input.GetKeyUp(KeyCode.Mouse1))                                         //Condition to change the state
                {
                    StopAllCoroutines();                                                    //Stop a coroutine that limits the spell time
                    EndSpellCasting();
                }
                break;

            case State.CastingElectricity:
                //electricityCollisionArea.SetActive(true);
                UpdatePlayerMovementCastingElectricity();
                UpdatePlayerRotation();
                if (!isCoroutineStarted)
                {
                    StartCoroutine(LimitBeamSpellTime());                                   //Start a coroutine that limits the spell time
                    isCoroutineStarted = true;
                }
                if (Input.GetKeyUp(KeyCode.Mouse1))                                         //Condition to change the state
                {
                    StopAllCoroutines();                                                    //Stop a coroutine that limits the spell time
                    EndSpellCasting();
                    isCastingElectricitySpell = false;
                    //electricityCollisionArea.SetActive(false);
                }
                break;
        }


    }


    private void UpdatePlayerRotation()
    {
        lookDirection = lookAtTarget.position - transform.position;     //Get the direction from player to the mouse position
        lookDirection.y = 0;        //Reset the vertical aim
        rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);     //Interpolate between the starting player rotation and mouse cursor direction
    }





    private void UpdatePlayerMovementWalking()
    {
        isCastingBeamSpell = false;
        movementTargetPos = movementTarget.transform.position;          //Create a variable to store the target's position
        moveDirection = movementTargetPos - transform.position;         //Get the direction from the player to the target
        moveDirection.y = 0;

        moveDirection = Vector3.Normalize(moveDirection);               //Normalize the vector from player to the target

        if (Vector3.Distance(feetObject.position, movementTargetPos) >= .081f)       //Distance check to avoid the player jittering over the target
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);                      //Character moving when not in close range of the target
        }
    }

    private void UpdatePlayerMovementCastingBeam()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            isCastingBeamSpell = true;
            switch (amountOfActiveElements.amountOfActiveElements)
            {
                case 1:
                    characterSpeed = 3.5f;
                    rotationSpeed = .7f;
                    break;
                case 2:
                    characterSpeed = 3f;
                    rotationSpeed = .7f;
                    break;
                case 3:
                    characterSpeed = 2.75f;
                    rotationSpeed = .7f;
                    break;
                case 4:
                    characterSpeed = 2.3f;
                    rotationSpeed = .7f;
                    break;
                case 5:
                    characterSpeed = 2f;
                    rotationSpeed = .7f;
                    break;
            }
        }



        movementTargetPos = movementTarget.transform.position;          //Create a variable to store the target's position
        moveDirection = movementTargetPos - transform.position;         //Get the direction from the player to the target
        moveDirection.y = 0;

        moveDirection = Vector3.Normalize(moveDirection);               //Normalize the vector from player to the target

        if (Vector3.Distance(feetObject.position, movementTargetPos) >= .081f)       //Distance check to avoid the player jittering over the target
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);                      //Character moving when not in close range of the target
        }
    }

    private void UpdatePlayerMovementCastingElectricity()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            isCastingElectricitySpell = true;
            switch (amountOfActiveElements.amountOfActiveElements)
            {
                case 1:
                    characterSpeed = 3.75f;
                    rotationSpeed = 8f;
                    break;
                case 2:
                    characterSpeed = 3.5f;
                    rotationSpeed = 8f;
                    break;
                case 3:
                    characterSpeed = 3f;
                    rotationSpeed = 8f;
                    break;
                case 4:
                    characterSpeed = 2.3f;
                    rotationSpeed = .7f;
                    break;
                case 5:
                    characterSpeed = 2f;
                    rotationSpeed = .7f;
                    break;
            }
        }



        movementTargetPos = movementTarget.transform.position;          //Create a variable to store the target's position
        moveDirection = movementTargetPos - transform.position;         //Get the direction from the player to the target
        moveDirection.y = 0;

        moveDirection = Vector3.Normalize(moveDirection);               //Normalize the vector from player to the target

        if (Vector3.Distance(feetObject.position, movementTargetPos) >= .081f)       //Distance check to avoid the player jittering over the target
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);                      //Character moving when not in close range of the target
        }
    }

    private void EndSpellCasting()
    {
        currentState = State.Walking;
        characterSpeed = 4.25f;
        rotationSpeed = 12f;
        amountOfActiveElements.amountOfActiveElements = 0;
        amountOfActiveElements.ResetTheElementFlags();
        isCastingElectricitySpell = false;
    }
}
