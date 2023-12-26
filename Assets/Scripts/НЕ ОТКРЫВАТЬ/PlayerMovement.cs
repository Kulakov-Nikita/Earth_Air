using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public AirCharScript AirCharacter;
    public EarthCharScript EarthCharacter;

    public int AbilityCost = 1;
    public UnityEvent OnAirUseAbility = new UnityEvent();
    public UnityEvent OnEarthUseAbility = new UnityEvent();

    [SerializeField] private GemCounter gems;
    [SerializeField] private LevelManager levelManager;

    Rigidbody2D AirBody;
    Rigidbody2D EarthBody;

    float AirDirection;
    float EarthDirection;

    public float PlayerSpeed = 50;
    public bool GameIsGoingOn = true;


    public void RotatePlayer(bool flipX)
    {
        if (GameIsGoingOn)
        {
            if (AirCharacter.isAirActive)
            {
                EarthCharacter.GetComponent<SpriteRenderer>().flipX = flipX;
            }
            else
            {
                AirCharacter.GetComponent<SpriteRenderer>().flipX = flipX;
            }
        }
    }

    private float ActivePlayerDirection = 0;
    private void Start()
    {
        AirBody = AirCharacter.getBody();
        EarthBody = EarthCharacter.getBody();
        Debug.Log("PlayerMovement: AirCharacter.isAirActive = " + AirCharacter.isAirActive);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameIsGoingOn)
        {
            AirBody.velocity = new Vector2(PlayerSpeed * AirDirection, AirBody.velocity.y);
            EarthBody.velocity = new Vector2(PlayerSpeed * EarthDirection, EarthBody.velocity.y);

            AirBody.transform.rotation = Quaternion.identity;
            EarthBody.transform.rotation = Quaternion.identity;
        }
    }
    public void UseAirAbility()
    {
        if (GameIsGoingOn)
        {
            if (gems.GemCount > 0 && levelManager.AirCanUseAbility())
            {
                gems.AddGems(-1 * AbilityCost);
                OnAirUseAbility.Invoke();
            }
        }
    }
    public void UseEarthAbility()
    {
        if (GameIsGoingOn)
        {
            if (gems.GemCount > 0)
            {
                gems.AddGems(-1 * AbilityCost);
                OnEarthUseAbility.Invoke();
            }
        }
    }

    public void ChangeDirection(int ButtonDirection)
    {
        if (GameIsGoingOn)
        {
            if (AirCharacter.isAirActive)
            {
                EarthDirection = ButtonDirection;
            }
            else
            {
                AirDirection = ButtonDirection;
            }
        }
    }




}
