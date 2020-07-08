using Car.Controller;
using Data;
using UnityEngine;
using Utility.System.Publisher_Subscriber_System;
using Zenject;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private PlayerData playerData;
        
        private CarDriveController carDriveController;

        private Subscription<GameState> gameStateSubscription;
        
        #region Delegates

        public delegate void PlayerFailed();

        #endregion

        #region Events

        public static event PlayerFailed OnPlayerFailed;

        #endregion

        private void OnEnable()
        {
            carDriveController = GetComponent<CarDriveController>();

            gameStateSubscription = PublisherSubscriber.Subscribe<GameState>(GameStateHandler);
        }

        private void OnDisable()
        {
            PublisherSubscriber.Unsubscribe(gameStateSubscription);
        }

        [Inject]
        // ReSharper disable once ParameterHidesMember
        private void Construct(PlayerData playerData)
        {
            this.playerData = playerData;
        }

        private void GameStateHandler(GameState gameState)
        {
            if (gameState == GameState.GamePlay)
            {
                carDriveController.StartDrive();
            }
        }
        
        public void Scored()
        {
            Debug.Log("Scored.");   
            playerData.AddScore();
        }

        public void Fail()
        {
            Debug.Log("Player Failed.");
            
            //Inner functionality change
            carDriveController.Stop();
            
            //Notify others
            OnPlayerFailed?.Invoke();
        }
    }
}