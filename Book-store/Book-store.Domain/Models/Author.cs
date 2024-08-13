using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Domain.Models
{
    public class Author : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
        public string? Origin { get; set; }
    }
}
