using Data;
using UnityEngine;

namespace UI.Controller
{
    public class ViewController : MonoBehaviour
    {
        #pragma warning disable 649
        [SerializeField] private GameState gameState;
        #pragma warning restore 649

        public GameState GameState => gameState;
    }
}