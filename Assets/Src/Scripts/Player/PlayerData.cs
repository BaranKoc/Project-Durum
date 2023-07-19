using UnityEngine;

public class PlayerData : CharacterData
{
    [HideInInspector] public PlayerCtrl playerCtrl;


    [Header("Dash Settings")]
    public float DEFAULT_dash_Speed;
    public float DEFAULT_dash_Time;
    public float DEFAULT_dash_Cooldown;

    [HideInInspector] public float CURRENT_dash_speed;
    [HideInInspector] public float CURRENT_dash_time;
    [HideInInspector] public float CURRENT_dash_Cooldown;


    [Header("Flip Settings")]
    public float DEFAULT_flip_Speed;
    public float DEFAULT_flip_Time;
    public float DEFAULT_flip_Cooldown;

    [HideInInspector] public float CURRENT_flip_speed;
    [HideInInspector] public float CURRENT_flip_time;
    [HideInInspector] public float CURRENT_flip_Cooldown;


    [Header("Weapon Settings")]
    public Weapon Weapon1;
    public Weapon Weapon2;


    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        SETUP FIELD                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    void Start()
    {
        if (playerCtrl == null) playerCtrl = GetComponent<PlayerCtrl>();

        CURRENT_MovementSpeed = DEFAULT_MovementSpeed;
        CURRENT_RotatoinSpeed = DEFAULT_RotationSpeed;

        CURRENT_dash_speed = DEFAULT_dash_Speed;
        CURRENT_dash_time = DEFAULT_dash_Time;
        CURRENT_dash_Cooldown = DEFAULT_dash_Cooldown;

        CURRENT_flip_speed = DEFAULT_flip_Speed;
        CURRENT_flip_time = DEFAULT_flip_Time;
        CURRENT_flip_Cooldown = DEFAULT_flip_Cooldown;

        ActivateWeapon1();
    }


    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                      Inventory Field                       */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================    

    private void ActivateWeapon1()
    {
        Weapon1.playerCtrl = playerCtrl;
    }
    private void ActivateWeapon2()
    {
        Weapon2.playerCtrl = playerCtrl;
    }
}
