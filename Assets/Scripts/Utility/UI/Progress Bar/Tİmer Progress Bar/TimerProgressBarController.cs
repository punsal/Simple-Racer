using UnityEngine;
using Utility.UI.Progress_Bar.Abstract;
using Utility.UI.Progress_Bar.Data;

namespace Utility.UI.Progress_Bar.Tİmer_Progress_Bar
{
    public class TimerProgressBarController : ProgressBarController
    {
        #pragma warning disable 649
        [SerializeField] private ShowTime showTime;
        #pragma warning restore 649

        protected override void ProgressBarDataDataAction(ProgressBarData barData)
        {
            if (showTime == null) return;
            showTime.SetTime(barData.CurrentAmount);
        }
    }
}