using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MathBot.Models.ORM.Entities
{
    public class UserOperation : Base
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int OperationId { get; set; }
        [ForeignKey("OperationId")]
        public Operation Operation { get; set; }

    }
}
