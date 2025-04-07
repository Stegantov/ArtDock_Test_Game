using UnityEngine;

public abstract class AbilityActionBase : ScriptableObject, IAbilityAction
{
    public abstract void Execute(AbilityContext context);
}

