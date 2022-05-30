using System;

namespace USBFormatingWithWinForm {
    internal class GetSize {
        public static string Size(Int64 size) {
            long result;
            if (size >= 1000000000) { // Larger than 1 GB
                result = size / 1000000000;
                return $"{result.ToString("F1")} GB";
            } else if (size >= 1000000) { // Larger than 1 MB
                result = size / 1000000;
                return $"{result.ToString("F1")} MB";
            }
            else if (size >= 1000) { // Larger than 1 KB
                result = size / 1000;
                return $"{result.ToString("F1")} KB";
            }
            return ""; //I highly doubt there is a flash drive smaller than 1KB
        }
    }
}