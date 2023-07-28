using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunInstance : WeaponInstance
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float firerate = 0.5f;

    public override void whenMultiTab()
    {
        Debug.Log("MultiTab");
    }
    public override void whenPress()
    {
        Debug.Log("Press");
        ShootPress();
    }
    public override void whenTab()
    {
        Debug.Log("Tab");
    }
    public override void whenSlowTab()
    {
        Debug.Log("SlowTab");
    }
    public override void whenHold()
    {
        Debug.Log("Hold");
    }


    public void ShootPress()
    {   
        Debug.Log(playerCtrl.firingPoint);
        Instantiate(bulletPrefab, playerCtrl.firingPoint.position, playerCtrl.firingPoint.rotation);
    }

}
