using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSizeAdjustment : MonoBehaviour
{

    public GameObject playerObject;
    bool isCastingBeamSpell;
    bool isCastingBeamSpellObj;
    private Vector3 localScaleOfTheBeam = new Vector3(1 ,1 ,1);
    

    // Start is called before the first frame update
    void Start()
    {
        isCastingBeamSpellObj = playerObject.GetComponent<PlayerMovement>().isCastingBeamSpell;
    }

    // Update is called once per frame
    void Update()
    {
        isCastingBeamSpellObj = playerObject.GetComponent<PlayerMovement>().isCastingBeamSpell;
        Debug.Log(isCastingBeamSpellObj);
        if(isCastingBeamSpellObj)
        {
            localScaleOfTheBeam.z = 10;
            transform.localScale = localScaleOfTheBeam;
        }
        else
        {
            localScaleOfTheBeam.z = 1;
            transform.localScale = localScaleOfTheBeam;
        }

    }
}
