using Car.Controller;
using Hook;
using UnityEngine;
using Utility.Behaviour.Trigger;
using Utility.Extension;

namespace Road.Controller.Trigger_Controller
{
    public class RoadDriftTriggerController : TriggerController
    {
        #pragma warning disable 649
        [Header("Hook for Player")]
        [SerializeField] private HookController hookController;
        #pragma warning restore 649
        
        protected override void OnTriggerEnterAction(Collider other)
        {
            CreateDriftController(other);
        }

        private void CreateDriftController(Collider other)
        {
            var driftController = other.gameObject.AddComponent<CarDriftController>();
            driftController.Construct(hookController);
        }

        private void OnTriggerStay(Collider other)
        {
            if (!tags.Contains(other.tag)) return;
            if (other.GetComponent<CarDriftController>(out var driftController)) return;
            CreateDriftController(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!tags.Contains(other.tag)) return;
            if (other.GetComponent<CarDriftController>(out var carDriftController))
            {
                Destroy(carDriftController);
            }
        }
    }
}
