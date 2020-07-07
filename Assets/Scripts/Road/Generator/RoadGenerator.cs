using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Road.Generator
{
    public class RoadGenerator : MonoBehaviour
    {
        #pragma warning disable 649
        [Header("Starting Road")]
        [SerializeField] private RoadController startingRoadController;
        
        [Header("Available Roads")]
        [SerializeField] private List<RoadController> roadControllers = new List<RoadController>();

        [Header("Generation")]
        [SerializeField] private int initialCount = 10;
        #pragma warning restore 649

        private List<GameObject> generatedRoads = new List<GameObject>();
        private Vector3 spawnPosition;
        private Quaternion spawnRotation;
        private RoadType nextRoadType;

        public void Generate()
        {
            spawnPosition = Vector3.zero;
            spawnRotation = Quaternion.identity;

            SpawnRoad(startingRoadController);
            for (var i = 0; i < initialCount; i++)
            {
                var nextRoad = roadControllers.FirstOrDefault(roadController => roadController.RoadType == nextRoadType);
                SpawnRoad(nextRoad);
            }
        }

        private void SpawnRoad(RoadController roadController)
        {
            var tempRoad = Instantiate(roadController);
            var tempRoadTransform = tempRoad.transform;
            tempRoadTransform.position = spawnPosition;
            tempRoadTransform.rotation = spawnRotation;
            generatedRoads.Add(tempRoad.gameObject);

            try
            {
                nextRoadType = tempRoad.GetNextRoad();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                nextRoadType = RoadType.DefaultForward;
            }
          
            spawnPosition = tempRoad.EndPosition;
            spawnRotation = tempRoad.EndRotation;
        }
    }
}
