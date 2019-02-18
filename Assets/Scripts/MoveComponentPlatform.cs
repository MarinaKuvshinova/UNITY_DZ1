using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponentPlatform : MonoBehaviour {
    bool dirRight = true;
    public float speed = 1f;
    public Transform block1;
    public Transform block2;

    // Use this for initialization
    void Start () {
	}

    void Update() {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
        if (transform.position.x >= block2.position.x - block2.right.x) {
            dirRight = false;
        }
        if (transform.position.x <= block1.position.x + block1.right.x)
        {
            dirRight = true;
        }

        //transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1f));
        //transform.Rotate(Vector3.up * 10f * Time.deltaTime);
    }
}
