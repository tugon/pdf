using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;
using System.Collections.Generic;
using iTextSharp.text.html.simpleparser;
using entities;
using iTextSharp.tool.xml;

namespace Helpers
{
    public class PdfHelper
    {
        public Document Doc { get; set; }
        public PdfHelper()
        {
            Doc = new Document(PageSize.A4, 30, 30, 42, 35);
        }


        public byte[] Generate(string html, string cssText)
        {

            using (var memoryStream = new MemoryStream())
            {
                
                var writer = PdfWriter.GetInstance(Doc, memoryStream);
                Doc.Open();

                using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
                {
                    using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, Doc, htmlMemoryStream, cssMemoryStream);
                    }
                }

                Doc.Close();

                return memoryStream.ToArray();
            }
        }
    }
}
