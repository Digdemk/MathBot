using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathBot.Models.ORM.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Password { get; set; }

        public List<Operation> Operations{ get; set; }

        //Bir kullanıcının birden çok sorusu olabileceği gibi aynı soruyu soran birden çok kullanıcı da olabilir. 
    }
}
