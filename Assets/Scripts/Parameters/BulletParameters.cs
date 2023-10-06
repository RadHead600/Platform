using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "CustomParameters/Bullet")]
public class BulletParameters : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _enemylayer;
    [SerializeField] private float _lifeTime;

    public int Damage => _damage;
    public float Speed => _speed;
    public LayerMask Enemylayer => _enemylayer;
    public float LifeTime => _lifeTime;
}
