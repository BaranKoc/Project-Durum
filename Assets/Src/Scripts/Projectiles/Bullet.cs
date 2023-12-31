using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1,100)]
    [SerializeField] private float speed;


    [Range(1,10)]
    [SerializeField] private float lifeTime;


    private Rigidbody2D rb;


    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);    
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
