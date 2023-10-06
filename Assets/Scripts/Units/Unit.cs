using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitParameters _parameters;

    protected UnitParameters Parameters => _parameters;

    private int _health;
    private float _speed;

    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            OnHealthChange?.Invoke(_health);
        }
    }

    public float Speed
    {

        get => _speed;
        private set
        {
            _speed = value;
            OnSpeedChange?.Invoke(_speed);
        }
    }

    public event Action<int> OnHealthChange;
    public event Action<float> OnSpeedChange;
    public Action OnDeath;

    protected virtual void Awake()
    {
        Health = _parameters.Health;
        OnHealthChange += (h) => Die();
    }

    public virtual void TakeDamage(int amount)
    {
        if (_health - amount < 0)
            return;

        Health -= amount;
    }

    public virtual void AddHealth(int amount)
    {
        Health += amount;
    }

    public virtual void Die()
    {
        if (Health > 0)
            return;

        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        OnDeath = null;
    }
}
