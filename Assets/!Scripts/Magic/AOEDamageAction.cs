using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Actions/AOE Damage")]
public class AOEDamageAction : AbilityActionBase
{
    public float radius = 3f;
    public float distanceFromCaster = 2f;
    public float damageAmount = 10f;
    public LayerMask targetLayer;

    public override void Execute(AbilityContext context)
    {
        Vector3 origin = context.Caster.transform.position + context.Caster.transform.forward * distanceFromCaster;
        Collider[] hits = Physics.OverlapSphere(origin, radius, targetLayer);

        List<GameObject> affected = new List<GameObject>();
        foreach (var hit in hits)
        {
            if (hit.gameObject != context.Caster)
            {
                affected.Add(hit.gameObject);
                var damageable = hit.GetComponent<IDamageable>();
                if (damageable != null)
                    damageable.TakeDamage(damageAmount);
            }
        }

        context.Targets = affected;
    }
}