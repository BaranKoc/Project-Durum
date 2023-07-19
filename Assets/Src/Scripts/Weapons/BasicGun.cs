using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


[CreateAssetMenu(menuName = "Weapons/Basic Gun", fileName = "Basic Gun")]
public class BasicGun : RangedWeapon, IWeapon
{
    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                     INTERACTION FIELD                      */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    public override void whenMultiTab()
    {
        UpdateLastInputState();
        current_input = input_state.MultiTab;
        ShootMultiTab();
    }

    public override void whenTab()
    {
        UpdateLastInputState();
        current_input = input_state.Tab;
        ShootTab();
    }

    public override void whenSlowTab()
    {
        UpdateLastInputState();
        current_input = input_state.SlowTab;
        ShootSlowTab();
    }

    public override void whenHold()
    {
        UpdateLastInputState();
        current_input = input_state.Hold;
    }



    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        ACTION FIELD                        */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    public void ShootTab()
    {
       Instantiate(TabBulletPrefab, playerCtrl.firingPoint.position, playerCtrl.firingPoint.rotation);
    }

    public void ShootMultiTab()
    {
       Instantiate(MultiTabBulletPrefab, playerCtrl.firingPoint.position, playerCtrl.firingPoint.rotation);
    }
    
    public void ShootSlowTab()
    {
       Instantiate(SlowTabBulletPrefab, playerCtrl.firingPoint.position, playerCtrl.firingPoint.rotation);
    }
}
