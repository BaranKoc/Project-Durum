using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class InputHandler
{
    private Time lastTabTime;

    public static AttackInput StartedAttackInput(InputAction.CallbackContext input)
    {
        if (input.interaction is SlowTapInteraction)
        {
            return AttackInput.Hold;
        }
        
        return AttackInput.Press;
    }

    public static AttackInput PerformedAttackInput(InputAction.CallbackContext input)
    {
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
