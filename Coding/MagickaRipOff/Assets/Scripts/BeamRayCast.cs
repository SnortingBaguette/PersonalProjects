using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BeamRayCast : MonoBehaviour
{

    private PlayerMovement castingSpell;
    public Vector3 raycastOffset = new Vector3(0, 0.5f, 0);
    public LineRenderer lineRenderer;
    private AddCastingElements elementsAmount;
    


    // Start is called before the first frame update
    void Start()
    {
        castingSpell = GetComponent<PlayerMovement>();
        elementsAmount = GetComponent<AddCastingElements>();
        lineRenderer.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        

        //Debug.Log(castingSpell.isCastingBeamSpell);
        if (castingSpell.isCastingBeamSpell)
        {
            RaycastBeamSpell(); 
        }
        else
        {
            lineRenderer.enabled = false;

        }

        //Debug.Log(transform.position);
    }

    void RaycastBeamSpell()
    {
        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit rayhit, 20f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 30f))
        {
            //Debug.Log("Hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
            lineRenderer.enabled = true;
            lineRenderer.endColor = Color.red;
            lineRenderer.startColor = Color.red;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            Debug.Log(hitInfo.collider.gameObject.name);
            Enemy enemy = hitInfo.collider.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                switch (elementsAmount.amountOfActiveElements)
                {
                    case 1:
                        enemy.TakeDamageArcane(10);
                        break;
                    case 2:
                        enemy.TakeDamageArcane(15);
                        break;
                    case 3:
                        enemy.TakeDamageArcane(20);
                        break;
                }
                
            }
            //hitInfo.collider.gameObject


        }
        else
        {
            //Debug.Log("Miss");
            Debug.DrawRay(transform.position, transform.forward * 30f, Color.green);
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.forward * 30f );
        }
        



    }
}
