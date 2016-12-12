using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dto
{
    public class IssuedDto
    {
        public int Id { get; set; }
        public RevenueDto Revenue { get; set; }
        public PersonDto Person { get; set; }
        public bool Cancellation { get; set; }
        public DateTime Date_Issued { get; set; }
    }
}
