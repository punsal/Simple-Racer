using Hook;
using Manager;
using UnityEngine;
using Utility.Manager.Type;

namespace Car.Controller
{
    [RequireComponent(typeof(LineRenderer))]
    public class CarDriftController : MonoBehaviour
    {
        [SerializeField] private HookController currentHookController;
        [SerializeField] private bool isAttached;
        
        private Rigidbody carRigidbody;
        private CarDriveController carDriveController;
        private LineRenderer lineRenderer;

        private void OnEnable()
        {
            carRigidbody = GetComponent<Rigidbody>();
            carDriveController = GetComponent<CarDriveController>();
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void OnDisable()
        {
            lineRenderer.positionCount = 0;
        }

        public void Construct(HookController hookController)
        {
            Debug.Log("Hook Constructed.");
            currentHookController = hookController;
        }

        private void Update()
        {
            switch (InputManager.InputState)
            {
                case InputState.Down:
                    Debug.Log("Try to attach.");
                    currentHookController.Attach(carRigidbody);
                    isAttached = true;

                    carDriveController.isDrifting = true;

                    DrawLine();

                    break;
                case InputState.Hold:
                {
                    if (!isAttached)
                    {
                        Debug.Log("Try to attach.");
                        currentHookController.Attach(carRigidbody);
                        isAttached = true;

                        carDriveController.isDrifting = true;
                    }
                    else
                    {
                        var relativeVector = transform.InverseTransformPoint(currentHookController.transform.position);
                        var steerAngle = relativeVector.x / relativeVector.magnitude;
                        carDriveController.Steer(steerAngle);
                    }
                    
                    DrawLine();

                    break;
                }
                case InputState.Up when !isAttached:
                    return;
                case InputState.Up:
                    currentHookController.Detach();
                    isAttached = false;

                    carDriveController.isDrifting = false;
                    carRigidbody.angularVelocity = Vector3.zero;

                    Destroy(this);
                    break;
            }
        }

        private void DrawLine()
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new[]
            {
                transform.position,
                currentHookController.transform.position
            });
        }
    }
}
