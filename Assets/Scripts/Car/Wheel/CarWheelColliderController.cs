using Car.Controller;
using Road.Controller;
using Road.Generator;
using UnityEngine;

namespace Car.Wheel
{
    [RequireComponent(typeof(WheelCollider))]
    public class CarWheelColliderController : MonoBehaviour
    {
        private CarDriveController driveController;
        private WheelCollider wheelCollider;

        private void OnEnable()
        {
            if (driveController == null)
            {
                driveController = GetComponentInParent<CarDriveController>();
            }

            if (wheelCollider == null)
            {
                wheelCollider = GetComponent<WheelCollider>();
            }
        }

        private void Update()
        {
            if (wheelCollider.GetGroundHit(out var hit))
            {
                var roadController = hit.collider.attachedRigidbody.GetComponent<RoadController>();
                driveController.destination = roadController.EndPosition;
            }
        }
    }
}