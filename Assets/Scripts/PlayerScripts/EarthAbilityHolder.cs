using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability ability;
    [SerializeField] private float cooldownTime;
    [SerializeField] private float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    private AbilityState state = AbilityState.ready;
    [SerializeField] private KeyCode key = KeyCode.A; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            switch(state)
            {
                case AbilityState.ready:
                    if (Input.GetKeyDown(key))
                    {
                        ability.Activate(gameObject);
                        state = AbilityState.active;
                        activeTime = ability.activeTime;
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
