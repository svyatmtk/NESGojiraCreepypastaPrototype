using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class YellowPlaneBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Rigidbody2D _yellowPlaneRB;
    private Vector2 _targetWay;
    private float _shift = 8f;

    public bool _hasBeenFounded;
    [Range(0,1)] public float _lerpCoefficient  = 0.5f;

    public void Awake()
    {
        _yellowPlaneRB = GetComponent<Rigidbody2D>();
        _targetWay = new Vector2(-10, 0);
    }

    void Start()
    {
        Moving();
    }

    void Update()
    {
        if (transform.position.x <= -20f)
        {
            Destroy(gameObject);
        }
    }

    private void Moving() => _yellowPlaneRB.velocity = _targetWay * _speed;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _hasBeenFounded = true;
            _yellowPlaneRB.velocity = new Vector2(_targetWay.x, _targetWay.y + _shift) * _speed ;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _targetWay = new Vector2(-20, -5);
            _yellowPlaneRB.velocity = _targetWay * (_speed * 0.5f);
            
        }
    }
}
