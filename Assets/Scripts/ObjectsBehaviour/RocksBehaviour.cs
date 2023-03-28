using UnityEngine;

public class RocksBehaviour : Entity
{
    [SerializeField] private float _lives = 100;
    [SerializeField] private float _viewingDistance = 0.8f;
    [SerializeField] private Transform _castPosition;

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
        Debug.Log(_lives);
        if (_lives <= 0)
        {
            Die();
        }
    }
}
