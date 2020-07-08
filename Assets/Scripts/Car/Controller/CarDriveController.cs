using System.Collections.Generic;
using System.Linq;
using Car.Interface;
using UnityEngine;

namespace Car.Controller
{
    public class CarDriveController : MonoBehaviour
    {
        [Header("Thrusting")]
        [SerializeField] private float carMaxSpeed = 25f;
        [SerializeField] private float wheelThrustTorque = 200f;

        [Header("Steering")]
        [SerializeField] private float carMaxSteeringAngle = 22.5f;
        public bool isDrifting;
        public Vector3 destination;
        
        private Rigidbody carRigidbody;

        private List<IThrustController> thrustControllers;
        private List<ISteerController> steerControllers;

        private void OnEnable()
        {
            carRigidbody = GetComponent<Rigidbody>();
            carRigidbody.centerOfMass = Vector3.down * 0.9f;
            carRigidbody.isKinematic = true;
            
            thrustControllers = GetComponentsInChildren<IThrustController>().ToList();
            steerControllers = GetComponentsInChildren<ISteerController>().ToList();
        }

        private void FixedUpdate()
        {
            if (carRigidbody.isKinematic) return;
            carRigidbody.velocity = carRigidbody.velocity.normalized * carMaxSpeed;

            if (isDrifting) return;
            Debug.DrawLine(transform.position + transform.up * 2f, destination + transform.up * 2f, Color.green);
            var relativeVector = transform.InverseTransformPoint(destination);
            var angle = relativeVector.x / relativeVector.magnitude;
            Steer(angle);
        }

        public void StartDrive()
        {
            carRigidbody.isKinematic = false;
            carRigidbody.velocity = transform.forward * carMaxSpeed;

            foreach (var thrustController in thrustControllers)
            {
                thrustController.Thrust(wheelThrustTorque, carMaxSpeed);
            }
        }

        public void Steer(float angle)
        {
            angle = Mathf.Clamp(angle, -1f, 1f);
            foreach (var steerController in steerControllers)
            {
                steerController.Steer(angle * carMaxSteeringAngle);
            }
        }

        public void Stop()
        {
            carRigidbody.isKinematic = true;
            carRigidbody.velocity = Vector3.zero;
            carRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
