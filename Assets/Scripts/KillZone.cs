using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillZone : MonoBehaviour
{
    public UnityEvent PlayerDead;
    private EarthCharScript earth;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        earth = GameObject.FindGameObjectWithTag("EarthCharacter").GetComponent<EarthCharScript>();
        if (collision.tag == "AirCharacter" || (collision.tag == "EarthCharacter" && !earth.GetIsSteady()))
        {
            PlayerDead.Invoke();
            Debug.Log("dead");
        }
    }
}
