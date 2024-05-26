using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedMousePos : MonoBehaviour
{

    private Transform savedMousePos;
    public GameObject cursorReferencedPosition;

    // Start is called before the first frame update
    void Start()
    {
        savedMousePos = cursorReferencedPosition.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.position = savedMousePos.position;
        }
    }
}