using System;
using System.IO;

namespace VRCTans.Utility
{
    internal class FileManager
    {
        public string JsonBase => $"{_Path}/Mods/{FileJson}";

        public string FileBase => $"{_Path}/Mods/{FileDll}";

        const string FileJson = "Language.json";

        const string FileDll = "VRChatMultiLanguage.dll";

        private string _Path { get; set; }

        public FileManager(string path)
            => _Path = path;

        public Loader CreateLoader()
            => new Loader(this);

        [Obsolete]
        public bool ChecIsExist_DLL()
            => File.Exists(FileBase);

        public bool CheckIsExist_Json()
            => File.Exists(JsonBase);
    }
}
