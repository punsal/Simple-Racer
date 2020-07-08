using System.Collections.Generic;
using System.Linq;
using Data;
using UI.Controller;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        private GameData gameData;
        
        private List<ViewController> viewControllers;

        private void Awake()
        {
            viewControllers = FindObjectsOfType<ViewController>().ToList();
        }

        [Inject]
        // ReSharper disable once ParameterHidesMember
        private void Construct(GameData gameData)
        {
            this.gameData = gameData;
        }

        private void Update()
        {
            foreach (var viewController in viewControllers)
            {
                viewController.gameObject.SetActive(viewController.GameState == gameData.GameState);
            }
        }
    }
}
