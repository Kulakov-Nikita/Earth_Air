using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpForce = 5.0f;
    void Start()
    {
         rb = GetComponent<Rigidbody2D>(); 
    }

    public void Jump()
    {
        if (rb.velocity.y == 0)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

}
