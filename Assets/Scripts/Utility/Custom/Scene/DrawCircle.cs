using UnityEngine;

namespace Utility.Custom.Scene
{
    public class DrawCircle : MonoBehaviour
    {
        [SerializeField] private Color customColor = Color.green;
        [SerializeField] private float customRadius = 1f;

        public Color CustomColor
        {
            get => customColor;
            set => customColor = value;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = customColor;
            Gizmos.DrawSphere(transform.position, customRadius);
        }
    }
}
    
