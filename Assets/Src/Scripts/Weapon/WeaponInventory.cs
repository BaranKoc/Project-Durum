using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public GameObject PrimaryWeapon;
    [HideInInspector] public WeaponComponent PrimaryWeaponComponent;

    public GameObject SecondaryWeapon;
    [HideInInspector] public WeaponComponent SecondaryWeaponComponent;
    


    public WeaponComponent getPrimaryWeaponComponent()
    {
        if (PrimaryWeapon != null) 
        {
            PrimaryWeaponComponent = PrimaryWeapon.GetComponent<WeaponComponent>();
        }
        return PrimaryWeaponComponent;
    }

    public WeaponComponent getSecondaryWeaponComponent()
    {
        if (SecondaryWeapon != null) 
        {
            SecondaryWeaponComponent = SecondaryWeapon.GetComponent<WeaponComponent>();
        }
        return SecondaryWeaponComponent;
    }
}
