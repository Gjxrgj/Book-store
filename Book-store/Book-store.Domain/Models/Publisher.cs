using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Domain.Models
{
    public class Publisher : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? PublisherImage { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
