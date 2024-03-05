using UnityEngine;

[CreateAssetMenu(fileName = "RangeActiveParameters", menuName = "CustomParameters/RangeActiveParameters")]
public class RangeActiveParameters : ScriptableObject
{
    [SerializeField] private float _activeRange;
    [SerializeField] private LayerMask _entityLayer;
    [SerializeField] private float _onTriggerWaitTime = 0.5f;

    public float ActiveRange => _activeRange;
    public LayerMask EntityLayer => _entityLayer;
    public float OnTriggerWaitTime => _onTriggerWaitTime;
}
