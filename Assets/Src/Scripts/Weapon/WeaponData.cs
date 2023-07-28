using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class WeaponData : MonoBehaviour
{
    public Transform firingPoint;

    
    public string WeaponName;

    [TextAreaAttribute]
    public string description;

    public WeaponType weaponType;
    public GripType gripType;
}
