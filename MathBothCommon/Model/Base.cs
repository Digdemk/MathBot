using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathBot.Models.ORM.Entities
{
    public class Base
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
