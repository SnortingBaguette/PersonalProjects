using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float characterSpeed = 5f;
    Vector3 moveDirection;



    public Transform lookAtTarget;
    private Vector3 lookDirection;
    private Quaternion rotation;
    public float rotationSpeed = 12f;

    public GameObject moveAfterMouseLetGo;
    private Vector3 movementFinalTarget;
    bool shouldStop;
    private Vector3 directionToSavesPos;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        movementFinalTarget  = moveAfterMouseLetGo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection.x = lookAtTarget.position.x - transform.position.x;
        lookDirection.z = lookAtTarget.position.z - transform.position.z;
        rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        /*movementFinalTarget = moveAfterMouseLetGo.transform.position;
        directionToSavesPos.x = movementFinalTarget.x - transform.position.x;
        directionToSavesPos.z = movementFinalTarget.z - transform.position.x;
        moveDirection = Vector3.Normalize(directionToSavesPos); */

        moveDirection = Vector3.Normalize(lookDirection);


        //Vector3.Normalize(lookDirection);

        /*if (Vector3.Distance(movementFinalTarget, transform.position) <= 1)
        {
            Debug.Log("The character will stop now");
            shouldStop = true;

        } else
        {
            Debug.Log("No stopping");
            shouldStop = false;
        }   */

        if (Input.GetKey(KeyCode.Mouse0))
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);
        }

        //Debug.Log(movementFinalTarget);
        //Debug.Log(Vector3.Distance(movementFinalTarget, transform.position));
    }



    private void FixedUpdate()
    {

    }
}
