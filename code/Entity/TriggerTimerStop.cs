using Sandbox;

namespace Surf
{
	[Library("trigger_timer_stop")]
	[Hammer.Solid]
	public partial class TriggerTimerStop : BaseTrigger
	{
		public override void OnTouchStart(Entity toucher)
		{
			base.OnTouchStart(toucher);
			Event.Run("stop.timer", toucher);
		}
	}
}
