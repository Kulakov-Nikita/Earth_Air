using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability ability;
    private float cooldownTime;
    private float activeTime;
    GameObject airChar;
    AirCharScript airCharScript;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    private AbilityState state = AbilityState.ready;
    [SerializeField] private KeyCode key = KeyCode.F;

    void Start()
    {
        airChar = GameObject.FindGameObjectWithTag("AirCharacter");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnActivate()
    {
        Debug.Log("OnActivateAir");
        switch (state)
        {
            case AbilityState.ready:
                Debug.Log("Ready");
                if (!airCharScript.isAirActive)
                {
                    ability.Activate(airChar);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                    Debug.Log(activeTime);
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
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
