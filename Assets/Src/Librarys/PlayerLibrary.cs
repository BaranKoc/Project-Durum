using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLibrary
{
    
    public static bool CanDash(PlayerCtrl _playerCtrl)
    {
        if (_playerCtrl.lock_dash == true)
        { return false; }

        if (_playerCtrl.request_dash == false)
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
