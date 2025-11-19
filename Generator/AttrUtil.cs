using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace GodotExportValidator.SourceGenerator;

public static class AttrUtil
{
    // 路径解析
    public static  ImmutableArray<TypedConstant> GetConstructorArgs(ImmutableArray<AttributeData> attributes)
    {
        var args = attributes
            .First(a => a.AttributeClass.Name == "ValidateAttribute")
            .ConstructorArguments;
        // var value = (string)args[0].Value;
        // return !string.IsNullOrEmpty(value) ? value : @default;
        return args;
    }
}