using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float characterSpeed = 5f;
    Vector3 moveDirection;



    public Transform lookAtTarget;      //Setting a target to look at in the inspector
    private Vector3 lookDirection;      //A variable to store the position of the target
    private Quaternion rotation;
    public float rotationSpeed = 12f;

    public Transform feetObject;
    private Vector3 feetPos;

    public GameObject movementTarget;
    private Vector3 movementTargetPos;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        lookDirection = lookAtTarget.position - transform.position;     //Get the direction from player to the mouse position
        lookDirection.y = 0;        //Reset the vertical aim
        rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //moveDirection = Vector3.Lerp(transform.position, lookDirection, 0.1f);
        //moveDirection = Vector3.Normalize(lookDirection);
        movementTargetPos = movementTarget.transform.position;
        moveDirection = movementTargetPos - transform.position;
        moveDirection.y = 0;

        feetPos = feetObject.position;

        
        moveDirection = Vector3.Normalize(moveDirection);
        //moveDirection = Vector3.Lerp(currentPlayerPosition, movementTarget.transform.position, 0.5f * Time.deltaTime);
        if (Vector3.Distance(feetPos, movementTargetPos) >= .081f)
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);
        } 

        Debug.Log(Vector3.Distance(feetPos, movementTargetPos));

        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);
        }*/
    }



    private void FixedUpdate()
    {

    }
}
