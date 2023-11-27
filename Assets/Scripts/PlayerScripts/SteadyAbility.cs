using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SteadyAbility : Ability
{
    [SerializeField] private float activeTime = 2f;
    [SerializeField] private float cooldownTime = 5f;
    public override void Activate(GameObject parent)
    {
        EarthCharScript earthCharScript = parent.GetComponent<EarthCharScript>();
        while (activeTime > 0) 
        {   
            activeTime -= Time.deltaTime;
            earthCharScript.SetIsSteady(true);
            if (activeTime > 0 && earthCharScript.GetIsSteady() == true)
                Debug.Log("HE IS STEADYYYYY");
        }
        earthCharScript.SetIsSteady(false);
        Debug.Log("HE IS NOT STEADY");
    }

}
