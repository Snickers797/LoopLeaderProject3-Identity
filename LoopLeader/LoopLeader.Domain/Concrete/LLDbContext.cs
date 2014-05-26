using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;
using System.Data.Entity;

namespace LoopLeader.Domain.Concrete
{
    public class LLDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
