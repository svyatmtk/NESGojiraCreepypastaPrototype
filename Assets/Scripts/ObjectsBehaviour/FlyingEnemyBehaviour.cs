using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyBehaviour : MonoBehaviour
{
    private SpriteRenderer _flyingEnemySprite;
    private SpriteRenderer _playerSprite;
    

    public Transform PlayerTransform;
    public float YShift = 7f;
    public float Speed = 2f;

    public void Awake()
    {
        _flyingEnemySprite = GetComponent<SpriteRenderer>();
        _playerSprite = FindObjectOfType<PlayerController>().GetComponentInChildren<SpriteRenderer>();   
    }

    private void Update()
    {
        FlyingEnemyMove();
    }

    private void FlyingEnemyMove()
    {
        if (PlayerTransform == null) return;
        MoveToPlayer();
        SwitchFlip();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards
        (transform.position,
            new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + YShift, 0),
            Speed * Time.deltaTime);
    }

    private void SwitchFlip()
    {
        var direction = transform.position - PlayerTransform.position;
        _flyingEnemySprite.flipX = direction.x switch
        {
            > 0.05f => false,
            < -0.05f => true,
            0 => !_playerSprite.flipX,
            _ => _flyingEnemySprite.flipX
        };
    }
}
