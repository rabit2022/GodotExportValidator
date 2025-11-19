using Godot;
using GodotExportValidator;

public partial class Main : Node
{
	[Validate]
	private string test = "";

	public override void _Notification(int what)
	{
		base._Notification(what);
		if (what == NotificationEnterTree)
		{
			OnValidate();
		}
	}

	public override void _Ready()
	{
		
		// ValidateUtilities.ValidateCheckEmptyString(this, "test",  "");
	}
}
