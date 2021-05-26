using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEvent.Data.Model
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Locations Location { get; set; }

        [Required]
        public EventType EventType { get; set; }

        [Required]
        public String Invite { get; set; }

    }
}