using System.Collections.Generic;
using System.Linq;
using Car.Interface;
using UniRx;
using UnityEngine;

namespace Car.Drive
{
    public class CarDriveController : MonoBehaviour
    {
        [SerializeField] private float carMaxSpeed = 25f;
        [SerializeField] private float carMaxSteeringAngle = 22.5f;
        
        [SerializeField] private float wheelThrustTorque = 200f;

        private Rigidbody carRigidbody;
        
        private List<IThrustController> thrustControllers;
        private List<ISteerController> steerControllers;

        private void OnEnable()
        {
            carRigidbody = GetComponent<Rigidbody>();
            
            thrustControllers = GetComponentsInChildren<IThrustController>().ToList();
            steerControllers = GetComponentsInChildren<ISteerController>().ToList();
        }

        private void Start()
        {
            carRigidbody.velocity = Vector3.forward * carMaxSpeed;
            
            foreach (var thrustController in thrustControllers)
            {
                thrustController.Thrust(wheelThrustTorque, carMaxSpeed);
            }
            
            Observable.EveryFixedUpdate().Subscribe(_ =>
            {
                var angle = Input.GetAxis("Horizontal");
                angle = Mathf.Clamp(angle, -1f, 1f);
                foreach (var steerController in steerControllers)
                {
                    steerController.Steer(angle * carMaxSteeringAngle);
                }
            });
        }
    }
}
