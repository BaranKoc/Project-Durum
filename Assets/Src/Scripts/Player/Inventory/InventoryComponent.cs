using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    /* 
    TODO: 
        * code functions to change items
    */

    private PlayerCtrl playerCtrl;

    public GameObject RangedWeapon;
    [HideInInspector] public RangedWeaponComponent rangedWeaponComponent;
    
    public GameObject MeleeWeapon;
    [HideInInspector] public MeleeWeaponComponent meleeWeaponComponent;


    public void init(PlayerCtrl _playerCtrl)
    {
        playerCtrl = _playerCtrl;
    }


    private void getRangedWeapon()
    {
        rangedWeaponComponent = RangedWeapon.GetComponent<RangedWeaponComponent>();
        rangedWeaponComponent.init(playerCtrl);
    }    
    public void UpdateRangedWeapon()
    {
        getRangedWeapon();
        playerCtrl.setRangedWeapon(rangedWeaponComponent, rangedWeaponComponent.weaponInstance);
    }


    private void getMeleeWeapon()
    {
        meleeWeaponComponent = MeleeWeapon.GetComponent<MeleeWeaponComponent>();
        meleeWeaponComponent.init(playerCtrl);
    }
    public void UpdateMeleeWeapon()
    {
        getMeleeWeapon();
        playerCtrl.setMeleeWeapon(meleeWeaponComponent, meleeWeaponComponent.weaponInstance);
    }

    
}
