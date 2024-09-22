using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string? NameService { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
