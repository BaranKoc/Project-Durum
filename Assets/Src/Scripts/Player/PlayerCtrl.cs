using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class PlayerCtrl : MonoBehaviour
{
    // Components
    private Rigidbody2D rb;

    private PlayerData playerData;

    public PlayerAnimation playerAnimation;

    private PlayerInputActions playerInputActions;

    public Transform firingPoint;

    private GameObject InventoryGameObject;
    private InventoryComponent Inventory;
    
    [HideInInspector] public RangedWeaponComponent rangedWeaponComponent;
    [HideInInspector] public RangedWeaponInstance rangedWeaponInstance;
    
    [HideInInspector] public MeleeWeaponComponent meleeWeaponComponent;
    [HideInInspector] public MeleeWeaponInstance meleeWeaponInstance;

    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        SETUP FIELD                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerData = GetComponent<PlayerData>();

        playerAnimation = new PlayerAnimation(GetComponent<Animator>(), transform);

        playerInputActions = new PlayerInputActions();

        InventoryGameObject = transform.Find("Inventory").gameObject; 
        Inventory = InventoryGameObject.GetComponent<InventoryComponent>();
        
        Inventory.init(this);
        Inventory.UpdateRangedWeapon();
        Inventory.UpdateMeleeWeapon();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();

        playerInputActions.Player.Movement.performed += PerformedMovement;
        playerInputActions.Player.Movement.canceled += CancelledMovement;

        playerInputActions.Player.Dash.performed += PerformedDash;
        playerInputActions.Player.Dash.canceled += CancelledDash;

        playerInputActions.Player.Aim.started += AimInputStarted;
        playerInputActions.Player.Aim.performed += AimInputPerformed;
        playerInputActions.Player.Aim.canceled += AimInputCancelled;

        playerInputActions.Player.Attack.started += AttackInputStarted;
        playerInputActions.Player.Attack.performed += AttackInputPerformed;
        playerInputActions.Player.Attack.canceled += AttackInputCancelled;
    }

    private void OnDisable()
    {
        playerInputActions.Disable();

        playerInputActions.Player.Movement.performed -= PerformedMovement;
        playerInputActions.Player.Movement.canceled -= CancelledMovement;

        playerInputActions.Player.Dash.performed -= PerformedDash;
        playerInputActions.Player.Dash.canceled -= CancelledDash;
        
        playerInputActions.Player.Aim.started -= AimInputStarted;
        playerInputActions.Player.Aim.performed -= AimInputPerformed;
        playerInputActions.Player.Aim.canceled -= AimInputCancelled;

        playerInputActions.Player.Attack.started -= AttackInputStarted;
        playerInputActions.Player.Attack.performed -= AttackInputPerformed;
        playerInputActions.Player.Attack.canceled -= AttackInputCancelled;
    }





    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        LOOP FIELD                          */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    private void Update() 
    { 
        // Aim...
        if (taking_aim) { rangedWeaponInstance.Aim(); }
        else { rangedWeaponInstance.AimInputCancelled(); }


        // Attack...
        switch (current_attack_input)
        {
            case AttackInput.Empty:
                rangedWeaponInstance.ShootInputCancelled();
                meleeWeaponInstance.MeleeAttackInputCancelled();
                break;
            
            case AttackInput.Melee:
                meleeWeaponInstance.MeleeAttack();
                break;

            case AttackInput.Shoot:
                rangedWeaponInstance.Shoot();
                break;
        }


        // Animations...

        if (is_dashing)
        {
            // Animate Dash
        }
        
        if (is_walking)
        {
            // Animate Movement
        }
    }

    private void FixedUpdate()
    {
        if (PlayerLibrary.CanDash(this))
        {
            StartCoroutine(dash());
        }

        if (PlayerLibrary.CanMove(this))
        {
            SetPlayerVelocity();
            UpdateIsWalking();
            RotateInDirection(_movementInput); 
        }
    }




    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                      MOVEMENT FIELD                        */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    [HideInInspector] public Vector2 _movementInput;
    [HideInInspector] public bool is_walking = false;
    
    private void PerformedMovement(InputAction.CallbackContext input)
    {
        _movementInput = input.ReadValue<Vector2>();
        _movementInput.Normalize();
    }

    private void CancelledMovement(InputAction.CallbackContext input)
    {
        stopWalking();
    }

    [HideInInspector] 
    public void stopWalking()
    {
        _movementInput = Vector2.zero;
        is_walking = false;
        rb.velocity = Vector2.zero;
    }


    private void SetPlayerVelocity()
    {
        rb.velocity = _movementInput * playerData.CURRENT_MovementSpeed;
    }

    private void UpdateIsWalking()
    {
        if (_movementInput != Vector2.zero && rb.velocity != Vector2.zero)
        { is_walking = true; }

        else if (_movementInput == Vector2.zero || rb.velocity == Vector2.zero)
        { is_walking = false; }
    }

    private void RotateInDirection(Vector2 vector)
    {
        if (is_walking)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }




    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                         DASH FIELD                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    [HideInInspector] public Vector2 direction_dash;

    [HideInInspector] public bool request_dash = false;
    [HideInInspector] public bool request_ChainDash = false;
    [HideInInspector] public bool request_HoverDash = false;
    
    [HideInInspector] public bool is_dashing = false;
    [HideInInspector] public bool lock_dash = false;


    private void PerformedDash(InputAction.CallbackContext input)
    {
        request_dash = true;
    }

    private void CancelledDash(InputAction.CallbackContext input)
    {
        request_dash = false;
    }


    private IEnumerator stopdash()
    {
        rb.velocity = Vector2.zero;
        direction_dash = Vector2.zero;
        is_dashing = false;

        yield return new WaitForSeconds(playerData.CURRENT_dash_Cooldown);
        lock_dash = false;
    }

    private IEnumerator dash()
    {
        is_dashing = true;
        lock_dash = true;

        direction_dash = MathHelpers.DegreeToVector2(transform.rotation.eulerAngles.z);        
        rb.velocity = direction_dash.normalized * playerData.CURRENT_dash_speed * Time.deltaTime;
        //            Until This Condition
        //            🔻🔻🔻🔻🔻🔻🔻🔻  
        yield return new WaitForSeconds(playerData.CURRENT_dash_time);
        
        StartCoroutine(stopdash());
    }






    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                      Inventory Field                       */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    public void setRangedWeapon(RangedWeaponComponent _WeaponComponent, RangedWeaponInstance _WeaponInstance)
    {
        rangedWeaponComponent = _WeaponComponent;
        rangedWeaponInstance = _WeaponInstance;
    }

    public void setMeleeWeapon(MeleeWeaponComponent _WeaponComponent, MeleeWeaponInstance _WeaponInstance)
    {
        meleeWeaponComponent = _WeaponComponent;
        meleeWeaponInstance = _WeaponInstance;
    }



    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                       Attack Input                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    private AttackInput current_attack_input = AttackInput.Empty;
    private bool taking_aim = false;

    private void AttackInputStarted(InputAction.CallbackContext input)
    {
        switch (InputHandler.StartedAttackInput(input,taking_aim))
        { 
            case AttackInput.Empty:
                current_attack_input = AttackInput.Empty;
                break;
            
            case AttackInput.Melee:
                current_attack_input = AttackInput.Melee;
                break;

            case AttackInput.Shoot:
                current_attack_input = AttackInput.Shoot;
                break;
        }
    }

    private void AttackInputPerformed(InputAction.CallbackContext input)
    {
        switch (InputHandler.PerformedAttackInput(input,taking_aim))
        { 
            case AttackInput.Empty:
            current_attack_input = AttackInput.Empty;
                break;
            
            case AttackInput.Melee:
                current_attack_input = AttackInput.Melee;
                break;

            case AttackInput.Shoot:
                current_attack_input = AttackInput.Shoot;
                break;
        }
    }

    private void AttackInputCancelled(InputAction.CallbackContext input)
    {
        switch (InputHandler.CancelledAttackInput(input))
        { 
            case AttackInput.Empty:
            current_attack_input = AttackInput.Empty;
                break;
            
            case AttackInput.Melee:
                current_attack_input = AttackInput.Melee;
                break;

            case AttackInput.Shoot:
                current_attack_input = AttackInput.Shoot;
                break;
        }
    }


    private void AimInputStarted(InputAction.CallbackContext input)
    {
        if (InputHandler.StartedAimInput(input)) { taking_aim = true; }
        else { taking_aim = false; }
    }

    private void AimInputPerformed(InputAction.CallbackContext input)
    {
        if (InputHandler.PerformedAimInput(input)) { taking_aim = true; }
        else { taking_aim = false; }
    }

    private void AimInputCancelled(InputAction.CallbackContext input)
    {
        if (InputHandler.CancelledAimInput(input)) { taking_aim = true; }
        else { taking_aim = false; }
    }


}

    
