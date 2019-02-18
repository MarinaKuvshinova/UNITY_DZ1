using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
    void Hit(float damageAmount);
}
public class WallComponent : MonoBehaviour, IHitable
{
    float hp = 100f;
    public void Hit(float damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
            Destroy(gameObject);
    }
}
