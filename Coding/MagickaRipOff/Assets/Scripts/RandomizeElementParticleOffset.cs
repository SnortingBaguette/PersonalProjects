using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeElementParticleOffset : MonoBehaviour
{

    private float randomZoffset;
    private IEnumerator ChangeParticleOffset()
    {
        yield return new WaitForSeconds(3);
        randomZoffset = Random.Range(0.5f, 1.21f);

        StartCoroutine(ChangeParticleOffset());
        yield break;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeParticleOffset());
        randomZoffset = Random.Range(0.7f, 1.21f);
    }

    void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.position, new Vector3(0, 0, randomZoffset), 2f);
        Debug.Log(transform.position);
    }
}
