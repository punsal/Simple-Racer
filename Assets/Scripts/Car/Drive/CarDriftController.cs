using Manager;
using UnityEngine;
using Utility.Manager.Type;

namespace Car.Drive
{
    [RequireComponent(typeof(CarDriveController))]
    public class CarDriftController : MonoBehaviour
    {
        private CarDriveController carDriveController;

        private void OnEnable()
        {
            carDriveController = GetComponent<CarDriveController>();
        }

        private void Update()
        {
            if (InputManager.InputState == InputState.Down)
            {
                carDriveController.enabled = false;
            }

            if (InputManager.InputState == InputState.Hold)
            {
                carDriveController.enabled = false;
            }

            if (InputManager.InputState == InputState.Up)
            {
                carDriveController.enabled = true;
            }
        }
    }
}
