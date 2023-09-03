using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeaponInstance : WeaponInstance, IMeleeWeaponInstance
{
    public abstract void MeleeAttack();
    public abstract void MeleeAttackInputCancelled();
}
