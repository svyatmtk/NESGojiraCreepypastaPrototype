using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyWeapons : Weapon
{
    public GameObject[] shootingPoints;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    public override IEnumerator Shoot()
    {
        while (true)
        {
            foreach (var shootingPoint in shootingPoints)
            {
                Instantiate(BulletPrefab, shootingPoint.transform.position, BulletPrefab.transform.rotation);
                yield return new WaitForSeconds(1f);
            }
        }
    }

}
