using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public Sprite closedDoor, openedDoor;
    private SpriteRenderer sp;
    private bool isOpen = false;
    public UnityEvent CharacterGoIn = new UnityEvent();
    private void Awake()
    {
        sp=GetComponent<SpriteRenderer>();
        sp.sprite = closedDoor;
    }
    public void onToggleTripped(bool ToggleIsOn)
    {
        Debug.Log("hello");
        if(ToggleIsOn) sp.sprite = openedDoor;
        else sp.sprite = closedDoor;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(isOpen && other.tag == "Player") 
        {
            CharacterGoIn.Invoke();
        }
    }
}
