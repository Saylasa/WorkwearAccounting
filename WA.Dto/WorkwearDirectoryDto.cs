using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dto
{
    public class WorkwearDirectoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int TimeOfWear { get; set; }
        public string Unit { get; set; }
    }
}
