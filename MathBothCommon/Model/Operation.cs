using MathBot.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MathBothCommon.Model
{
    public class Operation : Base
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public double Result { get; set; }
        public OperationType OperationType { get; set; }
        //public List<UserOperation> UserOperations { get; set; } 


    }
}
