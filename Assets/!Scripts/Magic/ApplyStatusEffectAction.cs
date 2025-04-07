using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Actions/Apply Status Effect")]
public class ApplyStatusEffectAction : AbilityActionBase
{
    public StatusEffect effect;

    public override void Execute(AbilityContext context)
    {
        foreach (var target in context.Targets)
        {
            var effectable = target.GetComponent<IEffectable>();
            if (effectable != null)
            {
                effectable.ApplyEffect(effect);
            }
        }
    }
}