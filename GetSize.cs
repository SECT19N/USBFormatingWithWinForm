using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBFormatingWithWinForm {
    internal class GetSize {
        public static string Size(Int64 size) {
            string postfix = "Bytes";
            long result = size;
            if (size >= 1000000000) { // Larger than 1 GB
                result = size / 1000000000;
                postfix = "GB";
            } else if (size >= 1000000) { // Larger than 1 MB
                result = size / 1000000;
                postfix = "MB";
            } else if (size >= 1000) { // Larger than 1 KB
                result = size / 1000;
                postfix = "KB";
            }
            return result.ToString("F1") + " " + postfix;
        }
    }
}