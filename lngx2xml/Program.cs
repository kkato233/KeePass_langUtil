using KeePassLib.Translation;
using KeePassLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace lngx2xml
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
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

            string outXmlFile = args[1];

            KPTranslation kpTrl = loadFromFile(inFile);
            WriteToXmlFile(kpTrl, outXmlFile);
        }

        private static void WriteToXmlFile(KPTranslation kpTrl, string outXmlFile)
        {
            XmlSerializer xs = new XmlSerializer(typeof(KPTranslation));
            using (FileStream fs = new FileStream(outXmlFile, FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                using (XmlWriter xw = XmlUtilEx.CreateXmlWriter(fs))
                {
                    xs.Serialize(xw, kpTrl);
                }
            }
        }

        private static KPTranslation loadFromFile(string file)
        {

            XmlSerializer xs = new XmlSerializer(typeof(KPTranslation));
            using (FileStream fs = new FileStream(file, FileMode.Open,
                            FileAccess.Read, FileShare.Read))
            {
                KPTranslation kpTrl = Load(fs, xs);

                return kpTrl;
            }
        }

        public static KPTranslation Load(Stream s, XmlSerializer xs)
        {
            if (xs == null) throw new ArgumentNullException("xs");

            KPTranslation kpTrl = null;

#if !KeePassLibSD
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
#else
			using(GZipInputStream gz = new GZipInputStream(s))
#endif
            {
                kpTrl = (xs.Deserialize(gz) as KPTranslation);
            }

            s.Close();
            return kpTrl;
        }
        public static void Usage()
        {
            Console.Error.WriteLine("lngx2xml <lngxファイル> <xmlファイル名>");
            Console.Error.WriteLine("KeePass の言語ファイル (*.lngx) を XML 形式に展開します。");
            Console.Error.WriteLine("出力ファイルが存在する場合は 上書きします。");
        }
    }
}
