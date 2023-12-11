using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent buttonPressed = new UnityEvent();
    public UnityEvent buttonReleased = new UnityEvent();
    private bool isPressed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPressed)
        {
            isPressed = true;
            transform.position += new Vector3(0, -0.1f, 0);
            buttonPressed.Invoke();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isPressed)
        {
            isPressed = false;
            transform.position += new Vector3(0, 0.1f, 0);
            buttonReleased.Invoke();
        }
    }
}
