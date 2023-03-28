using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleYellowPlaneWeapon : Weapon
{
    [SerializeField] private YellowPlaneBehaviour yellowPlane;
    private int _bulletsLeft = 2;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    public override IEnumerator Shoot()
    {
        while (_bulletsLeft > 0)
        {
            if (yellowPlane._hasBeenFounded)
            {
                Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
                _bulletsLeft--;
                yield return new WaitForSeconds(0.4f);
            }
            yield return null;
        }
    }
}


