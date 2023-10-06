using UnityEngine;

[CreateAssetMenu(fileName = "UnitParameters", menuName = "CustomParameters/Units/Unit")]
public class UnitParameters : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    public int Health => _health;
    public float Speed => _speed;
}
