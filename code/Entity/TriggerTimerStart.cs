using Sandbox;
using Sandbox.UI;

namespace Surf
{
    [Library("trigger_timer_start")]
	[Hammer.Solid]
	public partial class TriggerTimerStart : BaseTrigger
    {
		public override void OnTouchEnd(Entity toucher)
		{
			base.OnTouchEnd(toucher);
			Event.Run("start.timer", toucher);
		}

		public override void OnTouchStart(Entity toucher)
		{
			base.OnTouchStart(toucher);
			Event.Run("stop.timer.failed", toucher);
		}
	}
}
