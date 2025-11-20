using Godot;
using System;
using GodotExportValidator;

namespace GodotExportValidator.Example;

[GlobalClass] // 编辑器中创建资源
public partial class BuildingResource : Resource
{
    /// <summary>
    /// ui 的名字
    /// </summary>
    [Export]
    public string DisplayName { get; private set; }

    /// <summary>
    /// 建造消耗的资源 
    /// </summary>
    [Export]
    public int ResourceCost { get; private set; }

    /// <summary>
    /// 建造范围
    /// </summary>
    [Export]
    public int BuildableRadius { get; private set; }

    /// <summary>
    /// 可以收集资源 的范围
    /// </summary>
    [Export]
    public int ResourceRadius { get; private set; }

    // /// <summary>
    // /// 塔的预制体
    // /// </summary>
    // [Export]
    // public PackedScene BuildingScene { get; private set; }

    // public BuildingResource()
    // {
    //     OnValidate();
    // }
}