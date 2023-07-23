using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsComponent : MonoBehaviour
{
    public GameObject PrimaryWeapon;
    [HideInInspector] public WeaponComponent PrimaryWeaponComponent;

    public GameObject SecondaryWeapon;
    [HideInInspector] public WeaponComponent SecondaryWeaponComponent;
    

    private void Awake()
    {
        if (PrimaryWeapon != null) PrimaryWeaponComponent = PrimaryWeapon.GetComponent<WeaponComponent>();
        if (SecondaryWeapon != null) SecondaryWeaponComponent = SecondaryWeaponComponent.GetComponent<WeaponComponent>();
    }
}
