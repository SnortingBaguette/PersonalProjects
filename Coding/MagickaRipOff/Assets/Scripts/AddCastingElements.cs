using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCastingElements : MonoBehaviour
{

    public int amountOfActiveElements;
    public GameObject elementPrefab;
    private PlayerMovement playerMovementSpeed;
    private bool hasArcane = false;
    public int arcanePower = 0;
    private bool hasHeal = false;
    public int healPower = 0;
    private bool hasFire = false;
    public int firePower = 0;
    private bool hasElectricity = false;
    public int electricityPower = 0;
    private bool hasRock = false;
    public int rockPower = 0;
    private bool hasWater = false;
    public int waterPower = 0;
    private bool hasShield = false;
    private bool hasFrost = false;
    public int frostPower = 0;
    public char latestElement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementSpeed = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && amountOfActiveElements < 3 && !hasElectricity)
        {
            hasWater = true;
            waterPower++;
            latestElement = 'q';
            AddCastingElement();
        }

        if (Input.GetKeyDown(KeyCode.W) && amountOfActiveElements < 3 && !hasArcane)
        {
            hasHeal = true;
            healPower++;
            latestElement = 'w';
            AddCastingElement();
        }

        if (Input.GetKeyDown(KeyCode.E) && amountOfActiveElements < 3 && !hasShield)
        {
            hasShield = true;
            latestElement = 'e';
            AddCastingElement();
        }

        if (Input.GetKeyDown(KeyCode.R) && amountOfActiveElements < 3 && !hasFire)
        {
            hasFrost = true;
            frostPower++;
            latestElement = 'r';
            AddCastingElement();
        }

        if (Input.GetKeyDown(KeyCode.A) && amountOfActiveElements < 3 && !hasWater && !hasRock)
        {
            hasElectricity = true;
            electricityPower++;
            latestElement = 'a';
            AddCastingElement();
        }

        if (Input.GetKeyDown(KeyCode.S) && amountOfActiveElements < 3 && !hasHeal)
        {
            hasArcane = true;
            arcanePower++;
            latestElement = 's';
            AddCastingElement();
        }

        if (Input.GetKeyDown(KeyCode.D) && amountOfActiveElements < 3 && !hasElectricity)
        {
            hasRock = true;
            rockPower++;
            latestElement = 'd';
            AddCastingElement();
        }

        if (Input.GetKeyDown(KeyCode.F) && amountOfActiveElements < 3 && !hasFrost)
        {
            hasFire = true;
            firePower++;
            latestElement = 'f';
            AddCastingElement();
        }
    }



    private void AddCastingElement()
    {
        amountOfActiveElements++;
        switch (amountOfActiveElements)
        {
            case 1:
                playerMovementSpeed.characterSpeed = 4;
                Instantiate(elementPrefab);
                break;
            case 2:
                playerMovementSpeed.characterSpeed = 3.5f;
                Instantiate(elementPrefab);
                break;
            case 3:
                playerMovementSpeed.characterSpeed = 3f;
                Instantiate(elementPrefab);
                break;
        }
    }

    public void ResetTheElementFlags()
    {
        hasArcane = false;
        hasHeal = false;
        hasFire = false;
        hasElectricity = false;
        hasRock = false;
        hasWater = false;
        hasShield = false;
        hasFrost = false;
        arcanePower = 0;
        healPower = 0;
        firePower = 0;
        electricityPower = 0;
        rockPower = 0;
        waterPower = 0;
        frostPower = 0;
    }
}
