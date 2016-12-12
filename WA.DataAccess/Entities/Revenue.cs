using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.DataAccess.Entities
{
    public class Revenue
    {
        public int Id;
        public bool Issued;
        public DateTime Date_Revenue;
        public string Clothing_size;
        public int Shoe_size;
        public int Size_Headdress;
        public int Size_Glove;
        public int Id_WorkwearDirectory;
    }
}
