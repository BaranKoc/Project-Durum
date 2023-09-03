using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGunInstance : RangedWeaponInstance
{   
    public GameObject AimBox;

    public GameObject ShootBox;

    private Color green = new Color(0,255,0,1);
    private Color red = new Color(255,0,0,1);


   public override void Aim()
    {
        SpriteRenderer AimBoxRenderer = AimBox.GetComponent<SpriteRenderer>();
        AimBoxRenderer.color = green;
    }
    public override void AimInputCancelled()
    {
        SpriteRenderer AimBoxRenderer = AimBox.GetComponent<SpriteRenderer>();
        AimBoxRenderer.color = red;
    }


    public override void Shoot()
    {
        SpriteRenderer ShootBoxRenderer = ShootBox.GetComponent<SpriteRenderer>();
        ShootBoxRenderer.color = green;
    }
    public override void ShootInputCancelled()
    {
        SpriteRenderer ShootBoxRenderer = ShootBox.GetComponent<SpriteRenderer>();
        ShootBoxRenderer.color = red;
    }
}
