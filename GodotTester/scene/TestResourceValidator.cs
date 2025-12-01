using Godot;
using GodotExportValidator;


internal partial class TestResourceValidator:Node
{
    public override void _Ready()
    {
        ResourceValidator.ValidateAllResourcesInFolder("res://resources/building/");
    }
}