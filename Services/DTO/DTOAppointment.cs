using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public  class DTOAppointment
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int ServiceId { get; set; }
    }
}
