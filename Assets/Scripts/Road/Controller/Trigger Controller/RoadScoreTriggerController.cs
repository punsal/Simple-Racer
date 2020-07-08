using UnityEngine;
using Utility.Behaviour.Trigger;
using Utility.Extension;

namespace Road.Controller.Trigger_Controller
{
    public class RoadScoreTriggerController : TriggerController
    {
        protected override void OnTriggerEnterAction(Collider other)
        {
            if (other.GetComponent<Player.Player>(out var player))
            {
                player.Scored();
            }
        }
    }
}
