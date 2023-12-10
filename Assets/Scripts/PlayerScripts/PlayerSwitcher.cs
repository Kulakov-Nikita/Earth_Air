using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private AirCharScript AirCharacter;
    [SerializeField] private EarthCharScript EarthCharacter;
    private bool isAirActive = true;
    GameObject AirButton; 
    GameObject EarthButton;

    private void Awake()
    {
        AirButton = GameObject.Find("Ability-air");
        EarthButton = GameObject.Find("Ability-earth");

        if (AirButton != null)
        {
            Debug.Log("Button reference is  set");
        }

        if (EarthButton != null)
        {
            Debug.Log("Button reference is  set");
        }
        Debug.Log(isAirActive);
    }


    public void OnSwitchPlayer()
    {
        Debug.Log(isAirActive);
        if (isAirActive)
        {
            isAirActive = false;
            Debug.Log(isAirActive);
        }
        else
        {
            isAirActive = true;
            Debug.Log(isAirActive);
        }

        AirCharacter.isAirActive = isAirActive;
        EarthCharacter.isAirActive = !isAirActive;

        Debug.Log(isAirActive);

        AirButton.SetActive(!isAirActive);
        EarthButton.SetActive(isAirActive);
    }

}
