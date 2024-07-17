using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomizeElementParticleOffset : MonoBehaviour
{
    Vector3 particleOffset;
    private float offsetLimitVertical = .5f;
    private float offsetLimitHorizontalOuter = 1.25f;
    private float offsetLimitHorizontalInner = .75f;
    private ParticleSystem pS;
    private GameObject playerObject;
    private AddCastingElements latestElement;

    private void Start()
    {
        particleOffset.y = Random.Range(-.05f, .05f);
        particleOffset.z = Random.Range(-.05f, .05f);
        transform.Translate(Vector3.right * Random.Range(-.025f, 0.25f) * Time.deltaTime);
        transform.Translate(Vector3.up * Random.Range(-.05f, 0.5f) * Time.deltaTime);

        playerObject = GameObject.Find("Player");
        latestElement = playerObject.GetComponent<AddCastingElements>();
        pS = GetComponent<ParticleSystem>();
        var main = pS.main;
        switch (latestElement.latestElement)
        {
            case 'q':
                main.startColor = Color.blue;
                break;
            case 'w':
                main.startColor = Color.green;
                break;
            case 'e':
                main.startColor = Color.yellow;
                break;
            case 'r':
                main.startColor = Color.cyan;
                break;
            case 'a':
                main.startColor = Color.magenta;
                break;
            case 's':
                main.startColor = Color.red;
                break;
            case 'd':
                main.startColor = new Color(0.647f, 0.165f, 0.165f);
                break;
            case 'f':
                main.startColor = new Color(1f, 0.5f, 0.2f);
                break;


        }
        
        
        //main.startColor = Color.cyan;
    }

    private void Update()
    {
        if (transform.localPosition.y >= offsetLimitVertical)
        {
            particleOffset.y = Random.Range(-.05f, 0);
        }
        else if (transform.localPosition.y <= -offsetLimitVertical) 
        {
            particleOffset.y = Random.Range(0, .05f);
        }

        if (transform.localPosition.z >= offsetLimitHorizontalOuter)
        {
            particleOffset.z = Random.Range(0, .05f);
        }
        else if (transform.localPosition.z <= offsetLimitHorizontalInner)
        {
            particleOffset.z = Random.Range(-.05f, 0); 
        }

        transform.Translate(Vector3.right * particleOffset.z * Time.deltaTime);
        transform.Translate(Vector3.up * particleOffset.y * Time.deltaTime);
    }
}
