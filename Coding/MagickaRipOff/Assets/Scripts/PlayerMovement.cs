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

    int amountOfActiveElements;

    bool isCoroutineStarted;

    public Vector3 elementParticleNewInstancePos = new Vector3(0,0,1);
    public GameObject elementParticlePrefab;

    private IEnumerator LimitBeamSpellTime()
    {

        switch (amountOfActiveElements)
        {
            case 1:
                yield return new WaitForSeconds(6f);
                EndBeamCasting();
                yield break;
            case 2:
                yield return new WaitForSeconds(7f);
                EndBeamCasting();
                yield break;
            case 3:
                yield return new WaitForSeconds(8f);
                EndBeamCasting();
                yield break;
        }
        
    }

    IEnumerator StopBeamTimer;

    //Trying to implement a State Machine
    public enum State
    {
        Walking,
        CastingBeam
    }
    private State currentState;
    //State Machine Implementation

    // Start is called before the first frame update
    void Start()
    {
        StopBeamTimer = LimitBeamSpellTime();
        characterController = GetComponent<CharacterController>();
        currentState = State.Walking;
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
                break;
            case State.CastingBeam:
                UpdatePlayerMovementCastingBeam();
                UpdatePlayerRotation();
                break;
        }

        switch (currentState)
        {

            case State.Walking:
                if (isCoroutineStarted)
                {
                    StopAllCoroutines();                                                    //Stop a coroutine that limits the spell time
                    isCoroutineStarted = false;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1) && amountOfActiveElements > 0)         //Condition to change the state
                {
                    currentState = State.CastingBeam;
                }
                break;

            case State.CastingBeam:
                if (!isCoroutineStarted)                                                    
                {
                    StartCoroutine(LimitBeamSpellTime());                                   //Start a coroutine that limits the spell time
                    isCoroutineStarted = true;
                }

                if (Input.GetKeyUp(KeyCode.Mouse1))                                         //Condition to change the state
                {
                    StopAllCoroutines();                                                    //Stop a coroutine that limits the spell time
                    EndBeamCasting();
                }
                break;
        }
        //State Machine Implementation
        //CheckPlayerCastingState();
        //UpdatePlayerRotation();
        //UpdatePlayerMovementCastingBeam();
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
        if (Input.GetKeyDown(KeyCode.S) && amountOfActiveElements < 3)                           //This check will make sure that the character will pause movement when casting a beam spell
        {
            AddCastingElements();
        }
    }

    private void AddCastingElements()
    {
            amountOfActiveElements++;
            switch (amountOfActiveElements)
            {
                case 1:
                    characterSpeed = 4;
                    break;
                case 2:
                    characterSpeed = 3.5f;
                    break;
                case 3:
                    characterSpeed = 3f;
                    break;
            }
    }

    private void UpdatePlayerMovementCastingBeam()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            isCastingBeamSpell = true;
            switch (amountOfActiveElements)
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

    private void EndBeamCasting()
    {
        currentState = State.Walking;
        characterSpeed = 4.25f;
        rotationSpeed = 12f;
        amountOfActiveElements = 0;
    }
}
