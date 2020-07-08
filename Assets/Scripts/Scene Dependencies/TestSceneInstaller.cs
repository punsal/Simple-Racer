using Data;
using UnityEngine;
using Zenject;

namespace Scene_Dependencies
{
    public class TestSceneInstaller : MonoInstaller
    {
        #pragma warning disable 649
        [Header("Data")]
        [SerializeField] private PlayerData playerData;
        [SerializeField] private GameData gameData;
        [SerializeField] private RoadGenerationData roadGenerationData;
        #pragma warning restore 649
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().FromScriptableObject(playerData).AsCached();
            Container.Bind<GameData>().FromScriptableObject(gameData).AsCached();
            Container.Bind<RoadGenerationData>().FromScriptableObject(roadGenerationData).AsCached();
        }
    }
}