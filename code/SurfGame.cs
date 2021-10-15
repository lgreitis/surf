using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Surf
{
	[Library( "surf" )]
	public partial class SurfGame : Game
	{
		public SurfGame()
		{
			if ( IsServer )
			{
				Log.Info( "Surf Loaded Serverside!" );
				new SurfHudEntity();
			}
			if ( IsClient )
			{
				Log.Info( "Surf Loaded Clientside!" );
			}
		}

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new SurfPlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}
}
