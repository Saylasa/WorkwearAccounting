using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dto
{
    public class EmplPositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ManufactoryDto Manufactory { get; set; }
    }
}
