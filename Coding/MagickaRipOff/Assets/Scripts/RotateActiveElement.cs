using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateActiveElement : MonoBehaviour
{
    private float rotateBy = 1.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, Random.Range(0, 359), 0);
        rotateBy = Random.Range(40f, 50f);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Destroy(gameObject);
        }
        transform.Rotate(0, rotateBy * Time.deltaTime, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
