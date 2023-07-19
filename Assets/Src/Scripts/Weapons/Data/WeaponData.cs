using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public abstract class Weapon : ScriptableObject, IWeapon
{
    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        SETUP FIELD                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================  
    [HideInInspector] public PlayerCtrl playerCtrl;

    void Start()
    {
        last_input = input_state.Empty;
        current_input = input_state.Empty;
    }


    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                     INTERACTION FIELD                      */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    public  void StartedAttack(InputAction.CallbackContext input)
    {
        if (input.interaction is SlowTapInteraction)
        {
            whenHold();
        }
            
        else if(auto_tab)
        {
            whenTab();
        }

        else 
        {
            auto_tab = true;
        }
    }

    public void PerformedAttack(InputAction.CallbackContext input)
    {
        if (input.interaction is MultiTapInteraction)
        {
            whenMultiTab();
        }  

        if (input.interaction is SlowTapInteraction)
        {
            whenSlowTab();
            auto_tab = true;
        }
    }

    public void CancelledAttack(InputAction.CallbackContext input)
    {
        if (input.interaction is MultiTapInteraction)
        {
            auto_tab = false;
        }
    }

    public void UpdateLastInputState()
    {
        last_input = current_input;
    }
    public void ClearCurrentInputState()
    {
        current_input = input_state.Empty;
    }


    public virtual void whenMultiTab(){}
    public virtual void whenTab(){}
    public virtual void whenSlowTab(){}
    public virtual void whenHold(){}




    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                         Variables                          */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    private bool _auto_tab;
    public bool auto_tab 
    {
        get { return _auto_tab; }
        set{ _auto_tab = value; }
    }


    private input_state _last_input;
    public input_state last_input 
    {
        get { return _last_input; } 
        set {_last_input = value; }
    }

    private input_state _current_input;
    public input_state current_input 
    {
        get { return _current_input; } 
        set {_current_input = value; }
    }
}

