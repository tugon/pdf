using entities;
using Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ParentBusiness
    {
        private PdfHelper _helper;

        public ParentBusiness()
        {
            _helper = new PdfHelper();
        }
        public byte[] GeneratePdf(string html, string cssText)
        {
            List<Parent> parentList = new List<Parent>() {
                new Parent { Code = Guid.NewGuid(), Name="Ualabi"},
                new Parent { Code = Guid.NewGuid(), Name="Fabiano"},
                new Parent { Code = Guid.NewGuid(), Name="Adilson de Almeida Pedro"}
            };

            var sb = new StringBuilder();

            foreach (var parent in parentList)
            {
                sb.AppendFormat(html, parent.Name, parent.Code);
            }

            return _helper.Generate(sb.ToString(), cssText);
        }
    }
}
