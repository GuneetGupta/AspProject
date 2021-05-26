using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEvent.Data.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Gmail { get; set; }

        [Required]
        public String Password { get; set; }

    }
}
