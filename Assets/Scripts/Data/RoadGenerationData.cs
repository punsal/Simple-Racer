using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Road Generation Data", menuName = "Data/Road Generation Data", order = 0)]
    public class RoadGenerationData : ScriptableObject
    {
        public int scorePerLevel = 15;
        public int levelBatchBuffer = 3;
    }
}