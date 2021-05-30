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
        public string Password { get; set; }

        public List<UserOperation> UserOperations{ get; set; }

        //Bir kullanıcının birden çok sorusu olabileceği gibi aynı soruyu soran birden çok kullanıcı da olabilir. 
    }
}
