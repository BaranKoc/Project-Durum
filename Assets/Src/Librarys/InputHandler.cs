using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class InputHandler
{
    private static float lastTabTime = 0;
    private static int TabCount = 0;
    private static float TabSpaceping = 0.3f;

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
            if ((TabCount >= 1) & (Time.time <= lastTabTime + TabSpaceping))
            {
                return MultiTab();
            }

            else
            {
                return Tab();
            }
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


    private static AttackInput Tab()
    {
        TabCount++;
        lastTabTime = Time.time;
        return AttackInput.Tab;
    }

    private static AttackInput MultiTab()
    {
        TabCount = 0;
        lastTabTime = Time.time;
        return AttackInput.MultiTab;
    }
}
