using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKnifeInstance : MeleeWeaponInstance
{
    public GameObject MeleeAttackBox;

    private Color green = new Color(0,255,0,1);
    private Color red = new Color(255,0,0,1);

    public override void MeleeAttack()
    {
        SpriteRenderer MeleeAttackBoxRenderer = MeleeAttackBox.GetComponent<SpriteRenderer>();
        MeleeAttackBoxRenderer.color = green;
    }
    public override void MeleeAttackInputCancelled()
    {
        SpriteRenderer MeleeAttackBoxRenderer = MeleeAttackBox.GetComponent<SpriteRenderer>();
        MeleeAttackBoxRenderer.color = red;
    }
}
