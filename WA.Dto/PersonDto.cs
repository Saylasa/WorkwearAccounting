using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        public int Height { get; set; }
        public int ShoeSize { get; set; }
        public int SizeHeadDress { get; set; }
        public int SizeGlove { get; set; }
        public int ClothingSize { get; set; }
        public NormDto Norm { get; set; }
    }
}
