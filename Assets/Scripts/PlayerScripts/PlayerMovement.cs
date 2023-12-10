using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AirCharScript AirCharacter;
    public EarthCharScript EarthCharacter;

    Rigidbody2D AirBody;
    Rigidbody2D EarthBody;

    float AirDirection;
    float EarthDirection;

    float AirSpeed;
    float EarthSpeed;


    private float ActivePlayerDirection = 0;

    private void Awake()
    {
        //AirCharacter = GameObject.FindGameObjectWithTag("AirCharacter").GetComponent<AirCharScript>();
        //EarthCharacter = GameObject.FindGameObjectWithTag("EarthCharacter").GetComponent<EarthCharScript>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

         AirBody = AirCharacter.getBody();
         EarthBody = EarthCharacter.getBody();

         AirDirection = AirCharacter.GetDirection();
         EarthDirection = EarthCharacter.GetDirection();

         AirSpeed = AirCharacter.GetSpeed();
         EarthSpeed = EarthCharacter.GetSpeed();

        //var AirAnimator = AirCharacter.GetAnimator();
        //var EarthAnimator = EarthCharacter.GetAnimator();

        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        if (AirCharacter.isAirActive)
        {
            AirDirection = Input.GetAxisRaw("Horizontal");
            ActivePlayerDirection = AirDirection;
            AirBody.velocity = new Vector2(ActivePlayerDirection * AirSpeed * Time.fixedDeltaTime, AirBody.velocity.y);
        }
        else
        {
            EarthDirection = Input.GetAxisRaw("Horizontal");
            ActivePlayerDirection = EarthDirection;
            EarthBody.velocity = new Vector2(ActivePlayerDirection * EarthSpeed * Time.fixedDeltaTime, EarthBody.velocity.y);
        }

    }

    public void ChangeDirection(int ButtonDirection)
    {
        ActivePlayerDirection = ButtonDirection;

        
            AirDirection = Input.GetAxisRaw("Horizontal");
            AirBody.velocity = new Vector2(ActivePlayerDirection * AirSpeed * Time.fixedDeltaTime, AirBody.velocity.y);
        
       
        
            EarthDirection = Input.GetAxisRaw("Horizontal");
            EarthBody.velocity = new Vector2(ActivePlayerDirection * EarthSpeed * Time.fixedDeltaTime, EarthBody.velocity.y);
        
    }




}
