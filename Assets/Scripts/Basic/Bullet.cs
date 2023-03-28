using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20f;
    public float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    private Vector2 moveDirection;

    public void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        if (PlayerController.Instance != null)
        {
            moveDirection = (PlayerController.Instance.transform.position - transform.position).normalized * speed;
        }
        _rigidbody2D.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.GetDamage(damage);
            Destroy(gameObject);
        }
    }

}
