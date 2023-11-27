using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name { get; private set; }
    public float cooldownTime { get; private set; }
    public float activeTime { get; private set; }

    public virtual void Activate(GameObject parent)
    {

    }
}
