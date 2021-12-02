using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour 
{ 

    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    
    void Start()
    {
    Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBala()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DereckMovement dereck = collision.GetComponent<DereckMovement>();
        DevianScript devian = collision.GetComponent<DevianScript>();
        if (dereck != null)
        {
            dereck.Hit();
        }
        if (devian != null)
        {
            devian.Hit();
        }
        DestroyBala();
    }
   
}
