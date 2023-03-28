using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon:MonoBehaviour
{
    public Transform ShootingPoint;
    public GameObject BulletPrefab;

    public virtual IEnumerator Shoot()
    {
        yield return null;
    }
}