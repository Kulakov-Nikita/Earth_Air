using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public static class StateMachine
{
    private static bool AirReady = false;
    private static bool EarthReady = false;

    private static bool EarthUsingAbility = false;

    public static UnityEvent LevelComplete = new UnityEvent();
    public static UnityEvent GameOver = new UnityEvent();

    public static void PlayerEnterDoor(GameObject player)
    {
        if (player.tag == "AirCharacter")AirReady = true;
        if (player.tag == "EarthCharacter") EarthReady = true;

        UpdateState();
    }
    public static void PlayerLeaveDoor(GameObject player)
    {
        if (player.tag == "AirCharacter") AirReady = false;
        if (player.tag == "EarthCharacter") EarthReady = false;

        UpdateState();
    }
    public static void PlayerEnterKillZone(GameObject player)
    {
        if (player.tag == "AirCharacter") GameOver.Invoke();
        else if (player.tag == "EarthCharacter" && EarthUsingAbility == false) GameOver.Invoke();
    }
    public static void EarthStartAbility()
    {
        EarthUsingAbility = true;
    }
    public static void EarthStopAbility()
    {
        EarthUsingAbility = false;
    }
    private static void UpdateState()
    {
        if(AirReady && EarthReady)LevelComplete.Invoke();
    }
}
