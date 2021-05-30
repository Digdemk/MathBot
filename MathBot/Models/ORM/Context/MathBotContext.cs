using MathBot.Models.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathBot.Models.VM;

namespace MathBot.Models.ORM.Context
{
    public class MathBotContext : DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server = ec2-54-155-35-88.eu-west-1.compute.amazonaws.com; Database = def22a0v0flr1d; UID = jevjcbacfrwxhm; PWD = 26c2344665529290fa8163328393f4dbe1cbc78fc6138125f54e3b20c0767b87; SSL Mode = Require; TrustServerCertificate = True");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<MathBot.Models.VM.SignupVM> SignupVM { get; set; }
    }
}
