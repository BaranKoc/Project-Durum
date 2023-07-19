using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
public class SpaceShip : MonoBehaviour
{
 
    private void FixedUpdate()
    {
        if (PlayerLibrary.CanFlip(this, rb))
        {
            StartCoroutine(flip());
            RotateInDirection(direction_flip);
            Animate Flip();
        }
    }
    


    [HideInInspector] public Vector2 _movementInput;
    [HideInInspector] public Vector2 _smoothedMovementInput;
    [HideInInspector] public Vector2 _movementInputSmoothVelocity;

    _smoothedMovementInput = Vector2.SmoothDamp(
        _smoothedMovementInput,
        _movementInput,
        ref _movementInputSmoothVelocity,
        0.1f );

    rb.velocity = _smoothedMovementInput * playerData.CURRENT_MovementSpeed;




    [HideInInspector] public Vector2 direction_flip;
    [HideInInspector] public bool is_fliping = false;
    [HideInInspector] public bool can_flip = true;

    private IEnumerator flip()
    {
        tr.emitting = true;
        tr.startColor = Color.blue;
        is_fliping = true;
        can_flip = false;

        rb.velocity = direction_flip * playerData.CURRENT_flip_speed;
        //            Until This Condition
        //            🔻🔻🔻🔻🔻🔻🔻🔻  
        yield return new WaitForSeconds(playerData.CURRENT_flip_time);

        rb.velocity = Vector2.zero;
        tr.emitting = false;
        is_fliping = false;
        //            Until This Condition
        //            🔻🔻🔻🔻🔻🔻🔻🔻  
        yield return new WaitForSeconds(playerData.CURRENT_flip_Cooldown);

        can_flip = true;
    }
}
*/



/* 
public static bool CanFlip(PlayerCtrl _playerCtrl, Rigidbody2D rb)
    {
        if (_playerCtrl.can_flip == false)
        { return false; }

        if (_playerCtrl.direction_flip == Vector2.zero)
        { return false; }

        if (_playerCtrl.is_fliping)
        { return false; }

        if (_playerCtrl.is_dashing)
        { return false; }

        if 
        (
        MathHelpers.AreVectorsOpposite(
            MathHelpers.DegreeToVector2(rb.rotation),
            _playerCtrl._movementInput)
        )
        { return true; }

        else
        { return false; }
    }

*/