using Sandbox;
using Sandbox.UI;
using System;
using System.Diagnostics;

namespace Surf
{
	public class InfoPanel : Panel
	{
		private string TimeText { get; set; } = "00:00.00";
		private string BestTimeText { get; set; } = "00:00.00";
		public string TimerText => $"{TimeText} (Best: {BestTimeText})";

		private float topSpeed { get; set; } = 0f;
		private float PlayerSpeed { get; set; }
		public string PlayerSpeedText => $"{PlayerSpeed:N0}u/s (top: {topSpeed}u/s)";

		public InfoPanel()
		{
			SetTemplate( "code/UI/InfoPanel.html" );
			StyleSheet.Load( "code/UI/InfoPanel.scss" );
		}

		public override void Tick()
		{
			base.Tick();

			PlayerSpeed = Local.Pawn.Velocity.Cross( Vector3.Up ).Length;

			if ( PlayerSpeed.CeilToInt() > topSpeed )
				topSpeed = PlayerSpeed.CeilToInt();

			float bestTime = ((SurfPlayer)Local.Pawn).BestTime;
			BestTimeText = FloatToTimeString( bestTime );
			float time = ((SurfPlayer)Local.Pawn).SurfTime;
			TimeText = FloatToTimeString( time );
		}

		public static string FloatToTimeString( float time )
		{
			double minutes = Math.Floor( time / 60f );
			double seconds = Math.Floor( time % 60f );
			double milliseconds = Math.Floor( (time * 100f) % 100f );

			return String.Format( "{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds );
		}
	}
}
