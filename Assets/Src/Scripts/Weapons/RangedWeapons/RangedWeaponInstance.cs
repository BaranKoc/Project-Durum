using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeaponInstance : WeaponInstance, IRangedWeaponInstance
{
    public abstract void Aim();
    public abstract void AimInputCancelled();

    public abstract void Shoot();
    public abstract void ShootInputCancelled();
}
