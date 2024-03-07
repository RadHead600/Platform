using UnityEngine;

public class CharacterMouseAttack : MonoBehaviour
{
    [SerializeField] private CharacterAttack _characterAttack;
    [SerializeField] private Character _character;
    [SerializeField] private CharacterMouseWeaponRotate _weaponRotate;
    [SerializeField] private CharacterWeapon _characterWeapon;
    [SerializeField] private CharacterStatsUI _characterStatUI;

    private Coroutine _attackCoroutine;
    private Vector3 _difference;
    private const int ATTACK_MOUSE_BUTTON = 0;

    private void Start()
    {
        _characterWeapon.Weapon.BulletInMagazine = _characterWeapon.Weapon.WeaponParameters.BulletInmagazine;
        _characterStatUI.ChangeText(_characterStatUI.BulletsText, _characterWeapon.Weapon.BulletInMagazine.ToString());
        _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        if (Input.GetMouseButton(ATTACK_MOUSE_BUTTON))
        {
            _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (_characterAttack.isAttackEnd)
            {
                _attackCoroutine = StartCoroutine(_characterAttack.Attack(_difference, _weaponRotate.Offset, _characterWeapon));
                _characterStatUI.ChangeText(_characterStatUI.BulletsText, _characterWeapon.Weapon.BulletInMagazine.ToString());
            }
        }
#endif
    }
}
