using UnityEngine;

namespace Utility.Behaviour.Spawner
{
    public abstract class Spawner : MonoBehaviour
    {
        [Header("GameObject to Spawn")]
        #pragma warning disable 649
        [SerializeField] private GameObject prefab;
        #pragma warning restore 649

        protected GameObject SpawnedGameObject;
        
        public void Spawn()
        {
            SpawnedGameObject = Instantiate(prefab);
            OnSpawn();
        }

        public void Spawn(GameObject gameObjectPrefab)
        {
            SpawnedGameObject = Instantiate(gameObjectPrefab);
            OnSpawn();
        }

        protected abstract void OnSpawn();
    }
}