# 添加本地 NuGet 源
dotnet nuget add source "H:\project\godot\GodotLocalPackages" --name GodotLocalPackages

# 跳过编译阶段
dotnet pack Generator.csproj -c Release  --no-build
