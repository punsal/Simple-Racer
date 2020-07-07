using System;
using UnityEngine;
using Utility.Behaviour.Turn.Type;

namespace Utility.Behaviour.Turn
{
    public class FindTurnDirection : MonoBehaviour
    {
        [Tooltip("Whether global direction of object is positive or negative vector of related axis. If axis is negative means axis is flipped.")]
        [SerializeField]
        #pragma warning disable 649
        private bool isFlipped;
        #pragma warning restore 649

        [Header("Turn Direction")]
        [SerializeField] private Axis turningAxis = Axis.Z;

        [Header("Check Rotation")]
        [SerializeField] private int perFrame = 8;

        [Header("Debug")]
        [SerializeField] private int frameCount;
        [SerializeField] private float currentAngle;
        [SerializeField] private float previousAngle;
        [SerializeField] private Direction turnDirection;

        private Direction TurnDirection
        {
            get => turnDirection;
            set => turnDirection = value;
        }

        private Transform objectTransform;
        
        private void Awake()
        {
            objectTransform = transform;
        }

        private void Start()
        {
            switch (turningAxis)
            {
                case Axis.X:
                    previousAngle = objectTransform.eulerAngles.x;
                    break;
                case Axis.Y:
                    previousAngle = objectTransform.eulerAngles.y;
                    break;
                case Axis.Z:
                    previousAngle = objectTransform.eulerAngles.z;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Update()
        {
            switch (turningAxis)
            {
                case Axis.X:
                    currentAngle = objectTransform.eulerAngles.x;
                    break;
                case Axis.Y:
                    currentAngle = objectTransform.eulerAngles.y;
                    break;
                case Axis.Z:
                    currentAngle = objectTransform.eulerAngles.z;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (Mathf.Abs(previousAngle - currentAngle) < 0.001f)
            {
                //Do nothing
            }
            else
            {
                var angle = currentAngle - previousAngle;
                if (angle > 0f)
                {
                    turnDirection = isFlipped 
                        ? Direction.CounterClockwise 
                        : Direction.Clockwise;
                    Debug.Log(TurnDirection);
                }
                else
                {
                    turnDirection = isFlipped
                    ? Direction.Clockwise
                    : Direction.CounterClockwise;
                    Debug.Log(TurnDirection);
                }
            }

            if (frameCount == perFrame)
            {
                frameCount = 0;
                previousAngle = currentAngle;
            }

            frameCount++;
        }
    }
}