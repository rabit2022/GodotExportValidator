using Godot;

namespace GodotExportValidator;


public static class ResourceValidator
{
    /// <summary>
    /// 扫描指定目录下所有 .tres 文件，若脚本含公共 Validate() 方法则调用，
    /// 把错误汇总打印到控制台。
    /// </summary>
    public static void ValidateAllResourcesInFolder(string folder = "res://Resources")
    {
        using var dir = DirAccess.Open(folder);
        if (dir == null)
        {
            GD.PrintErr($"Open directory failed：{folder}");
            return;
        }

        GD.Print($"Start validating resources in folder：{folder}");

        dir.ListDirBegin(); // 开始遍历
        string fileName;
        while ((fileName = dir.GetNext()) != "")
        {
            if (dir.CurrentIsDir())
                continue;

            if (!fileName.EndsWith(".tres"))
                continue;

            string path = dir.GetCurrentDir().PathJoin(fileName);
            var res = ResourceLoader.Load<Resource>(path);
            if (res == null)
            {
                GD.PrintErr($"{path}：load failed");
                continue;
            }

            GD.Print("Start validating resource：" + path);

            // 拿脚本对象（Godot 4 里就是 res 本身）
            // var script = res.GetScript().As<Script>();
            // if (script == null)
            //     continue; // 原生 Resource，无脚本

            var script = res;

            // 2. 判断有没有这个方法
            // 生成器生成的方法无法通过 HasMethod() 判断和调用
            if (!script.HasMethod("Validate"))
            {
                GD.PrintErr($"{path}：has no defined Validate() method");
                continue;
            }

            // GD.Print("发现 Validate() 方法，开始调用");

            // 3. 调用（Godot 层调用，返回 Variant）
            var variantErrs = script.Call("Validate");
            // 4. 转成 C# 集合
            var errs = variantErrs.AsGodotArray<string>();
            foreach (var e in errs)
                GD.PrintErr($"{path}：{e}");
        }

        dir.ListDirEnd();
        GD.Print("End validating resource.\n");
    }
}