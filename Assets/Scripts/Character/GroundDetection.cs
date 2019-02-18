using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundDetection : MonoBehaviour {
    public event Action<Collider2D> GroundedEvent;
    public event Action AirborneEvent;

    public bool IsGrounded { get { return ground!=null; } }

    [SerializeField] LayerMask layerMask;
    [SerializeField] Vector2 overlapSize = new Vector2(1, 0.2f);

    Collider2D ground;
    void Update () {
        Vector2 overlapCenter = transform.position + Vector3.down * (0.5f + overlapSize.y / 2);
        Collider2D newGround = Physics2D.OverlapBox(overlapCenter, overlapSize, 0, layerMask);
        if (ground == null) {
            if (newGround != null) {
                ground = newGround;
                if (GroundedEvent != null) {
                    GroundedEvent(ground);
                }
            }
        }
        else if (ground!=null) {
            if (newGround == null)
            {
                Collider2D tmp = ground;
                ground = null;
                if (AirborneEvent != null) {
                    AirborneEvent();
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        //подсказка єлемента 
    }
    private void OnDrawGizmosSelected()
    {
        Vector2 overlapCenter = transform.position + Vector3.down * (0.5f + overlapSize.y / 2);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(overlapCenter, overlapSize);
    }

}
