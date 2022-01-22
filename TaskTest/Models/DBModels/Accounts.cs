using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Models
{
    public class Accounts
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contacts> Contact { get; set; }
    }
}
