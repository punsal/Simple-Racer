using UnityEngine;
using Utility.Behaviour.Trigger;
using Utility.Extension;

namespace Ground
{
    public class GroundCheckTriggerController : TriggerController
    {
        protected override void OnTriggerEnterAction(Collider other)
        {
            if (other.GetComponent<Player.Player>(out var player))
            {
                player.Fail();
            }
        }
    }
}
