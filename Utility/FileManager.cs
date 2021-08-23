using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VRCTans.Utility
{
    internal class FileManager
    {
        public string FileBase => $"{_Path}/mods/{FileName}";

        const string FileName = "VRChatMultiLanguage.dll";

        private string _Path { get; set; }

        public FileManager(string path)
            => _Path = path;
        public Loader CreateLoader()
            => new Loader(this);
        public bool CheckFileIsExist()
            => File.Exists(_Path);

    }
}
