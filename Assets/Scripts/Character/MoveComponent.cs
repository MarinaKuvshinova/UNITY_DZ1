using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour, IMoveComponent
{
    [SerializeField] float maxSpeed;
    new Rigidbody2D rigidbody2D;
    GroundDetection groundDetection;

    MovingPlatform movingPlatform; // ссылка на платформу, пытаемся получить ее в обработчике приземления
    public float MaxSpeed
    {
        get
        {
            return maxSpeed;
        }
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        groundDetection = GetComponent<GroundDetection>();

        // подписки на события GroundDetection
        groundDetection.GroundedEvent += GroundedEvent;
        groundDetection.AirborneEvent += GroundDetection_AirborneEvent;
    }

    private void GroundDetection_AirborneEvent()
    {
        movingPlatform = null;// если подпрыгнули, то обнуляем поле платформы
    }

    private void GroundedEvent(Collider2D obj)
    {
        // если приземлились, пытаемся получить у объекта, на который приземлились ссылку на класс платформы
        // если у этого объекта нет такого компонента, GetComponent вернет null
        movingPlatform = obj.GetComponent<MovingPlatform>(); 
    }
    public void Move(float direction, float speed)
    {
        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = direction * speed;
        if (movingPlatform != null)// если ссылка есть, добавляем скорость платформы персонажу
            velocity.x += movingPlatform.Velocity.x;
        rigidbody2D.velocity = velocity;
    }
}
