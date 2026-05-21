using UnityEngine;

namespace SalvageCrew.Data
{
    [CreateAssetMenu(menuName = "SalvageCrew/Difficulty Profile", fileName = "Difficulty_")]
    public class DifficultyProfile : ScriptableObject
    {
        [Range(0f, 10f)] public float oxygenDrainPerSec = 0.25f;
        [Range(0.1f, 5f)] public float hazardTickMultiplier = 1f;
        [Range(0.5f, 3f)] public float scripMultiplier = 1f;
    }
}
