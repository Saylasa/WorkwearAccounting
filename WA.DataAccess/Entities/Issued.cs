using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.DataAccess.Entities
{
    public class Issued
    {
        public int Id;
        public int Id_Revenue;
        public int Id_Person;
        public bool Cancellation;
        public DateTime Date_Issued; 
    }
}
