using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VuelosAPI.Entidades
{
    public class Airline
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50)]
        public string airline_name { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
