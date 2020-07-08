using Car;
using Controllers;
using Data;
using Road.Generator;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    #pragma warning disable 649
    [SerializeField] private RoadGenerator roadGenerator;
    #pragma warning restore 649

    private GameData gameData;
    
    private void Start()
    {
        roadGenerator.Generate();
    }

    [Inject]
    // ReSharper disable once ParameterHidesMember
    private void Construct(GameData gameData)
    {
        this.gameData = gameData;
    }

    public void StartGame()
    {
        gameData.ChangeGameState(GameState.GamePlay);
    }

    public void Retry()
    {
        gameData.ChangeGameState(GameState.GameStart);
        SceneManager.LoadScene(0);
    }
    
    
}
