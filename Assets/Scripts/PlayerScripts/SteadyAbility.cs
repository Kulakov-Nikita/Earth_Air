using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SteadyAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        
        EarthCharScript earthCharScript = parent.GetComponent<EarthCharScript>();
        earthCharScript.SetIsSteady(true);
        Debug.Log(earthCharScript.GetIsSteady());
    }

}
