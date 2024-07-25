using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricitySpellCast : MonoBehaviour
{

    private PlayerMovement electricitySpellStatus;
    public GameObject electricitySpellAreaSmall;
    public GameObject electricitySpellAreaMedium;
    public GameObject electricitySpellAreaLarge;
    // Start is called before the first frame update
    void Start()
    {
        electricitySpellStatus = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (electricitySpellStatus.isCastingElectricitySpell)
        {
            electricitySpellAreaSmall.SetActive(true);
        }
        else
        {
            electricitySpellAreaSmall.SetActive(false);
        }
    }
}
