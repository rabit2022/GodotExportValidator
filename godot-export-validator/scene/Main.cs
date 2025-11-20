using Godot;
using System;

namespace GodotExportValidator.Example;


public partial class Main : Node
{
    [Export]
    public BuildingResource BuildingResource { get; set; }
    public override void _Ready()
    {
        base._Ready();
        // ValidateUtilities.ValidateCheckEmptyString(this, "SomeString", "");
        
        ValidateUtilities.ValidateCheckNullValue(this, "BuildingResource", BuildingResource);

        // GD.Print(BuildingResource.GetType());
        // GD.Print(BuildingResource.ResourcePath);
        // GD.Print(BuildingResource.ResourceName);
    }
}
