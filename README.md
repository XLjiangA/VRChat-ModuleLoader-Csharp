# VRChat-ModuleLoader-Csharp

## VRCHAT汉化插件加载器

* 启发于 https://www.bilibili.com/video/BV1EQ4y117tn
* 会检测游戏目录下是否拥有汉化插件(VRChat_Chinese.dll),否则会自动释放插件置游戏根目录
* 会在游戏UI(buildIndex == 2)加载完毕后注入汉化插件(VRChat_Chinese.dll)到游戏中(仅加载一次,不必担心)

## 加载器属于MelonMod基于以下

- [MelonLoader 0.4.3](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [.NET Framework 4.7.2 Runtime](https://dotnet.microsoft.com/download/dotnet-framework/net472)

## 特别感谢

- [ExtremeBlackLiu](https://github.com/extremeblackliu)制作了汉化插件!