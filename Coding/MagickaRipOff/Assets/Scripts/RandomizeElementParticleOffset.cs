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

    private void Start()
    {
        particleOffset.y = Random.Range(-.05f, .05f);
        particleOffset.z = Random.Range(-.05f, .05f);
        transform.Translate(Vector3.right * Random.Range(-.025f, 0.25f) * Time.deltaTime);
        transform.Translate(Vector3.up * Random.Range(-.05f, 0.5f) * Time.deltaTime);
        pS = GetComponent<ParticleSystem>();
        var main = pS.main;
        main.startColor = Color.cyan;
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
