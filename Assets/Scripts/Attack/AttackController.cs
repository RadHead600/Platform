using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour, IAttack
{
    [SerializeField] private AttackParameters _attackParameters;
    [SerializeField] private Bullet _bullet;

    public Bullet Bullet
    {
        get => _bullet;
        set => _bullet = value;
    }

    private bool _isAttacked;

    public IEnumerator StartAttack()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        _isAttacked = true;
        yield return new WaitForSeconds(_attackParameters.ReloadTime);
        _isAttacked = false;
    }

    public void Attack()
    {
        if (!_isAttacked)
            StartCoroutine(StartAttack());
    }
}
