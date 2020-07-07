using UnityEngine;

namespace Hook
{
    public class HookController : MonoBehaviour
    {
        private FixedJoint fixedJoint;
        
        public void Attach(Rigidbody attachableRigidbody)
        {
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = attachableRigidbody;
        }

        public void Detach()
        {
            if (fixedJoint != null)
            {
                Destroy(fixedJoint);
            }
        }
    }
}
