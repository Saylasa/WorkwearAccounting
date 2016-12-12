using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dto
{
    public class NormDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public EmplPositionDto EmplPosition { get; set; }
        public WorkwearDirectoryDto WorkwearDirectory { get; set; }
    }
}
