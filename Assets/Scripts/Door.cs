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
    public Animator animator;


    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = closedDoor;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (doorForAir) sp.color = Color.cyan;
        else sp.color = Color.magenta;
        sp.sortingOrder = 0;
    }

    public void onTogglePressed()
    {
        sp.sprite = openedDoor;
        isOpen = true;
        animator.SetBool("OPEN", true);
    }

    public void onToggleReleased()
    {
        sp.sprite = closedDoor;
        isOpen = false;
        animator.SetBool("OPEN", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpen && ((other.tag == "AirCharacter" && doorForAir) || (other.tag == "EarthCharacter" && !doorForAir)))
        {
            CharacterGoIn.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpen && ((other.tag == "AirCharacter" && doorForAir) || (other.tag == "EarthCharacter" && !doorForAir)))
        {
            CharacterGoOut.Invoke();
        }
    }
}
