using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{

    private Animator anim;
    private GameObject baseGameObject;

    public WeaponData weaponData;
    public WeaponInstance weaponInstance;

    private void Awake()
    {
        baseGameObject = transform.Find("Base").gameObject;
        anim = baseGameObject.GetComponent<Animator>();
    }

    
}
