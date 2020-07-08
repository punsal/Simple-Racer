using System;
using Car.Interface;
using UniRx;
using UnityEngine;

namespace Car.Wheel
{
    public class CarWheelThrustController : MonoBehaviour, IThrustController
    {
        private WheelCollider wheelCollider;
        
        private void OnEnable()
        {
            wheelCollider = GetComponent<WheelCollider>();
        }

        public void Thrust(float torque, float topSpeed = 50f)
        {
            if (wheelCollider == null)
            {
                wheelCollider = GetComponent<WheelCollider>();
            }
            
            wheelCollider.motorTorque = torque;
            
            Observable.EveryFixedUpdate().Subscribe(_ =>
            {
                if (!(Math.Abs(wheelCollider.attachedRigidbody.velocity.magnitude - topSpeed) < 0.1f))
                {
                    wheelCollider.motorTorque = torque;
                    Debug.Log("Speeding..");
                    return;
                }
                wheelCollider.motorTorque = 0f;
                Debug.Log("Stopped.");
            });
        }
    }
}
