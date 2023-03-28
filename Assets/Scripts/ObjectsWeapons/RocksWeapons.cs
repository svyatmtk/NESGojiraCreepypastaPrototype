using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksWeapons : Weapon
{
    [SerializeField] private RocksBehaviour _rocksBehaviour;

    public int bulletsLeft = 4;
    void Start()
    {
        StartCoroutine(Shoot());
    }
    public override IEnumerator Shoot()
    {
        if (!_rocksBehaviour.IsSpottedPlayer())
        {
            yield return new WaitUntil(() => _rocksBehaviour.IsSpottedPlayer());
            StartCoroutine(Shoot());
        }
        else
        {
            if (bulletsLeft <= 0) yield break;
            Instantiate(BulletPrefab, transform.position, BulletPrefab.transform.rotation);
            Instantiate(BulletPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), BulletPrefab.transform.rotation);
            bulletsLeft--;
            yield return new WaitForSeconds(10f);
            StartCoroutine(Shoot());
        }
    }
}
