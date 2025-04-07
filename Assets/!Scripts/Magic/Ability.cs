using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Ability")]
public class Ability : ScriptableObject
{
    public AbilityActionBase[] actions;

    public void Activate(AbilityContext context)
    {
        foreach (var action in actions)
        {
            action.Execute(context);
        }
    }
}