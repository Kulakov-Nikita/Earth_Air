using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu]
public class WindPillarAbility : Ability
{
    WindPillarSpawner spawner;
    private void OnEnable()
    {
        spawner = GameObject.FindGameObjectWithTag("AirCharacter").GetComponent<WindPillarSpawner>();
    }

    public override void Activate(GameObject parent)
    {
        spawner.Spawn();
    }
}

