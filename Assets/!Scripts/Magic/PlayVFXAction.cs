using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Actions/Play VFX")]
public class PlayVFXAction : AbilityActionBase
{
    public GameObject vfxPrefab;
    public bool attachToTarget;

    public override void Execute(AbilityContext context)
    {
        if (vfxPrefab != null)
        {
            GameObject vfx = Instantiate(vfxPrefab);
            if (attachToTarget && context.Targets.Count > 0)
            {
                vfx.transform.position = context.Targets[0].transform.position;
            }
            else
            {
                vfx.transform.position = context.CastPoint;
            }
        }
    }
}