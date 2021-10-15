using Sandbox;
using Sandbox.UI;

namespace Surf
{
	partial class SurfPlayer : Player
	{
		[Net] public float SurfTime { get; private set; } = 0f;
		[Net] public float BestTime { get; private set; } = 0f;
		private bool TimerStarted { get; set; } = false;

		[Event( "start.timer" )]
		public void OnTimerStart( Entity player )
		{
			SurfTime = 0f;
			TimerStarted = true;
		}

		[Event( "stop.timer" )]
		public void OnTimerStop( Entity player )
		{
			if ( TimerStarted )
			{
				TimerStarted = false;
				if ( SurfTime < BestTime || BestTime == 0f )
				{
					BestTime = SurfTime;
					ChatBox.AddInformation( To.Everyone, $"{player.GetClientOwner().Name} got a new personal best! The time was: {InfoPanel.FloatToTimeString( BestTime )}" );
				}
			}
		}

		[Event( "stop.timer.failed" )]
		public void OnTimerFailStop( Entity player )
		{
			if ( TimerStarted )
			{
				TimerStarted = false;
				SurfTime = 0f;
			}
		}

		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new PlayerController();

			Animator = new StandardPlayerAnimator();

			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			SimulateActiveChild( cl, ActiveChild );

			if ( IsServer && TimerStarted )
			{
				SurfTime += Time.Delta;
			}

			//if (Input.Pressed(InputButton.Attack1))
			//         {
			//	Velocity += EyeRot.Forward * 1000f;
			//         }


			if ( IsServer && Input.Pressed( InputButton.Reload ) )
			{
				TeleportToEnt( "start" );
			}
		}

		public void TeleportToEnt( string entityName )
		{
			var targetent = Entity.FindByName( entityName );

			if ( targetent != null )
			{
				Velocity = Vector3.Zero;
				Transform = targetent.Transform;
			}
		}

		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}
	}
}
