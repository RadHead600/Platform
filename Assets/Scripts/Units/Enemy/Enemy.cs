using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private AttackController _attackController;
    [SerializeField] private EnemyParameters _enemyParameters;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer & (1 << _enemyParameters.EnemyLayer)) != 0)
        {
            _attackController.Attack();
        }
    }
}
