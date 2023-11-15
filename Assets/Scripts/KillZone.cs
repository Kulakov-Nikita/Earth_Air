using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillZone : MonoBehaviour
{
    public UnityEvent PlayerDead;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") PlayerDead.Invoke();
    }
}
