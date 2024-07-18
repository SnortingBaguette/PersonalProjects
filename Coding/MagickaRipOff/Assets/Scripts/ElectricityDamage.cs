using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityDamage : MonoBehaviour
{

    private AddCastingElements currentElementsStatus;
    

    // Start is called before the first frame update
    void Start()
    {
        currentElementsStatus = GameObject.Find("Player").GetComponent<AddCastingElements>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            switch (currentElementsStatus.elementQue)
            {
                case "a":
                    Debug.Log("Hit an enemy with lighting");
                    enemy.TakeDamageElectricity(10);
                    break;

                case "aa":
                    Debug.Log("Hit an enemy with lighting");
                    enemy.TakeDamageElectricity(20);
                    break;

                case "aaa":
                    Debug.Log("Hit an enemy with lighting");
                    enemy.TakeDamageElectricity(30);
                    break;
        }
            
        }
    }
    /*{
        
    }*/
}
