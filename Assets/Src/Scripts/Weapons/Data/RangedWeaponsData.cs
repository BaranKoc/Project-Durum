using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon, IWeapon
{
    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                    Tab Attack Settings                     */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    [Header("Tab Attack Settings")]
    public float DEFAULT_Tab_AttackDamage;
    public float DEFAULT_Tab_AttackCooldown;
    public float DEFAULT_Tab_AttackCost;
    public float DEFAULT_Tab_Ammo;
    public float DEFAULT_Tab_ReloadSpeed;

    protected float CURRENT_Tab_AttackDamage;
    protected float CURRENT_Tab_AttackCooldown;
    protected float CURRENT_Tab_AttackCost;
    protected float CURRENT_Tab_Ammo;
    protected float CURRENT_Tab_ReloadSpeed;



    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                  MultiTab Attack Settings                  */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    [Header("MultiTab Attack Settings")]
    public float DEFAULT_MultiTab_AttackDamage;
    public float DEFAULT_MultiTab_AttackCooldown;
    public float DEFAULT_MultiTab_AttackCost;
    public float DEFAULT_MultiTab_Ammo;
    public float DEFAULT_MultiTab_ReloadSpeed;
 
    protected float CURRENT_MultiTab_AttackDamage;
    protected float CURRENT_MultiTab_AttackCooldown;
    protected float CURRENT_MultiTab_AttackCost;
    protected float CURRENT_MultiTab_Ammo;
    protected float CURRENT_MultiTab_ReloadSpeed;



    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                    Hold Attack Settings                    */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    [Header("Hold Attack Settings")]
    public float DEFAULT_Hold_AttackDamage;
    public float DEFAULT_Hold_AttackCooldown;
    public float DEFAULT_Hold_AttackCost;
    public float DEFAULT_Hold_Ammo;
    public float DEFAULT_Hold_ReloadSpeed;
 
    protected float CURRENT_Hold_AttackDamage;
    protected float CURRENT_Hold_AttackCooldown;
    protected float CURRENT_Hold_AttackCost;
    protected float CURRENT_Hold_Ammo;
    protected float CURRENT_Hold_ReloadSpeed;



    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                  SlowTab Attack Settings                   */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    [Header("SlowTab Attack Settings")]
    public float DEFAULT_SlowTab_AttackDamage;
    public float DEFAULT_SlowTab_AttackCooldown;
    public float DEFAULT_SlowTab_AttackCost;
    public float DEFAULT_SlowTab_Ammo;
    public float DEFAULT_SlowTab_ReloadSpeed;
 
    protected float CURRENT_SlowTab_AttackDamage;
    protected float CURRENT_SlowTab_AttackCooldown;
    protected float CURRENT_SlowTab_AttackCost;
    protected float CURRENT_SlowTab_Ammo;
    protected float CURRENT_SlowTab_ReloadSpeed;



    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        SETUP FIELD                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================  
    void Start()
    {
        CURRENT_Tab_AttackDamage = DEFAULT_Tab_AttackDamage;
        CURRENT_Tab_AttackCooldown = DEFAULT_Tab_AttackCooldown;
        CURRENT_Tab_AttackCost = DEFAULT_Tab_AttackCost;
        CURRENT_Tab_Ammo = DEFAULT_Tab_Ammo;
        CURRENT_Tab_ReloadSpeed = DEFAULT_Tab_ReloadSpeed;

        CURRENT_MultiTab_AttackDamage = DEFAULT_MultiTab_AttackDamage;
        CURRENT_MultiTab_AttackCooldown = DEFAULT_MultiTab_AttackCooldown;
        CURRENT_MultiTab_AttackCost = DEFAULT_MultiTab_AttackCost;
        CURRENT_MultiTab_Ammo = DEFAULT_MultiTab_Ammo;
        CURRENT_MultiTab_ReloadSpeed = DEFAULT_MultiTab_ReloadSpeed;

        CURRENT_Hold_AttackDamage = DEFAULT_Hold_AttackDamage;
        CURRENT_Hold_AttackCooldown = DEFAULT_Hold_AttackCooldown;
        CURRENT_Hold_AttackCost = DEFAULT_Hold_AttackCost;
        CURRENT_Hold_Ammo = DEFAULT_Hold_Ammo;
        CURRENT_Hold_ReloadSpeed = DEFAULT_Hold_ReloadSpeed;

        CURRENT_SlowTab_AttackDamage = DEFAULT_SlowTab_AttackDamage;
        CURRENT_SlowTab_AttackCooldown = DEFAULT_SlowTab_AttackCooldown;
        CURRENT_SlowTab_AttackCost = DEFAULT_SlowTab_AttackCost;
        CURRENT_SlowTab_Ammo = DEFAULT_SlowTab_Ammo;
        CURRENT_SlowTab_ReloadSpeed = DEFAULT_SlowTab_ReloadSpeed;
    }


    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                         Variables                          */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    
    [Header("Bullet Settings")]
    
    [SerializeField] protected GameObject TabBulletPrefab;
    [SerializeField] protected GameObject MultiTabBulletPrefab;
    [SerializeField] protected GameObject SlowTabBulletPrefab;
    [SerializeField] protected GameObject HoldBulletPrefab;
}
