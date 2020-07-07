using Car;
using Hook;
using UnityEngine;

namespace Road.Generator
{
    public class RoadTriggerController : MonoBehaviour
    {
        [SerializeField] private HookController hookController;
        
        private void OnTriggerEnter(Collider other)
        {
            var carController = other.transform.GetComponent<CarController>();

            if (carController != null)
            {
                carController.CurrentHook = hookController;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var carController = other.transform.GetComponent<CarController>();

            if (carController != null)
            {
                carController.CurrentHook = null;
            }
        }
    }
}
