using UnityEngine;

public class Bullet : MonoBehaviour, IMove
{
    [SerializeField] private BulletParameters _bulletParameters;

    public int Damage {  get; set; }

    private void Awake()
    {
        Destroy(gameObject, _bulletParameters.LifeTime);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += transform.right * _bulletParameters.Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer & (1 << _bulletParameters.Enemylayer)) != 0)
            collision.gameObject.GetComponent<Unit>().TakeDamage(_bulletParameters.Damage);
    }
}
