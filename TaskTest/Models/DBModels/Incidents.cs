using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Models
{
    public class Incidents
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }
        public ICollection<Accounts> Account { get; set; }
    }
}
