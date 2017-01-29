using System.Collections.Generic;

namespace Entities
{
    public class MailMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public List<Recpient> Recipients { get; set; }
    }
}
