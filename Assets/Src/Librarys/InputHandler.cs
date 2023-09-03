using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class InputHandler
{
    public static AttackInput StartedAttackInput(InputAction.CallbackContext input, bool taking_aim)
    {
        return AttackType(taking_aim);
    }

    public static AttackInput PerformedAttackInput(InputAction.CallbackContext input, bool taking_aim)
    {
        if (input.interaction is HoldInteraction)
        {
            return AttackType(taking_aim);
        }

        return AttackInput.Empty;
    }

    public static AttackInput CancelledAttackInput(InputAction.CallbackContext input)
    {        
        return AttackInput.Empty;
    }

    private static AttackInput AttackType(bool taking_aim)
    {
        if (taking_aim) { return AttackInput.Shoot; }
        else { return AttackInput.Melee; }
    }



    public static bool StartedAimInput(InputAction.CallbackContext input)
    {
        return true;
    }

    public static bool PerformedAimInput(InputAction.CallbackContext input)
    {
        if (input.interaction is HoldInteraction)
        {
            return true;
        }

        return false;
    }

    public static bool CancelledAimInput(InputAction.CallbackContext input)
    {
        return false;
    }
}
