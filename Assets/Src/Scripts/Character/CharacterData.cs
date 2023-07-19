using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [Header("Health Settings")]
    public float DEFAULT_Health;

    [HideInInspector] public float CURRENT_Health;


    [Header("Movement Settings")]
    public float DEFAULT_MovementSpeed;
    public float DEFAULT_RotationSpeed;

    [HideInInspector] public float CURRENT_MovementSpeed;
    [HideInInspector] public float CURRENT_RotatoinSpeed;

    public CharacterData()
    {
        CURRENT_Health = DEFAULT_Health;

        CURRENT_MovementSpeed = DEFAULT_MovementSpeed;
        CURRENT_RotatoinSpeed = DEFAULT_RotationSpeed;
    }
}
