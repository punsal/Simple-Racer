using Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Controller
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ShowScoreController : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        
        private PlayerData playerData;

        private void OnEnable()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        [Inject]
        // ReSharper disable once ParameterHidesMember
        private void Construct(PlayerData playerData)
        {
            this.playerData = playerData;
        }

        private void Update()
        {
            scoreText.text = playerData.Score.ToString();
        }
    }
}