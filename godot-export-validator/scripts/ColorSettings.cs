using Godot;

namespace GodotExportValidator;

internal static class ColorSettings
{
    
    private static string WarniningColor = "[color=#FFAA55]";
    private static string ErrorColor = "[color=#FF5555]";
    private static string InfoColor = "[color=#55AAFF]";
    private static string DebugColor = "[color=#55FF55]";
    private static string VerboseColor = "[color=#AAAAAA]";
    private static string DefaultColor = "[color=#FFFFFF]";
    
    private static string NodeColor = "[color=#39cc9b]";

    public static string Validate = $"{ErrorColor}[Validate]{DefaultColor}    ";

    public static string WrapFieldName(string fieldName)
    {
        return $"{InfoColor}{fieldName}    {DefaultColor}";
    }
    
    public static string NodeToString(Node node)
    {
        // <type    path>
        // return $"{NodeColor}<{node.GetType().Name}    {node.GetPath()}>{DefaultColor}";
        if (node.HasMethod("GetPath"))
        {
            return $"{NodeColor}<{node.GetType().Name}    {node.GetPath()}>{DefaultColor}";
        }
        return $"{NodeColor}<{node.GetType().Name}    (no path)>";
    }
    
    public static string ResourceToString(Resource node)
    {
        // <type    path>
        return $"{NodeColor}<{node.GetType().Name}    {node.ResourcePath}>{DefaultColor}";
    }

}