using UnityEngine;

public class EnemyParameters : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;

    public LayerMask EnemyLayer => _enemyLayer;
}
