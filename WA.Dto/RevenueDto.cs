using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Dto
{
    public class RevenueDto
    {
        public int Id { get; set; }
        public bool Issued { get; set; }
        public DateTime Date_Revenue { get; set; }
        public string Clothing_size { get; set; }
        public int Shoe_size { get; set; }
        public int Size_Headdress { get; set; }
        public int Size_Glove { get; set; }
        public WorkwearDirectoryDto WorkwearDirectory { get; set; }
    }
}
