using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public static class InputHandler
{
    public static AttackInput StartedAttackInput(InputAction.CallbackContext input)
    {
        if (input.interaction is SlowTapInteraction)
        {
            return AttackInput.Hold;
        }
        
        if (input.interaction is TapInteraction)
        {
            return AttackInput.Empty;
        }

        else
        {
            return AttackInput.Press;
        }
    }

    public static AttackInput PerformedAttackInput(InputAction.CallbackContext input)
    {
        if (input.interaction is MultiTapInteraction)
        {
            return AttackInput.MultiTab;
        }  

        if (input.interaction is TapInteraction)
        {
            return AttackInput.Tab;
        }

        if (input.interaction is SlowTapInteraction)
        {
            return AttackInput.SlowTab;
        }

        else
        {
            return AttackInput.Empty;
        }
    }

    public static AttackInput CancelledAttackInput(InputAction.CallbackContext input)
    {
        return AttackInput.Empty;
    }
}
