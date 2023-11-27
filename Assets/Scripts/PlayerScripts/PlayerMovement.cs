using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AirCharScript AirCharacter;
    public EarthCharScript EarthCharacter;


    private void Awake()
    {
        //AirCharacter = GameObject.FindGameObjectWithTag("AirCharacter").GetComponent<AirCharScript>();
        //EarthCharacter = GameObject.FindGameObjectWithTag("EarthCharacter").GetComponent<EarthCharScript>();

        if (AirCharacter != null)
            Debug.Log("AAAAA");

        if (EarthCharacter != null)
            Debug.Log("A2A2A2A2A");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var AirBody = AirCharacter.getBody();
        var EarthBody = EarthCharacter.getBody();
        var AirDirection = AirCharacter.GetDirection();
        var EarthDirection = EarthCharacter.GetDirection();

        var AirSpeed = AirCharacter.GetSpeed();
        var EarthSpeed = EarthCharacter.GetSpeed();
        var AirAnimator = AirCharacter.GetAnimator();
        var EarthAnimator = EarthCharacter.GetAnimator();

        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        if(AirCharacter.isAirActive) AirDirection = Input.GetAxisRaw("Horizontal");
        else EarthDirection = Input.GetAxisRaw("Horizontal");
        AirBody.velocity = new Vector2(AirDirection * AirSpeed * Time.fixedDeltaTime, AirBody.velocity.y);
        AirAnimator.SetFloat("speed", Mathf.Abs(AirDirection));

        //сделать то же с землей
        EarthBody.velocity = new Vector2(EarthDirection * EarthSpeed * Time.fixedDeltaTime, EarthBody.velocity.y);
        EarthAnimator.SetFloat("speed", Mathf.Abs(EarthDirection));
        //на пробел в свитчере отключать управление героям

        //EarthCharacter.
    }




}
