using System.Collections.Generic;
using UnityEngine;

public class AbilityContext
{
    public GameObject Caster;
    public List<GameObject> Targets;
    public Vector3 CastPoint;

    public AbilityContext(GameObject caster, List<GameObject> targets, Vector3 castPoint)
    {
        Caster = caster;
        Targets = targets;
        CastPoint = castPoint;
    }
}


