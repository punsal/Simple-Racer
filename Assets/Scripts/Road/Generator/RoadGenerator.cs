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

        [Header("Ending Road")]
        [SerializeField] private RoadController endingRoadController;
        
        [Header("Available Roads")]
        [SerializeField] private List<RoadController> roadControllers = new List<RoadController>();

        [Header("Generation")]
        [SerializeField] private int initialCount = 10;
        [SerializeField] private int levelCount = 3;
        #pragma warning restore 649

        private readonly Queue<RoadController> generatedRoads = new Queue<RoadController>();
        
        private Vector3 spawnPosition;
        private Quaternion spawnRotation;
        private RoadType nextRoadType;

        public void Generate(bool isOnce = false)
        {
            spawnPosition = Vector3.zero;
            spawnRotation = Quaternion.identity;
            
            for (var i = 0; i < (isOnce ? 1 : levelCount); i++)
            {
                SpawnRoad(startingRoadController);
                
                for (var j = 0; j < initialCount; j++)
                {
                    var nextRoad = roadControllers.FirstOrDefault(roadController => roadController.RoadType == nextRoadType);
                    if (SpawnRoad(nextRoad)) continue;

                    try
                    {
                        nextRoadType = generatedRoads.Peek().GetNextRoad(nextRoadType);
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                        nextRoadType = RoadType.DefaultForward;
                    }
                    j--;
                }

                SpawnRoad(endingRoadController);
            }
        }

        private bool SpawnRoad(RoadController roadController)
        {
            var tempRoad = Instantiate(roadController);
            var tempRoadTransform = tempRoad.transform;
            tempRoadTransform.position = spawnPosition;
            tempRoadTransform.rotation = spawnRotation;

            var expectedSpawnPosition = tempRoad.EndPosition;
            if (spawnPosition.z > expectedSpawnPosition.z)
            {
                Destroy(tempRoad.gameObject);
                return false;
            }

            generatedRoads.Enqueue(tempRoad);

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
            return true;
        }

        private void OnPlayerScored(int score)
        {
            if (score % (initialCount * 2) != 0) return;
            for (var i = 0; i < initialCount + 2; i++)
            {
                var temp = generatedRoads.Dequeue();
                Destroy(temp.gameObject);
            }
            
            Generate(true);
        }
    }
}
