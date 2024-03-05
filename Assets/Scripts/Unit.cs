using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private int _minHp = 0;
    [SerializeField] private int _hp;

    public virtual int HP
    {
        get => _hp;
        set => _hp = value;
    }
    public int MinHp => _minHp;

    public virtual int AddHealth(int amount)
    {
        HP += amount;
        return HP;
    }

    public virtual int ReceiveDamage(int damage)
    {
        _hp -= damage;
        
        if (HP <= _minHp)
        {
            Die();
        }

        return HP;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
