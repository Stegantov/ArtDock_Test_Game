using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Actions/Delay")]
public class DelayAction : AbilityActionBase
{
    public float delayTime;

    public override void Execute(AbilityContext context)
    {
        context.Caster.GetComponent<MonoBehaviour>().StartCoroutine(DelayCoroutine(context));
    }

    private System.Collections.IEnumerator DelayCoroutine(AbilityContext context)
    {
        yield return new WaitForSeconds(delayTime);
    }
}