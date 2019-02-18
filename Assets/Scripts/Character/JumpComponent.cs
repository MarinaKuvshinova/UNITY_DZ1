using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : MonoBehaviour, IJumpComponent {
    [SerializeField] float jumpForce = 10f;
    new Rigidbody2D rigidbody2D;
    public float JumpForce
    {
        get
        {
            return jumpForce;
        }
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Jump(float jumpForce)
    {
        Vector2 velocity = rigidbody2D.velocity;
        velocity.y = jumpForce;
        rigidbody2D.velocity = velocity;
    }
   
}
