using System.Collections;
using UnityEngine;

public class ExplosiveBullets : Bullet, IGrounded
{
    [SerializeField] private float _radius;
    [SerializeField] private float _bulletLifeTime = 10;
    [SerializeField] private float _bulletDestroyLifeTime = 3;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Sprite _switchSprite;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _circleCollider2D;
    [SerializeField] private CapsuleCollider2D _capsuleCollider2D;

    private const float GROUND_RADIUS = 0.2f;

    public float Offset
    {
        get => offset;
        set => offset = value;
    }

    private float offset;

    private bool stopRun = false;

    private void Start()
    {
        Destroy(gameObject, _bulletLifeTime);
    }

    private void Update()
    {
        if (!stopRun)
        {
            _particleSystem.Play(false);
            Vector3 position = transform.position; 
            position.z = 20.0f;

            transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, Speed * Time.deltaTime);

            if (Direction.x > 0)
            {
                Vector3 left_turn_bullet = new Vector3(0, 0, -430f);
                Turn(left_turn_bullet, true);
            }
            else
            {
                Vector3 right_turn_bullet = new Vector3(0, 0, 70f);
                Turn(right_turn_bullet, false);
                transform.rotation = Quaternion.Euler(0, 0, -0.5f);
            }
        }

        Grounded();
    }

    private void Turn(Vector3 turnBullet, bool isFlipWeapon)
    {
        _spriteRenderer.flipX = isFlipWeapon;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(turnBullet), Time.deltaTime);
    }

    public virtual void Grounded()
    {
        Vector3 position = transform.position; 
        position.x = -1.0f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GROUND_RADIUS, Blocks);

        if (colliders.Length > 0.8F)
        {
            stopRun = true;
            _rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            CreateExplosion();
            Destroy(gameObject, _bulletDestroyLifeTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Unit unit))
        {
            unit.ReceiveDamage(Damage);
        }
    }

    protected void CreateExplosion()
    {
        _particleSystem.Play(true);
        _capsuleCollider2D.enabled = false;
        _circleCollider2D.radius = 0;
        _circleCollider2D.isTrigger = true;
        _spriteRenderer.sprite = _switchSprite;
        transform.rotation = Quaternion.Euler(0, 0, -180);
        StartCoroutine(ExplosionExpansion());
    }

    private IEnumerator ExplosionExpansion()
    {
        float waitingTime = 0.009f;
        for (float q = 1f; q < _radius; q += .1f)
        {
            _spriteRenderer.transform.localScale = new Vector3(q, q, 1);
            _circleCollider2D.radius = q;
            yield return new WaitForSeconds(waitingTime);
        }
    }
}
