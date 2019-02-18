using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveComponent {
    float MaxSpeed { get; }
    void Move(float direction, float speed);
}
