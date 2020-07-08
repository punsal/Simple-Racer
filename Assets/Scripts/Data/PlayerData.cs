using System;
using UnityEngine;
using Utility.System.Publisher_Subscriber_System;

namespace Data
{
    [CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int score;

        private Subscription<GameState> gameStateSubscription;

        private void OnEnable()
        {
            score = 0;

            gameStateSubscription = PublisherSubscriber.Subscribe<GameState>(GameStateHandler);
        }

        private void OnDisable()
        {
            PublisherSubscriber.Unsubscribe(gameStateSubscription);
        }

        public int Score => score;

        public void AddScore(int value = 1) => score += value;

        private void GameStateHandler(GameState gameState)
        {
            if (gameState == GameState.GameStart)
            {
                score = 0;
            }
        }
    }
}