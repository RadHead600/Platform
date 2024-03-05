using UnityEngine;

[CreateAssetMenu(fileName = "WeaponParameters", menuName = "CustomParameters/WeaponParameters")]
public class WeaponParameters : ScriptableObject
{
    [SerializeField] private ResourcesBullet _resourcesBullet;
    [SerializeField] private float _rechargeTime;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _bulletInmagazine;
    [SerializeField] private int _minBulletInMagazine = 0;
    [SerializeField] private float _delay;
    [SerializeField] private float _spread;

    public ResourcesBullet ResourcesBullet => _resourcesBullet;
    public float RechargeTime => _rechargeTime;
    public int Damage => _damage;
    public float Speed => _speed;
    public int BulletInmagazine => _bulletInmagazine;
    public int MinBulletInMagazine => _minBulletInMagazine;
    public float Delay => _delay;
    public float Spread => _spread;
}
