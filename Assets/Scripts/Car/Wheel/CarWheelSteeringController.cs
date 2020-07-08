using Car.Interface;
using UnityEngine;

namespace Car.Wheel
{
    public class CarWheelSteeringController : MonoBehaviour, ISteerController
    {
        private WheelCollider wheelCollider;

        private void OnEnable()
        {
            wheelCollider = GetComponent<WheelCollider>();
        }

        public void Steer(float angle)
        {
            wheelCollider.steerAngle = angle;
        }
    }
}
