using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPillarScript : MonoBehaviour
{
    private float LifeTime = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rg = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.tag != "EarthCharacter")
        {
            Debug.Log("Enter");
            rg = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rg != null)
            {
                rg.gravityScale = -1.2f;
            }
        }     
    }

    private void Update()
    {
        if (LifeTime > 0) LifeTime -= Time.deltaTime;
        else Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        Rigidbody2D rg = collision.gameObject.GetComponent<Rigidbody2D>();
        rg.gravityScale = 1.0f;
    }
}
