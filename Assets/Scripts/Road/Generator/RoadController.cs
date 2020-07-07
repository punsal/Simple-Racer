using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Road.Generator
{
    public class RoadController : MonoBehaviour
    {
        [SerializeField] private RoadType roadType;

        [SerializeField] private Transform endPoint;
        
        [Header("Generation Constraints")]
        [SerializeField] private List<RoadType> nextRoads;

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
    }
}