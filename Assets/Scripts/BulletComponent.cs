using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour {
    public float damage = 25f;
    float time;

	// Use this for initialization
	void Start () {
        //Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 5f) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        IHitable hitable = collision.collider.GetComponent<IHitable>();
        if (hitable != null) hitable.Hit(damage);
    }
}
