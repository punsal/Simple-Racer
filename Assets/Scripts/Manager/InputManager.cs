using UnityEngine;
using Utility.Behaviour.Game.HotKey;
using Utility.Manager.Type;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        #pragma warning disable 649
        [SerializeField] private HotKeyData hotKeyData;
        #pragma warning restore 649
        
        public static InputState InputState = InputState.Up;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(hotKeyData.keyCode))
            {
                InputState = InputState.Down;
            }

            if (Input.GetMouseButton(0) || Input.GetKey(hotKeyData.keyCode))
            {
                InputState = InputState.Hold;
            }

            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(hotKeyData.keyCode))
            {
                InputState = InputState.Up;
            }
        }
    }
}