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
    [Export] [Validate]
    public string DisplayName { get; private set; }

    /// <summary>
    /// 建造消耗的资源 
    /// </summary>
    [Export][Validate]
    public int ResourceCost { get; private set; }

    /// <summary>
    /// 建造范围
    /// </summary>
    [Export][Validate]
    public int BuildableRadius { get; private set; }

    /// <summary>
    /// 可以收集资源 的范围
    /// </summary>
    [Export][Validate]
    public int ResourceRadius { get; private set; }

    /// <summary>
    /// 塔的预制体
    /// </summary>
    [Export][Validate]
    public PackedScene BuildingScene { get; private set; }

    /// <summary>
    /// 这里必须创建public函数Validate，OnValidate()函数 代码生成，无法被检测到
    /// </summary>
    public void Validate()
    {
        OnValidate();
    }
}