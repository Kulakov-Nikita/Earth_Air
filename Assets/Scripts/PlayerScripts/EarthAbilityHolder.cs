using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability ability;
    private float cooldownTime;
    private float activeTime;
    GameObject earthChar;
    AirCharScript airChar;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    private AbilityState state = AbilityState.ready;
    [SerializeField] private KeyCode key = KeyCode.Space;
 
    void Start()
    {
        earthChar = GameObject.FindGameObjectWithTag("EarthCharacter");
        airChar = GameObject.FindGameObjectWithTag("AirCharacter").GetComponent<AirCharScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
            switch(state)
            {
                case AbilityState.ready:
                    if (Input.GetKeyDown(key) && !airChar.isAirActive)
                    {
                        ability.Activate(earthChar);
                        state = AbilityState.active;
                        activeTime = ability.activeTime;
                    Debug.Log(activeTime);
                    }
                    break;
                case AbilityState.active:
                    if(activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    } 
                    else
                    {
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                    }
                    break;
                case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
            }
            
    }
}
