using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour
{
    bool isGrounded;

    IMoveComponent moveComponent;
    IJumpComponent jumpComponent;
    IShootComponent shootComponent;
    GroundDetection groundDetection;
    int direction = 1;
    void Start()
    {
        moveComponent = GetComponent<IMoveComponent>();
        jumpComponent = GetComponent<IJumpComponent>();
        shootComponent = GetComponent<IShootComponent>();
        groundDetection = GetComponent<GroundDetection>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float hInput = Input.GetAxis("Horizontal");
        if (hInput != 0)
            direction = (int)Mathf.Sign(hInput);

        moveComponent.Move(hInput, moveComponent.MaxSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && groundDetection.IsGrounded)
            jumpComponent.Jump(jumpComponent.JumpForce);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            shootComponent.Shoot(direction);
        }

    }
}
