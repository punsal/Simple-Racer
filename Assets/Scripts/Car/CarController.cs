using Hook;
using UnityEngine;

namespace Car
{
    public class CarController : MonoBehaviour
    {
        #pragma warning disable 649
        [Header("Movement")]
        [SerializeField] private float speed;

        [Header("VFX")]
        [SerializeField] private LineRenderer lineRenderer;
        #pragma warning restore 649
        
        private Rigidbody carRigidbody;

        private HookController currentHook;

        public HookController CurrentHook
        {
            private get => currentHook;
            set
            {
                if (!isAttached)
                {
                    currentHook = value;
                }   
            }
        }

        private bool isAttached;

        private void Awake()
        {
            carRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            carRigidbody.velocity = transform.forward * speed;
        }

        private void Update()
        {
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (currentHook == null) return;
                currentHook.Attach(carRigidbody);
                isAttached = true;
            }

            if (Input.GetMouseButton(0) && isAttached)
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(1, currentHook.transform.position);
            }

            if (Input.GetMouseButtonUp(0) && isAttached)
            {
                currentHook.Detach();
                carRigidbody.velocity = transform.forward * speed;
                carRigidbody.angularVelocity = Vector3.zero;
                carRigidbody.rotation = Quaternion.identity;
                isAttached = false;
            }
        }
    }
}
