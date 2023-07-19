using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public enum input_state { Tab, MultiTab, SlowTab, Hold, Empty}


interface IWeapon
{
    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                         Variables                          */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    
    bool auto_tab {get; set;}

    
    input_state last_input {get; set;}
    input_state current_input {get; set;}


    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                     INTERACTION FIELD                      */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    void StartedAttack(InputAction.CallbackContext input);

    void PerformedAttack(InputAction.CallbackContext input);

    void CancelledAttack(InputAction.CallbackContext input);

    void whenMultiTab();
    void whenTab();
    void whenSlowTab();
    void whenHold();
}
