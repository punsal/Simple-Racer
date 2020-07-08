using UnityEngine;
using Utility.Manager.Type;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        public static InputState InputState = InputState.Up;

        #region Delegates

        public delegate void InputDown();

        public delegate void InputHold();

        public delegate void InputUp();

        #endregion

        #region Events

        public static event InputDown OnInputDown;
        public static event InputHold OnInputHold;
        public static event InputUp OnInputUp;

        #endregion

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputState = InputState.Down;
                OnInputDown?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                InputState = InputState.Hold;
                OnInputHold?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                InputState = InputState.Up;
                OnInputUp?.Invoke();
            }
        }
    }
}