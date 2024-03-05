using UnityEngine;

public class HelicopterMachineGun : Enemy
{
    [SerializeField] private GameObject _machineGun;
    [SerializeField] private RotateWeapon _rotateWeapon;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _speed;

    private float _offset;
    private Vector3 _difference;
    private Character _character;

    private void Start()
    {
        if (_character == null)
            _character = FindObjectOfType<Character>();
    }

    private void FixedUpdate()
    {
        _difference = _character.transform.position - _machineGun.transform.position;
        _rotateWeapon.WeaponRotate(ref _offset, _difference, _machineGun);
    }

    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
    }

    public override int ReceiveDamage(int damage)
    {
        HP -= damage;

        if (HP <= MinHp)
            Die();

        return HP;
    }

}
