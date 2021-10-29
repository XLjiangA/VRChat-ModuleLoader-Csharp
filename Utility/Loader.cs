using System;
using System.IO;
using UnityEngine;
using VRCTans.Model;

namespace VRCTans.Utility
{
    class Loader
    {
        private FileManager fm { get; set; }
        public Loader(FileManager _fm)
            => fm = _fm;



        public int LoadTranslate()
        {
            /*
            if (fm.ChecIsExist_DLL())
            {
                return LoadFormFIle(fm.FileBase);
            }
            */
            if (fm.CheckIsExist_Json())
            {
                return loadFormJson();
            }
            throw new FileNotFoundException();
        }

        [Obsolete]
        private int LoadFormFIle(string fileBase)
            => NativeAPI.LoadLibraryA(fileBase);

        public int loadFormJson()
        {

            var jText = File.ReadAllText(fm.JsonBase);
            var tList = JsonFormat.Get<TransObject>(jText);
            //MelonLogger.Msg(tList.Items.Length);
            for (int i = 0; i < tList.Items.Length; i++)
            {
                var t = tList.Items[i];
                var _path = t.Path;
                var _text = t.Text;
                GameObject.Find(_path)
                    .GetTextComponent()
                    .SetText(_text);
            }
            return 1;
        }
    }
}
