using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class PlayerCtrl : MonoBehaviour
{
    // Components
    private Rigidbody2D rb;
    private TrailRenderer tr;

    private PlayerData playerData;

    public PlayerAnimation playerAnimation;

    private PlayerInputActions playerInputActions;

    public Transform firingPoint;


    private GameObject Inventory;
    private InventoryWeapon weaponsComponent;
    private WeaponComponent PrimaryWeaponComponent;
    private WeaponComponent SecondaryWeaponComponent;


    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        SETUP FIELD                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();

        playerData = GetComponent<PlayerData>();

        playerAnimation = new PlayerAnimation(GetComponent<Animator>(), transform);

        playerInputActions = new PlayerInputActions();


        Inventory = transform.Find("Inventory").gameObject; 

        if (Inventory != null) weaponsComponent = Inventory.GetComponent<InventoryWeapon>();
        if (weaponsComponent != null)
        {
            if (weaponsComponent.PrimaryWeaponComponent != null)   {PrimaryWeaponComponent = weaponsComponent.PrimaryWeaponComponent;} 
            if (weaponsComponent.SecondaryWeaponComponent != null) {SecondaryWeaponComponent = weaponsComponent.SecondaryWeaponComponent;} 
        }
    }

    private void OnEnable()
    {
        playerInputActions.Enable();

        playerInputActions.Player.Movement.performed += PerformedMovement;
        playerInputActions.Player.Movement.canceled += CancelledMovement;

        playerInputActions.Player.Dash.performed += PerformedDash;
        playerInputActions.Player.Dash.canceled += CancelledDash;

        playerInputActions.Player.PrimaryWeapon.started += PrimaryWeaponStarted;
        playerInputActions.Player.PrimaryWeapon.performed += PrimaryWeaponPerformed;
        playerInputActions.Player.PrimaryWeapon.canceled += PrimaryWeaponCancelled;
    }

    private void OnDisable()
    {
        playerInputActions.Disable();

        playerInputActions.Player.Movement.performed -= PerformedMovement;
        playerInputActions.Player.Movement.canceled -= CancelledMovement;

        playerInputActions.Player.Dash.performed -= PerformedDash;
        playerInputActions.Player.Dash.canceled -= CancelledDash;
    }





    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                        LOOP FIELD                          */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    private void Update() 
    { 
    }

    private void FixedUpdate()
    {
        if (PlayerLibrary.CanDash(this))
        {
            StartCoroutine(dash());
            // Animate Dash
        }

        if (PlayerLibrary.CanMove(this))
        {
            SetPlayerVelocity();
            UpdateIsWalking();
            RotateInDirection(_movementInput); 
            // Animate Movement
        }
    }




    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                      MOVEMENT FIELD                        */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    [HideInInspector] public Vector2 _movementInput;
    [HideInInspector] public bool is_walking;
    
    private void PerformedMovement(InputAction.CallbackContext input)
    {
        _movementInput = input.ReadValue<Vector2>();
        _movementInput.Normalize();
    }

    private void CancelledMovement(InputAction.CallbackContext input)
    {
        _movementInput = Vector2.zero;
        rb.velocity = Vector2.zero;
    }


    private void SetPlayerVelocity()
    {
        rb.velocity = _movementInput * playerData.CURRENT_MovementSpeed;
    }

    private void RotateInDirection(Vector2 vector)
    {
        if (is_walking)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }

    private void UpdateIsWalking()
    {
        if (_movementInput != Vector2.zero)
        { is_walking = true; }

        else if (_movementInput == Vector2.zero)
        { is_walking = false; }
    }




    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                         DASH FIELD                         */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================

    [HideInInspector] public Vector2 direction_dash;
    [HideInInspector] public bool is_dashing = false;
    [HideInInspector] public bool can_dash = true;


    private void PerformedDash(InputAction.CallbackContext input)
    {
        direction_dash = MathHelpers.DegreeToVector2(transform.rotation.eulerAngles.z);
    }

    private void CancelledDash(InputAction.CallbackContext input)
    {
        direction_dash = Vector2.zero;
    }


    private IEnumerator dash()
    {
        // Force to be correct
        direction_dash = MathHelpers.DegreeToVector2(transform.rotation.eulerAngles.z);

        tr.emitting = true;
        tr.startColor = Color.red;
        is_dashing = true;
        can_dash = false;

        rb.velocity = direction_dash.normalized * playerData.CURRENT_dash_speed * Time.deltaTime;
        //            Until This Condition
        //            🔻🔻🔻🔻🔻🔻🔻🔻  
        yield return new WaitForSeconds(playerData.CURRENT_dash_time);
        
        rb.velocity = Vector2.zero;
        tr.emitting = false;
        is_dashing = false;
        //            Until This Condition
        //            🔻🔻🔻🔻🔻🔻🔻🔻  
        yield return new WaitForSeconds(playerData.CURRENT_dash_Cooldown);

        can_dash = true;
    }




    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                       PRIMARY WEAPON                       */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    [HideInInspector] public AttackInput ATTACK1_current_input = AttackInput.Empty;
    
    private void PrimaryWeaponStarted(InputAction.CallbackContext input)
    {
        switch (InputHandler.StartedAttackInput(input))
        {
            case AttackInput.Empty:
                break;
            
            case AttackInput.Press:
                Debug.Log("PrimaryWeaponStarted: Press");
                break;

            case AttackInput.Tab:
                Debug.Log("PrimaryWeaponStarted: Tab");
                break;

            case AttackInput.MultiTab:
                Debug.Log("PrimaryWeaponStarted: MultiTab");
                break;
            
            case AttackInput.SlowTab:
                Debug.Log("PrimaryWeaponStarted: SlowTab");
                break;
            
            case AttackInput.Hold:
                Debug.Log("PrimaryWeaponStarted: Hold");
                break;
        }
    }

    private void PrimaryWeaponPerformed(InputAction.CallbackContext input)
    {
        switch (InputHandler.PerformedAttackInput(input))
        {
            case AttackInput.Empty:
                break;
            
            case AttackInput.Press:
                Debug.Log("PrimaryWeaponPerformed: Press");
                break;

            case AttackInput.Tab:
                Debug.Log("PrimaryWeaponPerformed: Tab");
                break;

            case AttackInput.MultiTab:
                Debug.Log("PrimaryWeaponPerformed: MultiTab");
                break;
            
            case AttackInput.SlowTab:
                Debug.Log("PrimaryWeaponPerformed: SlowTab");
                break;
            
            case AttackInput.Hold:
                Debug.Log("PrimaryWeaponPerformed: Hold");
                break;
        }
    }

    private void PrimaryWeaponCancelled(InputAction.CallbackContext input)
    {
        switch (InputHandler.CancelledAttackInput(input))
        {
            case AttackInput.Empty:
                break;
            
            case AttackInput.Press:
                Debug.Log("PrimaryWeaponCancelled: Press");
                break;

            case AttackInput.Tab:
                Debug.Log("PrimaryWeaponCancelled: Tab");
                break;

            case AttackInput.MultiTab:
                Debug.Log("PrimaryWeaponCancelled: MultiTab");
                break;
            
            case AttackInput.SlowTab:
                Debug.Log("PrimaryWeaponCancelled: SlowTab");
                break;
            
            case AttackInput.Hold:
                Debug.Log("PrimaryWeaponCancelled: Hold");
                break;
        }
    }


    
    //================================================================
    /*´:°•.°+.*•´.*:˚.°*.˚•´.°:°•.°•.*•´.*:˚.°*.˚•´.°:°•.°+.*•´.*:*/
    /*                       ATTACK2 FIELD                        */
    /*.•°:°.´+˚.*°.˚:*.´•*.+°.•°:´*.´•*.•°.•°:°.´:•˚°.*°.˚:*.´+°.•*/
    //================================================================
    [HideInInspector] public AttackInput ATTACK2_current_input = AttackInput.Empty;
    
}