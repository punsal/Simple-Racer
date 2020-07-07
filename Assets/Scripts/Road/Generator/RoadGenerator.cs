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
        private RoadType nextRoadType;

        public void Generate()
        {
            spawnPosition = Vector3.zero + Vector3.down * 0.5f;

            SpawnRoad(startingRoadController);
            for (var i = 0; i < initialCount; i++)
            {
                var nextRoad = roadControllers.FirstOrDefault(roadController => roadController.RoadType == nextRoadType);
                SpawnRoad(nextRoad);
            }
        }

        private void SpawnRoad(RoadController roadController)
        {
            var temp = Instantiate(roadController);
            temp.transform.position = spawnPosition;
            generatedRoads.Add(temp.gameObject);

            try
            {
                nextRoadType = temp.GetNextRoad();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                nextRoadType = RoadType.DefaultForward;
            }
          
            spawnPosition = temp.EndPoint;
        }
    }
}
