using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateActiveElement : MonoBehaviour
{
    private float rotateBy = 2f;
    
    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotateBy, 0);
    }
}
