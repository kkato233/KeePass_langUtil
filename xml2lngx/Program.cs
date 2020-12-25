using KeePass.Util.XmlSerialization;
using KeePassLib.Translation;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace xml2lngx
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Usage();
                return;
            }

            string inFile = args[0];
            if (! System.IO.File.Exists(inFile))
            {
                Usage();
                return;
            }

            string outLngFile = args[1];

            KPTranslation kpTrl = loadFromXmlFile(inFile);

            saveToFile(kpTrl, outLngFile);
        }

        private static KPTranslation loadFromXmlFile(string inFile)
        {
            XmlSerializer xs = new XmlSerializer(typeof(KPTranslation));
            using (FileStream fs = new FileStream(inFile, FileMode.Open,
                            FileAccess.Read, FileShare.Read))
            {
                KPTranslation kpTrl = xs.Deserialize(fs) as KPTranslation;

                return kpTrl;
            }
        }

        /// <summary>
        /// 翻訳ファイルに出力する
        /// </summary>
        /// <param name="kpTrl"></param>
        /// <param name="outFile"></param>
        private static void saveToFile(KPTranslation kpTrl, string outFile)
        {
            XmlSerializerEx xsWrute = new XmlSerializerEx(typeof(KPTranslation));
            KPTranslation.Save(kpTrl, outFile, xsWrute);
        }

        public static void Usage()
        {
            Console.Error.WriteLine("xml2lngx <xmlファイル名> <lngxファイル>");
            Console.Error.WriteLine("KeePass の言語ファイル の XML 形式を *.lngx 形式に展開します。");
            Console.Error.WriteLine("出力ファイルが存在する場合は 上書きします。");
        }
    }
}
