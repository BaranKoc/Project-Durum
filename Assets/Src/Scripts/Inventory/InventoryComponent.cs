using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    /* 
    TODO: 
        * public void ChangeWeapon(float index, GameObject _SecondaryWeapon){}

        * This will be need for pick up items 
    */

    private PlayerCtrl playerCtrl;

    public GameObject PrimaryWeapon;
    [HideInInspector] public WeaponComponent PrimaryWeaponComponent;

    public GameObject SecondaryWeapon;
    [HideInInspector] public WeaponComponent SecondaryWeaponComponent;
    

    public void init(PlayerCtrl _playerCtrl)
    {
        playerCtrl = _playerCtrl;
    }


    private void getPrimaryWeapon()
    {
        PrimaryWeaponComponent = PrimaryWeapon.GetComponent<WeaponComponent>();
        PrimaryWeaponComponent.init(playerCtrl);
    }    
    public void UpdatePrimaryWeapon()
    {
        getPrimaryWeapon();
        playerCtrl.setPrimaryWeapon(PrimaryWeaponComponent, PrimaryWeaponComponent.weaponInstance);
    }


    private void getSecondaryWeapon()
    {
        PrimaryWeaponComponent = PrimaryWeapon.GetComponent<WeaponComponent>();
        PrimaryWeaponComponent.init(playerCtrl);
    }
    public void UpdateSecondaryWeapon()
    {
        getSecondaryWeapon();
        playerCtrl.setSecondaryWeapon(SecondaryWeaponComponent, SecondaryWeaponComponent.weaponInstance);
    }




    
}
