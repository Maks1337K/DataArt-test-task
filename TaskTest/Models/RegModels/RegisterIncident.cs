using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTest.Models.DBModels
{
    public class RegisterIncident
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Contacts Contact { get; set; }
    }
}
