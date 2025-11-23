
using System;
using Godot;
using GodotExportValidator;

// Console.WriteLine("Hello World!");
Console.WriteLine(new BouncingEnemy().Validate());

class Node2D :Node
{
    public T GetNode<T>(string path) => default(T)!;
}

// class ExportAttribute : Attribute {}

class AnimatedSprite2D {}

class RayCast2D :Node {}

partial class BouncingEnemy : Node2D
{
    // [Export]
    // public float Speed { get; private set; } = 50.0f;

    // [Export("./EnemySprite")]
    // private AnimatedSprite2D? _sprite;
    [Validate]
    private string  _rayCastLeft;
    [Validate]
    private int  _rayCastRight;
    [Validate]
    private List<RayCast2D> _rayCasts0;
    [Validate]
    private RayCast2D _rayCasts;
    [Validate]
    private RayCast2D[] _rayCasts2;

    public bool Validate()
    {
        OnValidate();
        return true;
    }
}



