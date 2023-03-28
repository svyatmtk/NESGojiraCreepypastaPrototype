using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SputnikBehaviour : Entity
{
    [SerializeField] private float _viewingDistance = 0.8f;
    [SerializeField] private Transform _castPosition;
    [SerializeField] private float _lives = 40f;

    void Update()
    {
        IsSpottedPlayer();
    }

    public bool IsSpottedPlayer()
    {
        var isSpotted = false;
        var castDist = _viewingDistance;

        var endPoint = _castPosition.position + Vector3.right * -(castDist);

        var hitPlayer = Physics2D.Linecast(_castPosition.position, endPoint, 1 << LayerMask.NameToLayer("Action"));

        if (hitPlayer.collider != null)
        {
            if (hitPlayer.collider != null && hitPlayer.collider.gameObject.CompareTag("Player"))
            {
                isSpotted = true;
                Debug.DrawLine(_castPosition.position, hitPlayer.point, Color.red);
            }
        }
        else
        {
            Debug.DrawLine(_castPosition.position, endPoint, Color.green);
        }
        return isSpotted;
    }

    public override void GetDamage(float damage)
    {
        _lives -= damage;
        if( _lives <= 0 )
            Die();
    }
}
