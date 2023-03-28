using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SputnikWeapon : Weapon
{
    [SerializeField] private SputnikBehaviour _sputnikBehaviour;

    public int bulletsLeft = 2;
    void Start()
    {
        StartCoroutine(Shoot());
    }
    public override IEnumerator Shoot()
    {
        if (!_sputnikBehaviour.IsSpottedPlayer())
        {
            yield return new WaitUntil(() => _sputnikBehaviour.IsSpottedPlayer());
            StartCoroutine(Shoot());
        }
        else
        {
            if (bulletsLeft <= 0) yield break;
            Instantiate(BulletPrefab, transform.position, BulletPrefab.transform.rotation);
            bulletsLeft--;
            yield return new WaitForSeconds(10f);
            StartCoroutine(Shoot());
        }
    }
}
