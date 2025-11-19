using Godot;
using System;

namespace GodotExportValidator.Example;
public partial class Main : Node
{
    public override void _Ready()
    {
        base._Ready();
        ValidateUtilities.ValidateCheckEmptyString(this, "SomeString", "");
    }
}
