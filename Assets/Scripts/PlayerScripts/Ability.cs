using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent)
    {

    }
}
