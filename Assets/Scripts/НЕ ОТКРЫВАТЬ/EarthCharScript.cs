using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCharScript : MonoBehaviour
{
    private PlayerControls controls;
    private float direction = 0;
    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 400;
    bool isFacingRight = true;
    public bool isSteady = false;
    public bool isAirActive = true;

    private void Awake()
    {
        controls = new PlayerControls();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        controls.Land.Move.performed += ctx => direction = ctx.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();


        if (!isSteady && body.velocity.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.up = Vector3.up;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    public void ControlsEnable() { controls.Enable(); }
    public void ControlsDisable() { controls.Disable(); }
    public float GetSpeed() { return speed; }
    public Rigidbody2D getBody() { return body; }
    public float GetDirection() { return direction; }
    public void SetDirection(float dir) { direction = dir; }
    public Animator GetAnimator() { return animator; }
    public bool GetIsSteady() { return isSteady; }
    public void SetIsSteady(bool isSteady) { this.isSteady = isSteady; }
}
