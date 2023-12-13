using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAbilityHolder : MonoBehaviour
{
    [SerializeField] private SteadyAbility ability;
    private float cooldownTime;
    private float activeTime;
    GameObject earthChar;
    EarthCharScript earthCharSc;
    public bool isAbilityActive {get; private set; }

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
        isAbilityActive = false;
        earthCharSc = GetComponent<EarthCharScript>();
        earthChar = gameObject;
    }
    public void OnAbilityActive()
    {
        if (earthCharSc.isAirActive)
        {
            isAbilityActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnActivate()
    {
        Debug.Log("OnActivateEarth");
        switch (state)
        {
            case AbilityState.ready:
                Debug.Log("Ready");
                if (earthCharSc.isAirActive)
                {
                    ability.Activate(earthChar);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                    isAbilityActive = false;
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
                    ability.Disactivate(earthChar);
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
                    activeTime = 2f;
                }
                break;
        }
    }
}
