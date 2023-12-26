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
    [SerializeField] private GameObject AirButton;
    [SerializeField] private GameObject EarthButton;
    [SerializeField] private GameObject AirJumpButton;

    private void Awake()
    {
       // AirButton = GameObject.Find("Ability-air");
       // EarthButton = GameObject.Find("Ability-earth");

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

    private void Start()
    {
        AirCharacter.isAirActive = true;
        EarthCharacter.isAirActive = false;
        isAirActive = true;
        AirJumpButton.SetActive(false);
    }

    public void OnSwitchPlayer()
    {

        if (isAirActive)
        {
            isAirActive = false;
            AirButton.SetActive(true);
            EarthButton.SetActive(false);
            AirJumpButton.SetActive(true);
            Debug.Log("PlayerSwitcher: Air is NOT Active");
        }
        else
        {
            AirJumpButton.SetActive(false);
            isAirActive = true;
            AirButton.SetActive(false);
            EarthButton.SetActive(true);
            Debug.Log("PlayerSwitcher: Air is Active");
        }

        AirCharacter.isAirActive = isAirActive;
        EarthCharacter.isAirActive = !isAirActive;


    }

}
