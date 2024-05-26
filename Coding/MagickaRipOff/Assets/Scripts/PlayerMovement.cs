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


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection.x = lookAtTarget.position.x - transform.position.x;
        lookDirection.z = lookAtTarget.position.z - transform.position.z;
        rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        moveDirection = Vector3.Normalize(lookDirection);
        //Vector3.Normalize(lookDirection);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            characterController.Move(moveDirection * characterSpeed * Time.deltaTime);
        }
    }



    private void FixedUpdate()
    {

    }
}
