using System.IO;
using System.Text;

namespace Helpers
{
    public static class Extensions
    {
        public static Stream ToStream(this string contents, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            byte[] byteArray = encoding.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }

        public static Stream ToStream(this byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}
