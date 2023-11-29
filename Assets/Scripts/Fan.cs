using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fan : MonoBehaviour
{
    public bool isPlayerInside { get; private set; }
    private void Start()
    {
        isPlayerInside = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AirCharacter")
        {
            isPlayerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AirCharacter")
        {
            isPlayerInside = false;
        }
    }
}
