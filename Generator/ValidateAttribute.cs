using System;

namespace GodotExportValidator
{
    /// <summary>
    /// 特性定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ValidateAttribute : Attribute
    {
    }
}