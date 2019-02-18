using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpComponent {
    float JumpForce { get; }

    void Jump(float jumpForce);
}
