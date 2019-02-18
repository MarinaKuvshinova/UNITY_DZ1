using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float speed = 7f;
    [SerializeField] Vector3 offset;
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime*speed);
	}
}
