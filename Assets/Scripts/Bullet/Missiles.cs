    using UnityEngine;

public class Missiles : ExplosiveBullets, IGrounded
{
    [SerializeField] private float _bulletLifeTime = 10;
    [SerializeField] private float _bulletDestroyLifeTime = 3;

    private bool _stopRun;

    private const float GROUND_RADIUS = 0.8f;

    private void Start()
    {
        Destroy(gameObject, _bulletLifeTime);
    }

    private void Update()
    {
        if (_stopRun)
            return;

        Vector3 position = transform.position; 
        position.z = 20.0F;
        transform.position = Vector3.MoveTowards(transform.position, (transform.position - Direction), Speed * Time.deltaTime);
        Grounded();
    }

    public override void Grounded()
    {
        Vector3 position = transform.position; 
        position.x = -1.0F;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GROUND_RADIUS, Blocks);

        if (colliders.Length > 0.8F)
        {
            _stopRun = true;
            CreateExplosion();
            Destroy(gameObject, _bulletDestroyLifeTime);
        }
    }
}
