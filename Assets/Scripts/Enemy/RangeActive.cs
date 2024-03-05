using System.Collections;
using UnityEngine;

public class RangeActive : MonoBehaviour
{
    [SerializeField] private Transform _activePos;
    [SerializeField] private RangeActiveParameters _rangeParameters;
    [SerializeField] private EnemyAttack _enemyAttack;

    private WaitForSeconds _wait;
    private const int MIN_COUNT_ENEMY_TRIGGER = 1;

    private void Awake()
    {
        _wait = new WaitForSeconds(_rangeParameters.OnTriggerWaitTime);
    }

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_activePos.position, _rangeParameters.ActiveRange, _rangeParameters.EntityLayer);
        bool isTriggerEnemies = enemies.Length >= MIN_COUNT_ENEMY_TRIGGER;
        _enemyAttack.enabled = isTriggerEnemies;
        yield return _wait;
        StartCoroutine(Attack());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_activePos.position, _rangeParameters.ActiveRange);
    }

}
