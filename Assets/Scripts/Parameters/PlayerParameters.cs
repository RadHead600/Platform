using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "CustomParameters/Units/PlayerParameters")]
public class PlayerParameters : UnitParameters
{
    [SerializeField] private float _jump;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundDistanceTrigger;

    public float Jump => _jump;
    public LayerMask GroundLayer => _groundLayer;
    public float GroundDistanceTrigger => _groundDistanceTrigger;
}
