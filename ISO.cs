using DiscUtils;
using DiscUtils.Udf;
using System.IO;

namespace USBFormatingWithWinForm {
    internal class ISO {
        public static void ExtractISO(string ISOName, string ExtractionPath) {
            using (FileStream ISOStream = File.Open(ISOName, FileMode.Open)) {
                UdfReader Reader = new UdfReader(ISOStream);
                ExtractDirectory(Reader.Root, ExtractionPath, "");
                Reader.Dispose();
            }
        }
        static void ExtractDirectory(DiscDirectoryInfo Dinfo, string RootPath, string PathinISO) {
            if (!string.IsNullOrWhiteSpace(PathinISO)) {
                RootPath += "\\" + Dinfo.Name;
            }
            RootPath += "\\" + Dinfo.Name;
            AppendDirectory(RootPath);
            foreach (DiscDirectoryInfo dinfo in Dinfo.GetDirectories()) {
                ExtractDirectory(dinfo, RootPath, PathinISO);
            }
            foreach (DiscFileInfo finfo in Dinfo.GetFiles()) {
                using (Stream FileStr = finfo.OpenRead()) {
                    using (FileStream Fs = File.Create(RootPath + "\\" + finfo.Name)) {
                        FileStr.CopyTo(Fs, 4 * 1024); //Buffer Size
                    }
                }
            }
        }
        private static void AppendDirectory(string rootpath) {
            try {
                if (!Directory.Exists(rootpath)) {
                    Directory.CreateDirectory(rootpath);
                }
            } catch (DirectoryNotFoundException) {
                AppendDirectory(Path.GetDirectoryName(rootpath));
            } catch (PathTooLongException) {
                AppendDirectory(Path.GetDirectoryName(rootpath));
            }
        }
    }
}