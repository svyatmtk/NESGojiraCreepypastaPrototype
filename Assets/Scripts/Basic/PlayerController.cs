using System.Collections;
using UnityEngine;

public enum States
{
    Idle,
    Run,
    Jump,
    Attack
}


public class PlayerController : Entity
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _lives = 200;
    [SerializeField] private float _jumpForce = 4;
    private bool _isGrounded;
    private bool _isAttacking;
    public LayerMask Enemy;
    private Animator _animation;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;


    public Transform AttackPosition;
    public float AttackRange;
    public GameObject ShootPoint;


    public static PlayerController Instance { get; set; }


    public States StateSet
    {
        get => (States)_animation.GetInteger("state");

        set => _animation.SetInteger("state", (int)value);
    }

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animation = GetComponent<Animator>();
        Instance = this;
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if (_isGrounded && !_isAttacking)
        {
            StateSet = States.Idle;
        }

        if (Input.GetButton("Horizontal") && !_isAttacking)
        {
            Run();
        }

        if (_isGrounded && Input.GetButtonDown("Jump") && !_isAttacking)
        {
            OnGroundCheck();
            Jump();
        }

        if (Input.GetButtonDown("Fire1") && !_isAttacking)
        {
            Attack();
        }
    }

    public void FixedUpdate()
    {
        OnGroundCheck();
    }

    public void Run()
    {
        if (_isGrounded)
        {
            StateSet = States.Run;
        }

        var direction = transform.right * Input.GetAxis("Horizontal");
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
        switch (direction.x)
        {
            case < 0 when !_spriteRenderer.flipX:
            case > 0 when _spriteRenderer.flipX:
                Flip();
                break;
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void OnGroundCheck()
    {
        if (!_isGrounded)
        {
            StateSet = States.Jump;
        }

        var overlapCircleAll = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        _isGrounded = overlapCircleAll.Length > 1;
    }

    public void Attack()
    {
        StateSet = States.Attack;
        _isAttacking = true;
        StartCoroutine(AttackCoolDown());
    }

    public void OnAttack()
    {
        var colliders = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRange, Enemy);

        foreach (var t in colliders)
        {
            t.GetComponent<Entity>().GetDamage(20f);
        }
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.4f);
        _isAttacking = false;
    }

    public override void GetDamage(float damage)
    {
        _lives -= damage;

        if (_lives <= 0)
        {
            Die();
            _gameManager.GameOverScreen();
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, AttackRange);
    }

    public void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        ShootPoint.transform.Rotate(0f, 180f, 0f);
    }
}