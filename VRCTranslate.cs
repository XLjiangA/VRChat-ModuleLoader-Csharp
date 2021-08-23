using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using System.IO;
using System.Reflection;
using VRCTans.Utility;

namespace VRCTans
{
    class VRCTranslate : MelonMod
    {
        private static bool Initialized { get; set; }
        private Loader Loader { get; set; }
        public override void OnApplicationLateStart()
        {
            MelonLogger.Msg("Hey human");
            var CurrentDirectory = Directory.GetCurrentDirectory();
            Loader = new FileManager(CurrentDirectory)
                .CreateLoader();
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            //MelonLogger.Msg($"buildIndex:{buildIndex},sceneName:{sceneName}");
            if (buildIndex == 2 && !Initialized)
            {
                try
                {
                    if (Loader.LoadTranslate() > 0)
                    {
                        MelonLogger.Msg("VRChat多语言插件加载成功!!!");
                        Initialized = true;
                    }
                }
                catch (FileNotFoundException)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("VRChat多语言插件(VRChatMultiLanguage.dll)未找到，请前往下载：");
                    sb.AppendLine("https://github.com/extremeblackliu/VRChatMultiLanaguge/releases/tag/release");
                    sb.AppendLine("如果你也没有语言文件(language file)，下载：");
                    sb.AppendLine("https://github.com/extremeblackliu/VRChatMultiLanguage-File");
                    sb.AppendLine("下载好两个文件后，和加载器(VRCTranslate.dll)放置在同一路径");
                    MelonLogger.Error(sb.ToString());
                }
            }
        }

    }
}
