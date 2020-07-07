using System;
using System.Collections.Generic;
using EventArguments;
using UnityEngine;
using Utility.System.Publisher_Subscriber_System;

namespace Utility.Behaviour.Camera
{
    [Serializable]
    public struct CameraFollowData
    {
        public GameEventType gameEventType;
        public CameraSmoothFollow cameraFollow;
    }
    
    public class CameraFollowManager : MonoBehaviour
    {
        [SerializeField] private List<CameraFollowData> data = new List<CameraFollowData>();

        private Subscription<GameEventType> gameEventSubscription;

        private void OnEnable()
        {
            gameEventSubscription = PublisherSubscriber.Subscribe<GameEventType>(GameEventHandler);
        }

        private void OnDisable()
        {
            PublisherSubscriber.Unsubscribe(gameEventSubscription);
        }

        private void Start()
        {
            foreach (var followData in data)
            {
                followData.cameraFollow.enabled = followData.gameEventType == GameEventType.IntroGame;
            }
        }

        private void GameEventHandler(GameEventType gameEventType)
        {
            if (gameEventType == GameEventType.StartGame)
            {
                foreach (var item in data)
                {
                    item.cameraFollow.enabled = item.gameEventType == GameEventType.StartGame;
                }
            }
        }
    }
}
