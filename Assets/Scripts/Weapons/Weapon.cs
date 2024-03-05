using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _posAttack;
    [SerializeField] private WeaponParameters _weaponParameters;
    [SerializeField] private int _takeBulletCountFromMagazine = 1;

    public WeaponParameters WeaponParameters => _weaponParameters;
    public int BulletInMagazine
    {
        get => _bulletInMagazine;
        set => _bulletInMagazine = value;
    }
    
    private int _bulletInMagazine;
    private Bullet _bullet;

    private void Start()
    {
        _bullet = Resources.Load<Bullet>("BulletPrefabs/" + _weaponParameters.ResourcesBullet.ToString());
    }

    public virtual void Attack(Vector3 difference)
    {
        CreateBullet(difference);
        TakeBulletOutMagazine(_takeBulletCountFromMagazine);
    }

    private Bullet CreateBullet(Vector3 difference)
    {
        var newBullet = Instantiate(_bullet, _posAttack.transform.position, _posAttack.transform.rotation);
        newBullet.Speed = _weaponParameters.Speed;
        newBullet.Damage = _weaponParameters.Damage;
        newBullet.Direction = newBullet.transform.right * (difference.x < 0 ? -1 : 1);
        return newBullet;
    }

    public int TakeBulletOutMagazine(int quantity)
    {
        return _bulletInMagazine -= quantity;
    }
}

public enum ResourcesBullet
{
    StandartBullet,
    StandartBulletEnemy,
    ArmorPiercingBullet,
    ArmorPiercingBulletEnemy,
    ExplosiveBullet,
    ExplosiveBulletEnemy,
    Missiles,
    Missilesenemy
}

