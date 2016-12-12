using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dto
{
    public class CancellationDto
    {
        public int Id { get; set; }
        public IssuedDto Issued { get; set; }
        public DateTime Date_Cancellation { get; set; }
    }
}
