using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask _blocks;
    [SerializeField] protected float _bulletLifeTime = 10;

    public float Speed { get => _speed; set => _speed = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public Vector3 Direction { get => _direction; set => _direction = value; }
    public LayerMask Blocks => _blocks;

    private Vector3 _direction;
    private float _speed;
    private int _damage;

    private void Start()
    {
        DestroyBullet();
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Unit unit))
        {
            unit.ReceiveDamage(_damage);
            Destroy(gameObject);
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, _blocks);
        if (colliders.Length > 0.8F)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void DestroyBullet()
    {
        Destroy(gameObject, _bulletLifeTime);
    }
}
