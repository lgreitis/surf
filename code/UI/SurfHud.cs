using Sandbox;
using Sandbox.UI;
using System;
using System.Diagnostics;

namespace Surf
{
	[Library]
	public partial class SurfHudEntity : HudEntity<RootPanel>
	{
		public SurfHudEntity()
		{
			if ( !IsClient )
				return;

			RootPanel.SetTemplate( "code/UI/SurfHud.html" );
			RootPanel.StyleSheet.Load( "code/UI/SurfHud.scss" );
			RootPanel.AddChild<InfoPanel>();
		}
	}
}
