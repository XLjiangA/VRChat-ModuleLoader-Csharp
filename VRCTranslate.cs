using MelonLoader;
using System.IO;
using System.Text;
using VRCTans.Utility;
using UnityEngine;
using VRCTans.Model;

namespace VRCTans
{
    class VRCTranslate : MelonMod
    {
        private static bool Initialized { get; set; }
        private static bool Done { get; set; }
        private Loader Loader { get; set; }
        public override void OnApplicationLateStart()
        {
            MelonLogger.Msg("Hey human");
            var CurrentDirectory = Directory.GetCurrentDirectory();
            //MelonLogger.Msg(CurrentDirectory);
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
                        Initialized = true;
                    }
                }
                catch (FileNotFoundException)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("翻译插件加载失败!");
                    // sb.AppendLine("VRChat多语言插件(VRChatMultiLanguage.dll)未找到，请前往下载：");
                    //  sb.AppendLine("https://github.com/extremeblackliu/VRChatMultiLanaguge/releases/tag/release");
                    sb.AppendLine("如果你没有语言文件(language file)，下载：");
                    sb.AppendLine("https://github.com/extremeblackliu/VRChatMultiLanguage-File");
                    sb.AppendLine("下载文件后，请放置在(VRchat/Mods/)路径下");
                    MelonLogger.Error(sb.ToString());
                }
            }
        }
        public override void OnUpdate()
        {
            if(!Done && Initialized && GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)") != null)
            {
                var jText = File.ReadAllText(Loader.fm.JsonBase);
                var tList = JsonFormat.Get<TransObject>(jText);
                for (int i = 0; i < tList.Items.Length; i++)
                {
                    var t = tList.Items[i];
                    var _path = t.Path;
                    var _text = t.Text;
                    var component = GameObject.Find(_path).GetTextComponent();
                    if (component == null)
                    {
                        var component1 = GameObject.Find(_path).GetTextMeshProComponent();
                        if (component1 == null)
                        {
                            continue;
                        }
                        component1.SetText(_text);
                        continue;
                    }
                    component.SetText(_text);
                }
                Done = true;
                MelonLogger.Msg("VRChat多语言插件加载成功!!!");
            }
        }
    }
}
