namespace Godot;

// GD
public static class GD
{
    public static void PrintErr(string message)
    {
        Console.WriteLine(message);
    }
    
}

// Node
public class Node : Object
{
    public string GetPath()
    {
        return "/root/node";
    }
}