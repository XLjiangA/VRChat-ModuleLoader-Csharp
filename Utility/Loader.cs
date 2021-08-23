using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VRCTans.Utility
{
    internal class Loader
    {
        private FileManager fm { get; set; }
        public Loader(FileManager _fm)
            => fm = _fm;

        public int LoadTranslate()
        {
            if (fm.CheckFileIsExist())
            {
                return LoadFormFIle(fm.FileBase);
            }
            throw new FileNotFoundException();
        }
        private int LoadFormFIle(string fileBase)
            => NativeAPI.LoadLibraryA(fileBase);


    }
}
