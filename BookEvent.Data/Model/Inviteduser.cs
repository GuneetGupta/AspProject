using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEvent.Data.Model
{
    public class Inviteduser
    {
        public int id { get; set; }
        public String Gmail { get; set; }
        public int EventId { get; set; }
    }
}