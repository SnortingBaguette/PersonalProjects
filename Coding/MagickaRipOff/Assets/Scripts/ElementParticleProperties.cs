using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementParticleProperties : MonoBehaviour
{
    private Transform playerPos;
    public GameObject playerObject;


   

    // Start is called before the first frame update
    void Start()
    {

        playerObject = GameObject.Find("Player");
        playerPos = playerObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position;

    }
}
