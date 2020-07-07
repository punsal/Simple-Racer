using UnityEngine;

namespace Controllers
{
    public class CameraFollowController : MonoBehaviour
    {
        #pragma warning disable 649
        [SerializeField] private Transform followTarget;
        #pragma warning restore 649

        private Transform cameraTransform;
        private Vector3 offset;

        private void Awake()
        {
            cameraTransform = transform;
        }

        private void Start()
        {
            offset = cameraTransform.position - followTarget.position;
        }

        private void LateUpdate()
        {
            cameraTransform.position = followTarget.position + offset;
        }
    }
}
