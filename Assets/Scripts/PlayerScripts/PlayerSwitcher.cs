using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private AirCharScript AirCharacter;
    [SerializeField] private EarthCharScript EarthCharacter;
    [SerializeField] private Button AirAbility;
    private bool isAirActive = true; 

    public void OnSwitchPlayer()
    {
        if (isAirActive) isAirActive = false;
        else isAirActive = true;

        AirCharacter.isAirActive = isAirActive;
        EarthCharacter.isAirActive = !isAirActive;
    }

}
