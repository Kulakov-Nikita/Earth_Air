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
        if (ToggleIsOn)
        {
            sp.sprite = openedDoor;
            isOpen = true;
        }
        else
        {
            sp.sprite = closedDoor;
            isOpen = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (isOpen && other.tag == "Player") 
        {
            
            CharacterGoIn.Invoke();
        }
    }
}
