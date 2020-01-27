using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityNotesDemo.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
    }
}
