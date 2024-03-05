using UnityEngine;

public class EnemyDropShild : Enemy
{
    [SerializeField] private GameObject _shild;

    public override void Die()
    {
        Instantiate(_shild, gameObject.transform.position, _shild.transform.rotation);
        Destroy(gameObject);
    }
}
