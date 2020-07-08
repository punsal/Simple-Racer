using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Road.Generator
{
    public class RoadController : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField] private RoadType roadType;

        [SerializeField] private Transform endPoint;
        
        [Header("Generation Constraints")]
        [SerializeField] private List<RoadType> nextRoads;
#pragma warning restore 649

        public RoadType RoadType => roadType;

        public Vector3 EndPosition => endPoint.position;
        public Quaternion EndRotation => endPoint.rotation;
        
        public RoadType GetNextRoad()
        {
            if (nextRoads.Count < 1)
            {
                throw new Exception($"{gameObject.name} prefab does not have next roads.");
            }

            var randomRoad = nextRoads[Random.Range(0, nextRoads.Count)];
            return randomRoad;
        }

        public RoadType GetNextRoad(RoadType excludeRoadType)
        {
            if (nextRoads.Count < 1)
            {
                throw new Exception($"{gameObject.name} prefab does not have next roads.");
            }

            var excludedNextRoads = nextRoads;
            var excludeIndex = 0;
            for (var i = 0; i < nextRoads.Count; i++)
            {
                if (excludedNextRoads[i] != excludeRoadType) continue;
                excludeIndex = i;
                break;
            }
            excludedNextRoads.RemoveAt(excludeIndex);

            if (excludedNextRoads.Count < 1)
            {
                throw new Exception($"{gameObject.name} prefab does not have next roads.");
            }

            var randomRoad = nextRoads[Random.Range(0, nextRoads.Count)];
            return randomRoad;
        }
    }
}