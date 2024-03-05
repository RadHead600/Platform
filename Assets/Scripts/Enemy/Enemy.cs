using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _points;

    public int Damage { get => _damage; set => _damage = value; }
    public int Points => _points;

    private int _damage;

    public const float IMPULS_UP_DEFAULT = 2;

    public override int ReceiveDamage(int damage)
    {
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.AddForce(transform.up * IMPULS_UP_DEFAULT, ForceMode2D.Impulse);
        HP -= damage;

        if (HP <= MinHp)
            Die();

        return HP;
    }

    public override void Die()
    {
        SaveParameters.levelPoints[SaveParameters.levelActive] += _points;
        Destroy(gameObject);
    }
}
