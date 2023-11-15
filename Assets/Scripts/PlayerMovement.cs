using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerControls controls;
    [SerializeField] Rigidbody2D AirRB;
    [SerializeField] Rigidbody2D EarthRB;
    [SerializeField] Animator AirAnimator;
    [SerializeField] Animator EarthAnimator;
    [SerializeField] float direction = 0;
    [SerializeField] float speed = 400;
    bool isFacingRight = true;

    Animator activeAnimator;
    Rigidbody2D activeChar;

    private void Awake()
    {
        activeChar = AirRB;
        activeAnimator = AirAnimator;

        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetNextChar();
        }

        activeChar.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, activeChar.velocity.y);
        activeAnimator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    private void SetNextChar()
    {

        if (activeChar == AirRB)
        {
            activeChar = EarthRB;
            activeAnimator = EarthAnimator;
        }
        else
        {
            activeChar = AirRB;
            activeAnimator = AirAnimator;
        }
    }
}
