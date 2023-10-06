using UnityEngine;

[CreateAssetMenu(fileName = "AttackParameters", menuName = "CustomParameters/AttackParameters")]
public class AttackParameters : ScriptableObject
{
    [SerializeField] private float _reloadTime;

    public float ReloadTime => _reloadTime;
}
