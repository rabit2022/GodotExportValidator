using System;

namespace GodotExportValidator
{
    /// <summary>
    /// 特性定义
    /// </summary>
    [AttributeUsage(AttributeTargets.Field  | AttributeTargets.Property)]
    public class ValidateAttribute : Attribute
    {
    }
}