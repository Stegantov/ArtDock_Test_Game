using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Actions/Play Sound")]
public class PlaySoundAction : AbilityActionBase
{
    public AudioClip soundClip;
    public float volume = 1f;

    public override void Execute(AbilityContext context)
    {
        AudioSource audioSource = context.Caster.GetComponent<AudioSource>();
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip, volume);
        }
    }
}