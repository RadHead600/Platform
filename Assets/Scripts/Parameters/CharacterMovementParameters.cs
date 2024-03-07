using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMovementParameters", menuName = "CustomParameters/CharacterMovementParameters")]
public class CharacterMovementParameters : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private LayerMask _blockStay;

    public float Speed => _speed;
    public float Jump => _jump;
    public LayerMask BlockStay => _blockStay;
}
