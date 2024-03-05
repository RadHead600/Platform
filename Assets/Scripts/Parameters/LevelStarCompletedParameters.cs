using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelStarCompletedParameters", menuName = "CustomParameters/LevelStarCompletedParameters")]
public class LevelStarCompletedParameters : ScriptableObject
{
    [SerializeField] private List<float> _completedStarPercent;

    public List<float> CompletedStarPercent => _completedStarPercent;
}
