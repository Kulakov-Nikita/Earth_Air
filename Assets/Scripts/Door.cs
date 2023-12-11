using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public Sprite closedDoor, openedDoor;
    private SpriteRenderer sp;
    private bool isOpen = false;
    public bool doorForAir = true;
    public UnityEvent CharacterGoIn = new UnityEvent();
    public UnityEvent CharacterGoOut = new UnityEvent();
    private void Awake()
    {
        sp=GetComponent<SpriteRenderer>();
        sp.sprite = closedDoor;
    }
    private void Start()
    {
        if (doorForAir) sp.color = Color.cyan;
        else sp.color = Color.magenta;
    }
    public void onTogglePressed()
    {
        sp.sprite = openedDoor;
        isOpen = true;
    }
    public void onToggleReleased()
    {
        sp.sprite = closedDoor;
        isOpen = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (isOpen && (other.tag == "AirCharacter" && doorForAir || other.tag == "EarthCharacter" && !doorForAir)) 
        {
            
            CharacterGoIn.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isOpen && (other.tag == "AirCharacter" && doorForAir || other.tag == "EarthCharacter" && !doorForAir))
        {

            CharacterGoOut.Invoke();
        }
    }
}
