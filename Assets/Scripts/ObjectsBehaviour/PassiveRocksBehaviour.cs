using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveRocksBehaviour : Entity
{
    [SerializeField] private float _lives = 60;
    [SerializeField] private Sprite _damagedRockSprite;
    public override void GetDamage(float damage)
    {
        _lives -= damage;
        Debug.Log(_lives);
        if (_lives <= 20)
        {
            GetComponent<SpriteRenderer>().sprite = _damagedRockSprite;
        }
        if (_lives <= 0)
        {
            Die();
        }
    }
}
