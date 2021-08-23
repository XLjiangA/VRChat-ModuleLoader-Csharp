using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using System.IO;
using System.Reflection;
namespace vrc_zh
{
    class Vrczh : MelonMod
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static int LoadLibraryA(string path);

        public const string LIB_NAME_STR = "VRChat_Chinese.dll";

        public static bool Initialized { get; set; }

        public override void OnApplicationLateStart()
        {
            MelonLogger.Msg("Hey human");
            if (!File.Exists(LIB_NAME_STR))
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"vrc_zh.{LIB_NAME_STR}"))
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    File.WriteAllBytes(LIB_NAME_STR, bytes);
                    stream.Close();

                }

            }

        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            //MelonLogger.Msg($"buildIndex:{buildIndex},sceneName:{sceneName}");
            if (buildIndex == 2&&!Initialized)
            {
                if (LoadLibraryA("VRChat_Chinese.dll") > 0)
                {
                    MelonLogger.Msg("VRChat中文汉化插件加载成功!!!");
                    Initialized = true;
                }
            }
        }

    }
}
