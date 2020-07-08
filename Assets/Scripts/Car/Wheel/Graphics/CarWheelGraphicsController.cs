using System;
using UniRx;
using UnityEngine;

namespace Car.Wheel.Graphics
{
    public class CarWheelGraphicsController : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField] private WheelCollider wheelCollider;
#pragma warning restore 649

        private Transform graphicsTransform;

        private void Start()
        {
            if (wheelCollider == null) return;
            graphicsTransform = transform;
            Observable.EveryUpdate().Subscribe(_ =>
            {
                wheelCollider.GetWorldPose(out var position, out var rotation);
                graphicsTransform.position = position;
                graphicsTransform.rotation = rotation;
            });
        }
    }
}
