using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastYelloPlanes : MonoBehaviour
{
    [SerializeField] private GameObject _yellowPlanePrefab; 
    private int _planeCount = 3;
    void Start()
    {
        StartCoroutine(CastPlanes());
    }

    public IEnumerator CastPlanes()
    {
        if (_planeCount > 0)
        {
            Instantiate(_yellowPlanePrefab, transform.position, _yellowPlanePrefab.transform.rotation);
            _planeCount--;
            yield return new WaitForSeconds(3f);
            yield return StartCoroutine(CastPlanes());
        }
    }
}
