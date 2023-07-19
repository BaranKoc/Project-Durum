using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLibrary
{
    
    public static bool CanDash(PlayerCtrl _playerCtrl)
    {
        if (_playerCtrl.can_dash == false)
        { return false; }

        if (_playerCtrl.direction_dash == Vector2.zero)
        { return false; }

        if (_playerCtrl.is_dashing)
        { return false; }

        else { return true; }
    }

    public static bool CanMove(PlayerCtrl _playerCtrl)
    {
        if (_playerCtrl._movementInput == Vector2.zero)
        { return false; }

        if (_playerCtrl.is_dashing)
        { return false; }

        else
        { return true; }
    }
}
