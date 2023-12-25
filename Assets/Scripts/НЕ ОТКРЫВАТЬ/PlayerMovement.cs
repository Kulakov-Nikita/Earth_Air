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

    float AirSpeed;
    float EarthSpeed;


    private float ActivePlayerDirection = 0;

    private void Awake()
    {
        //AirCharacter = GameObject.FindGameObjectWithTag("AirCharacter").GetComponent<AirCharScript>();
        //EarthCharacter = GameObject.FindGameObjectWithTag("EarthCharacter").GetComponent<EarthCharScript>();


    }
    private void Start()
    {
        Debug.Log("PlayerMovement: AirCharacter.isAirActive = " + AirCharacter.isAirActive);
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

        Debug.Log("PlayerMovement [FixedUpdate]: AirCharacter.isAirActive = " + AirCharacter.isAirActive);
        if (AirCharacter.isAirActive)
        {
            Debug.Log(1111);
            //AirDirection = Input.GetAxisRaw("Horizontal");
            ActivePlayerDirection = AirDirection;
            AirBody.velocity = new Vector2(ActivePlayerDirection * AirSpeed * Time.fixedDeltaTime, AirBody.velocity.y);
        }
        else
        {
            //EarthDirection = Input.GetAxisRaw("Horizontal");
            ActivePlayerDirection = EarthDirection;
            EarthBody.velocity = new Vector2(ActivePlayerDirection * EarthSpeed * Time.fixedDeltaTime, EarthBody.velocity.y);
        }

    }
    public void UseAirAbility()
    {
        if (gems.GemCount > 0 && levelManager.AirCanUseAbility())
        {
            gems.AddGems(-1 * AbilityCost);
            OnAirUseAbility.Invoke();
        }
    }
    public void UseEarthAbility()
    {
        if (gems.GemCount > 0)
        {
            gems.AddGems(-1 * AbilityCost);
            OnEarthUseAbility.Invoke();
        }
    }

    public void ChangeDirection(int ButtonDirection)
    {
        ActivePlayerDirection = ButtonDirection;

           // AirDirection = Input.GetAxisRaw("Horizontal");
            AirBody.velocity = new Vector2(ActivePlayerDirection * AirSpeed * Time.fixedDeltaTime, AirBody.velocity.y);
        
       
        
            //EarthDirection = Input.GetAxisRaw("Horizontal");
            EarthBody.velocity = new Vector2(ActivePlayerDirection * EarthSpeed * Time.fixedDeltaTime, EarthBody.velocity.y);
        
    }




}
