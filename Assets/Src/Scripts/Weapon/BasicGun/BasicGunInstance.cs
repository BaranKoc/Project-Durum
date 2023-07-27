using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGunInstance : WeaponInstance
{
    public override void whenMultiTab()
    {
        Debug.Log("MultiTab");
    }
    public override void whenPress()
    {
        Debug.Log("Press");
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
}
