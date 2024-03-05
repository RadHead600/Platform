using UnityEngine;

public class ArmorPiercingBullets : Bullet
{
    [SerializeField] private float _bulletLifeTime = 5;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, Speed * Time.deltaTime);
    }

    protected new void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Unit unit))
        {
            unit.ReceiveDamage(Damage);

            if (unit.CompareTag("Head"))
            {
                unit.ReceiveDamage(Damage);
            }
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, Blocks);

        if (colliders.Length > 0.8F)
            Destroy(gameObject);
    }

    protected override void DestroyBullet()
    {
        Destroy(gameObject, _bulletLifeTime);
    }
}
