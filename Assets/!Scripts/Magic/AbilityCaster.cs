using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityCaster : MonoBehaviour
{
    public Ability abilityToUse;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Ability.performed += OnAbilityPerformed;
    }

    private void OnDisable()
    {
        inputActions.Player.Ability.performed -= OnAbilityPerformed;
        inputActions.Disable();
    }

    private void OnAbilityPerformed(InputAction.CallbackContext context)
    {
        if (abilityToUse == null) return;

        var contextData = new AbilityContext(
            caster: gameObject,
            targets: new System.Collections.Generic.List<GameObject>(),
            castPoint: transform.position + transform.forward * 2f
        );

        abilityToUse.Activate(contextData);
    }
}