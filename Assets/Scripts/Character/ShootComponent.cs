using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour, IShootComponent {
    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] float bulletSpeed = 20f;

    public void Shoot(int direction) {
        Rigidbody2D bulletInst = Instantiate(bulletPrefab, transform.position + new Vector3(0 + direction * 0.1f, 0, 0), Quaternion.identity);
        bulletInst.velocity = Vector2.right * bulletSpeed * direction;

    }

}
