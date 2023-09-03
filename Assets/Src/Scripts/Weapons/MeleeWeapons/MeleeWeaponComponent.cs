using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class MeleeWeaponComponent : MonoBehaviour
{
    private PlayerCtrl playerCtrl;

    private Animator anim;
    private GameObject baseGameObject;
    private GameObject spritesGameObject;

    public MeleeWeaponData weaponData;
    public MeleeWeaponInstance weaponInstance;


    public void init(PlayerCtrl _playerCtrl)
    {
        playerCtrl = _playerCtrl;
        weaponInstance.init(playerCtrl);

        baseGameObject = transform.Find("Base").gameObject;
        spritesGameObject = transform.Find("Sprites").gameObject;

        anim = baseGameObject.GetComponent<Animator>();
    }
    
}
