using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GProject.Data.DomainClass
{
    public class Message
    {
        public int Id { get; set; }
        public string? userId { get; set; }
        public string? staffId { get; set; }
        public string content { get; set; }
        public DateTime sendDate{ get; set; }
        public bool? isAdmin{ get; set; }
    }
}
