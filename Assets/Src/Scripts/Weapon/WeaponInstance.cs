using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class WeaponInstance : MonoBehaviour, IWeaponInstance
{
    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                     INTERACTION FIELD                      */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    
    public void UpdateCurrentInputState(AttackInput input)
    {
        current_input = input;
    }

    public void UpdateLastInputState()
    {
        last_input = current_input;
    }

    public virtual void whenMultiTab(){}
    public virtual void whenPress(){}
    public virtual void whenTab(){}
    public virtual void whenSlowTab(){}
    public virtual void whenHold(){}



    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                         Variables                          */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    private AttackInput _last_input;
    public AttackInput last_input 
    {
        get { return _last_input; } 
        set {_last_input = value; }
    }

    private AttackInput _current_input;
    public AttackInput current_input 
    {
        get { return _current_input; } 
        set {_current_input = value; }
    }

}