using System.Security.Policy;
using UnityEngine;
using Utility.System.Publisher_Subscriber_System;

namespace Data
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Data/Game Data", order = 0)]
    public class GameData : ScriptableObject
    {
        [SerializeField] private GameState gameState;

        private void OnEnable()
        {
            gameState = GameState.GameStart;

            Player.Player.OnPlayerFailed += OnPlayerFailedEventHandler;
        }

        private void OnDisable()
        {
            Player.Player.OnPlayerFailed -= OnPlayerFailedEventHandler;
        }

        public GameState GameState => gameState;

        // ReSharper disable once ParameterHidesMember
        public void ChangeGameState(GameState gameState)
        {
            this.gameState = gameState;
            PublisherSubscriber.Publish(this.gameState);
        }

        private void OnPlayerFailedEventHandler()
        {
            gameState = GameState.GameEnd;
        }
    }
}