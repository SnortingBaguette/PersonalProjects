using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerSphere;
    private Rigidbody ballRB;
    private Vector3 directionOfPlayer;
    private float pushStrength = 5f;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        directionOfPlayer = playerSphere.transform.position - transform.position;
        ballRB.AddForce(directionOfPlayer * pushStrength);
    }
}
