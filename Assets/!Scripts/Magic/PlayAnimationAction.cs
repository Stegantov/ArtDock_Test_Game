using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Actions/Play Animation")]
public class PlayAnimationAction : AbilityActionBase
{
    public string animationName;
    public float animationSpeed = 1f;

    public override void Execute(AbilityContext context)
    {
        Animator animator = context.Caster.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play(animationName);
            animator.speed = animationSpeed;
        }
    }
}