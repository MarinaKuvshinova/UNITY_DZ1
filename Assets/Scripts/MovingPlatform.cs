using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] GameObject platform;
    //   new Rigidbody2D rigidbody2D;
    [SerializeField] Transform currentPoint;
    [SerializeField] Transform[] points;
    int pointSelection = 0;

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public Vector2 Velocity // свойство позволит добраться до приватного поля
    {
        get { return currentVelocity; }
    }
    Vector2 currentVelocity; // поле для сохранения вычисленной скорости платформы
    // Use this for initialization
    void Start()
    {
        currentPoint = points[pointSelection];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dirToPoint = currentPoint.position - transform.position; // определяем направление от положения платформы к цели (следующей точке)
        dirToPoint.Normalize(); // привели вектор направления к единичному (его длина теперь 1 метр)
        currentVelocity = dirToPoint * speed; // добавили в вектор направления информацию о скорости

        platform.transform.position = Vector2.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * speed);
        if (platform.transform.position == currentPoint.position)
        {
            pointSelection++;
            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }
            currentPoint = points[pointSelection];
        }
    }






}
