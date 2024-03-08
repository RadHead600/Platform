using UnityEngine;

public class CharacterMouseWeaponRotate : MonoBehaviour
{
    [SerializeField] private RotateWeapon _rotateWeapon;
    [SerializeField] private CharacterWeapon _characterWeapon;

    private float _offset;

    public float Offset
    {
        get => _offset;
        set => _offset = value;
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _rotateWeapon.WeaponRotate(ref _offset, difference, _characterWeapon.Hand);
    }
}
